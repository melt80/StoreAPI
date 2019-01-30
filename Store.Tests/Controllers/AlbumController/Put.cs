using System.Web.Http;
using System.Web.Http.Results;
using Store.Models.Album;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Store.WebApi.Tests.Controllers.AlbumController
{
    [TestClass]
    public class Put : AlbumControllerTestsBase
    {
        private bool _updateNoteSuccess = true;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            AlbumService
                .Setup(x => x.UpdateAlbum(It.IsAny<AlbumEdit>()))
                .Returns(() => _updateNoteSuccess);
        }

        private IHttpActionResult Act()
        {
            return Controller.Put(new AlbumEdit());
        }

        [TestMethod]
        public void ReturnsOkResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void CallsUpdateNote()
        {
            Act();

            NoteService.Verify(
                x => x.UpdateNote(It.IsAny<NoteEdit>()),
                Times.Once);
        }

        [TestMethod]
        public void ReturnsInvalidModelStateResult_GivenInvalidModelState()
        {
            Controller.ModelState.AddModelError("", "some error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void ReturnsInternalServerErrorResult_GivenCreateNoteFails()
        {
            _updateNoteSuccess = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}