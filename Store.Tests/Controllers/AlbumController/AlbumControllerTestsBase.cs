using System;
using Store.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Store.WebApi.Tests.Controllers.AlbumController
{
    [TestClass]
    public abstract class AlbumControllerTestsBase
    {
        protected WebApi.Controllers.AlbumController Controller;

        protected Mock<IAlbumService> AlbumService;

        [TestInitialize]
        public virtual void Arrange()
        {
            AlbumService = new Mock<IAlbumService>();

            Controller = new WebApi.Controllers.AlbumController(
                new Lazy<IAlbumService>(() => AlbumService.Object));
        }
    }
}