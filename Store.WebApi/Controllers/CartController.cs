using Microsoft.AspNet.Identity;
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
        public class CartController : ApiController
        {
            public IHttpActionResult Get()
            {
                CartService albumService = CreateCartService();
                var carts = albumService.GetCarts();
                return Ok(carts);
            }

            private CartService CreateCartService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var cartService = new CartService(userId);
                return cartService;
            }
        }
}
