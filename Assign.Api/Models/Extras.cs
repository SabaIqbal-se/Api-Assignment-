using System.ComponentModel.DataAnnotations;

namespace Assign.Api.Models
{
    public class Extras
    {
        public int ExtrasId { get; set; }
        [Required]
        public string ExtrasName { get; set; }
        public ICollection<CityExtras> CityExtras { get; set; }
    }
}
