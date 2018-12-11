using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheHopeless.API.Constants;
using TheHopeless.API.Services;

namespace TheHopeless.API.Controllers
{

    [Route("api/picures")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _service;

        public PictureController(IPictureService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _service.GetPicture(id);
            if (entity is null)
            {
                return NotFound();
            }

            return File(entity.Data, entity.Type.GetString());
        }

        [HttpPost("{id}/{main}")]
        //[Route("user/PostUserImage")]  
        public async Task<IActionResult> Post(int id, bool main)
        {
            var type = MimeTypeBuilder.GeMimeType(HttpContext.Request.ContentType);

            var t= await _service.PostPicture(id, main, type, Request.Body);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.DeletePicure(id))
            {
                return Ok();
            }

            return NotFound();
        }

    }

}
