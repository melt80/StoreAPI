using Store.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Album
{
    public class AlbumCreate
    {
            [Required]
            public string Title { get; set; }
            [Required]
            public string Artist { get; set; }
            [Required]
            public AlbumFormat Format { get; set; }
            [Required]
            public decimal Price { get; set; }
            public override string ToString()
            {
                return base.ToString();
            }
    }
}
