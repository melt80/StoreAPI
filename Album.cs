using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Data
{
    public enum AlbumFormat
    {
        CD = 1, LP = 2, Cassette = 3
    }

    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public AlbumFormat Format { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
