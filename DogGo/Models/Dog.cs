using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(55)]
        [DisplayName("Dog Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(55)]
        public string Breed { get; set; }

        [Required(ErrorMessage = "A dog must be assigned an owner")]
        public int OwnerId { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }

    }
}
