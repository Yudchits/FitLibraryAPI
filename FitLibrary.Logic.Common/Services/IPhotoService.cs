using CloudinaryDotNet.Actions;
using FitLibrary.Logic.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(PhotoBLL photo);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}