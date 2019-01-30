using Microsoft.AspNet.Identity;
using Store.Models.Album;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.WebApi.Controllers
{
    [Authorize]
    public class AlbumController : ApiController
    {

        // not every action path needs a note service, so Lazy allows us to defer instantiation until we actually need one.
        private readonly Lazy<IAlbumService> _albumService;

        /// <summary>
        /// Production constructor. Creates a real NoteService.
        /// </summary>
        public AlbumController()
        {
            _albumService = new Lazy<IAlbumService>(() =>
                new AlbumService(Guid.Parse(User.Identity.GetUserId())));
        }

        /// <summary>
        /// Testing constructor. Lets us inject a mocked INoteService.
        /// </summary> 
        public AlbumController(Lazy<IAlbumService> albumService)
        {
            _albumService = albumService;
        }

        public IHttpActionResult Get()
        {
            var albums = _albumService.Value.GetAlbums();
            return Ok(albums);
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_albumService.Value.CreateAlbum(album))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_albumService.Value.UpdateAlbum(album))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_albumService.Value.DeleteAlbum(id))
                return InternalServerError();
            return Ok();
        }
    }
}
