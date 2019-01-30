using Newtonsoft.Json;
using Store.Data;
using Store.Models;
using Store.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly Guid _userId;

        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Artist = model.Artist,
                    Format = model.Format,
                    Price = model.Price,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Artist = model.Artist;
                entity.Format = model.Format;
                entity.Price = model.Price;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == albumId && e.OwnerId == _userId);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Albums
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AlbumListItem
                                {
                                    AlbumId = e.AlbumId,
                                    Title = e.Title,
                                    Artist = e.Artist,
                                    Format = e.Format,
                                    Price = e.Price,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public AlbumDetail GetAlbumById(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == albumId && e.OwnerId == _userId);

                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Title = entity.Title,
                        Artist = entity.Artist,
                        Format = entity.Format,
                        Price = entity.Price,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}