using ImageServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ImageServiceAPI.Models;


namespace ImageServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{


    private readonly ILogger<ImageController> _logger;
    private readonly IImageRepository _imageRepository;

    public ImageController(ILogger<ImageController> logger, IImageRepository imageRepository)
    {
        _logger = logger;
        _imageRepository = imageRepository;
    }


    [HttpGet]
    public async Task<ImageDTO?> GetData(int id)
    {
        ImageDTO? result = await _imageRepository.ReadImage(id);
        return result;
    }

    [HttpPost]
    public async Task<int?> PostData(string imagePath)
    {
        int? result = await _imageRepository.CreateImage(new ImageDTO(imagePath));
        return result;
    }

    [HttpPut]
    public async Task<ImageDTO?> PutData(int id, string imagePath)
    {
        ImageDTO? result = await _imageRepository.UpdateImage(new ImageDTO(id, imagePath));
        return result;
    }

    [HttpDelete]
    public async Task<bool?> DeleteData(int imageId)
    {
        bool? result = await _imageRepository.DeleteImage(imageId);
        return result;
    }

}
