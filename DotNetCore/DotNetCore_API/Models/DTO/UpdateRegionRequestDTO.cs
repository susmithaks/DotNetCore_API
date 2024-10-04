using System.ComponentModel.DataAnnotations;

namespace DotNetCore_API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength ( 3 , ErrorMessage ="should be 3 char")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
