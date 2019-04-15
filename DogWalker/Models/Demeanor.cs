using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Demeanor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Animal Friendly")]
        public bool AnimalFriendly { get; set; }

        [Required]
        [Display(Name = "Kid Friendly")]
        public bool KidFriendly { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}