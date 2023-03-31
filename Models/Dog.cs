using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DogGo.Models
{
    public class Dog
    {
        
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Owner Name")]
        public int OwnerId { get; set; }

        [Required]
        [DisplayName("Breed")]
        public string Breed { get; set; }

        public string Notes { get; set; }

        [Required]
        [DisplayName("Dog Photo")]
        public string ImageUrl { get; set; }

        public Owner Owner { get; set; }
    }
}

