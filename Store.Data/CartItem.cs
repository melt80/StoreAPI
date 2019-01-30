using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Store.Data
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Album Album { get; set; }
    }
}
