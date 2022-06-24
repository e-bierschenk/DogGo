using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DogGo.Models
{
    public class Walk
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, int.MaxValue)] 
        public int Duration { get; set; }

        [Required]
        public int WalkerId { get; set; }

        [Required]
        public int DogId { get; set; }

        public Owner Owner { get; set; }
        public Dog Dog { get; set; }
    }
}
