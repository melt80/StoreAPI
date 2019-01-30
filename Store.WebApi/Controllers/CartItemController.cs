using Microsoft.AspNet.Identity;
using Store.Models.CartItem;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.WebApi.Controllers
{ 
        [Authorize]
        public class CartItemController : ApiController
        {
            public IHttpActionResult Get()
            {
                CartItemService cartItemService = CreateCartItemService();
                var cartItems = cartItemService.GetCartItems();
                return Ok(cartItems);
            }

            public IHttpActionResult Post(CartItemCreate cartItem)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateCartItemService();
                if (!service.CreateCartItem(cartItem))
                    return InternalServerError();
                return Ok();
            }

            public IHttpActionResult Put(CartItemEdit cartItem)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateCartItemService();
                if (!service.UpdateCartItem(cartItem))
                    return InternalServerError();
                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateCartItemService();
                if (!service.DeleteCartItem(id))
                    return InternalServerError();
                return Ok();
            }

        private CartItemService CreateCartItemService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var cartItemService = new CartItemService(userId);
                return cartItemService;
            }
        }
}
