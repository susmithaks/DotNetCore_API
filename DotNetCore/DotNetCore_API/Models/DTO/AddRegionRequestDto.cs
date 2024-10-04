using System.ComponentModel.DataAnnotations;

namespace DotNetCore_API.Models.DTO
{
    public class AddRegionRequestDto
    {

        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
