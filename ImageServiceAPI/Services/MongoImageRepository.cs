using Npgsql;
using Dapper;
using ImageServiceAPI.Controllers;
using ImageServiceAPI.Models;



namespace ImageServiceAPI.Services
{
    public class MongoImageRepository : IImageRepository
    {
        private readonly string? _dbConnection = Environment.GetEnvironmentVariable("connectionstring");
        private readonly ILogger<ImageController> _logger;

        public MongoImageRepository(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        //Post image
        public async Task<int> CreateImage(ImageDTO imageDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageDTO> ReadImage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageDTO> UpdateImage(ImageDTO imageDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteImage(int imageId)
        {
           throw new NotImplementedException();
        }
    }
}

