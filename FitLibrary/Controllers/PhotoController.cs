using CloudinaryDotNet.Actions;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FitLibrary.Controllers
{
    [ApiController]
    [Route("api/photo")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        [Route("addPhoto")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPhotoAsync([FromForm] PhotoBLL photo)
        {
            ImageUploadResult uploadResult = null;
            if (photo?.Photo?.Length > 0)
            {
                uploadResult = await _photoService.AddPhotoAsync(photo);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    return Ok(uploadResult.Url.ToString());
                }
            }

            return BadRequest(uploadResult?.Error.Message ?? "Photo wasn't loaded");
        }

        [HttpDelete]
        [Route("deletePhoto")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletePhotoAsync([FromQuery] string publicId)
        {
            var deletionResult = await _photoService.DeletePhotoAsync(publicId);

            if (deletionResult?.StatusCode == HttpStatusCode.OK)
            {
                return NoContent();
            }

            return BadRequest(deletionResult?.Error.Message ?? $"Photo '{publicId}' wasn't deleted");
        }
    }
}