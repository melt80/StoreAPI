using Newtonsoft.Json;
using Store.Data;
using Store.Models;
using Store.Models.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class CartItemService
    {
        private readonly Guid _userId;

        public CartItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCartItem(CartItemCreate model)
        {
            var entity =
                new CartItem()
                {
                    OwnerId = _userId,
                    AlbumId = model.AlbumId,
                    Quantity = model.Quantity,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CartItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCartItem(CartItemEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CartItems
                        .Single(e => e.CartItemId == model.CartIemId && e.OwnerId == _userId);

                entity.Quantity = model.Quantity;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCartItem(int cartItemId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CartItems
                        .Single(e => e.CartItemId == cartItemId && e.OwnerId == _userId);

                ctx.CartItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CartListItem> GetCartItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CartItems
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CartListItem
                                {
                                    CartItemId = e.CartItemId,
                                    AlbumId = e.AlbumId,
                                    Quantity = e.Quantity,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}