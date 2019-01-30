using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.CartItem
{
    public class CartItemEdit
    {
        public int CartIemId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
    }
}
