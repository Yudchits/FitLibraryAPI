using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FitLibrary.Logic.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            _cloudinary = new Cloudinary(config.Value.Url);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(PhotoBLL photo)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var image = await Image.LoadAsync(photo.Photo.OpenReadStream()))
                {
                    image.Mutate(x => x.Crop(new Rectangle(
                        photo.FrameLeft,
                        photo.FrameTop,
                        photo.FrameWidth,
                        photo.FrameHeight)));

                    image.Mutate(x => x.Resize(photo.PhotoWidth, photo.PhotoHeight));

                    await image.SaveAsJpegAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                }

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.Photo.FileName, memoryStream)
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult;
            }
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deletionParams);
        }
    }
}