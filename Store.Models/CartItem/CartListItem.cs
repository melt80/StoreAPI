using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.CartItem
{
    public class CartListItem
    {
        public int CartItemId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
