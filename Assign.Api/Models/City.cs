using System.ComponentModel.DataAnnotations;

namespace Assign.Api.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PricePerSqM { get; set; }
        public ICollection<CityExtras> CityExtras { get; set; }
    }
}
