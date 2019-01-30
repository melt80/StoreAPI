using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Data;

namespace Store.Models.CartItem
{
    public class CartItemCreate
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
