﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Required]
        [DisplayName("Profile Image")]
        public string ImageUrl { get; set; }

        public Neighborhood Neighborhood { get; set; }
    }
}