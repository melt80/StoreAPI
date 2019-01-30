using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Album
{
    public class AlbumDetail
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public AlbumFormat Format { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
