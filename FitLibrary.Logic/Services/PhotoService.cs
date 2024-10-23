using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FitLibrary.Logic.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.Extensions.Options;
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
            var uploadResult = new ImageUploadResult();

            var photoFile = photo?.Photo;
            if (photoFile?.Length > 0)
            {
                using (var stream = photoFile.OpenReadStream())
                {
                    int width = photo.Width > 0 ? photo.Width : 750;
                    int height = photo.Height > 0 ? photo.Height : 500;

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(photoFile.FileName, stream),
                        Transformation = new Transformation()
                            .Width(width)
                            .Height(height)
                            .Crop("fill")
                            .Gravity("face")
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deletionParams);
        }
    }
}