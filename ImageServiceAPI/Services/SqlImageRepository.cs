using Npgsql;
using Dapper;
using ImageServiceAPI.Controllers;
using ImageServiceAPI.Models;



namespace ImageServiceAPI.Services
{
    public class SqlImageRepository : IImageRepository
    {
        private readonly string? _dbConnection = new DbConnection().connectionString;
        private readonly ILogger<ImageController> _logger;

        public SqlImageRepository(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        //Post image
        public async Task<int> CreateImage(ImageDTO imageDTO)
        {
            string sql = $"INSERT INTO images (imagePath) VALUES ('{imageDTO.ImagePath}') RETURNING id";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                return connection.Execute(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the image to the database: " + e.Message);
                throw new InvalidDataException();
            }

        }

        public async Task<ImageDTO> ReadImage(int id)
        {
            Console.WriteLine("Get ImageDTO by ID");
            string sql = $"SELECT * FROM public.images WHERE id = {id}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                return connection.Query<ImageDTO>(sql).First();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the image to the database: " + e.Message);
                throw new InvalidDataException();
            }
        }

        public async Task<ImageDTO> UpdateImage(ImageDTO imageDTO)
        {
            string sql = $"UPDATE public.images SET imagePath = '{imageDTO.ImagePath}' WHERE id = {imageDTO.Id}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                connection.Query<ImageDTO>(sql);
                return imageDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the image in the database: " + e.Message);
                throw new InvalidDataException();
            }


        }
        public async Task<bool> DeleteImage(int imageId)
        {
            string sql = $"DELETE FROM public.images WHERE id = {imageId}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                connection.Execute(sql);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the image in the database: " + e.Message);
                throw new InvalidDataException();
            }
        }
    }
}

