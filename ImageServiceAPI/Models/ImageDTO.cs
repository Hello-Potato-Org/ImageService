
using System.ComponentModel.DataAnnotations;

namespace ImageServiceAPI.Models
{
    public record ImageDTO
    {

        public ImageDTO()
        {

        }

        public ImageDTO(int id, string imagePath)
        {
            this.Id = id;
            this.ImagePath = imagePath;
        }

        public ImageDTO(string imagePath)
        {
            this.ImagePath = imagePath;
        }

        public int? Id { get; set; }
        public string? ImagePath { get; set; }
    }
}