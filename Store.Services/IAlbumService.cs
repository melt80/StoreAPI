using Store.Models.Album;
using System.Collections.Generic;

namespace Store.Services
{
    public interface IAlbumService
    {
        bool CreateAlbum(AlbumCreate model);
        IEnumerable<AlbumListItem> GetAlbums();
        AlbumDetail GetAlbumById(int albumId);
        bool UpdateAlbum(AlbumEdit model);
        bool DeleteAlbum(int albumId);
    }
}