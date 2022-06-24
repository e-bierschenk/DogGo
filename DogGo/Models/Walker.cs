using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Walkers must be assigned a neighborhood")]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}