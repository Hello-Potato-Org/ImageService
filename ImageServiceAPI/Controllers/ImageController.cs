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
    public async Task<ImageDTO?> GetData(int id) => await _imageRepository.ReadImage(id);

    [HttpPost]
    public async Task<int?> PostData(string imagePath) => await _imageRepository.CreateImage(new ImageDTO(imagePath));
   
    [HttpPut]
    public async Task<ImageDTO?> PutData(int id, string imagePath) => await _imageRepository.UpdateImage(new ImageDTO(id, imagePath));

    [HttpDelete]
    public async Task<bool?> DeleteData(int imageId) => await _imageRepository.DeleteImage(imageId);

}
