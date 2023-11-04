using System;
using ImageServiceAPI.Models;

namespace ImageServiceAPI.Services
{
    public interface IImageRepository
    {
        Task <int> CreateImage(ImageDTO imageDTO);
        Task<ImageDTO> ReadImage(int imageId);
        Task<ImageDTO> UpdateImage(ImageDTO imageDTO);
        Task<bool> DeleteImage(int imageId);
    }
}