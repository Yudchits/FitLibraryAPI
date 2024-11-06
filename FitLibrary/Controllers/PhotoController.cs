using CloudinaryDotNet.Actions;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FitLibrary.WebAPI.Controllers
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
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddPhotoAsync([FromForm] PhotoBLL photo)
        {
            if (photo?.Photo?.Length > 0)
            {
                ImageUploadResult uploadResult = await _photoService.AddPhotoAsync(photo);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    return Ok(new { PhotoUrl = uploadResult.Url.ToString() });
                }
            }

            return StatusCode(500, "Не удалось загрузить фото. Попробуйте позже");
        }

        [HttpDelete]
        [Route("deletePhoto")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePhotoAsync([FromBody] string publicUrl)
        {
            var publicId = publicUrl.Split("/").Last().Split(".").FirstOrDefault();

            if (publicId != null && publicId.Trim().Length > 0)
            {
                var deletionResult = await _photoService.DeletePhotoAsync(publicId);

                if (deletionResult?.StatusCode == HttpStatusCode.OK)
                {
                    return NoContent();
                }
            }

            return StatusCode(500, "Не удалось удалить фото. Попробуйте позже");
        }
    }
}