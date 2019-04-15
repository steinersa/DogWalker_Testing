using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool SpayedNeutered { get; set; }

        [Display(Name = "Rating")]
        public int ? Rating { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("Health")]
        public int HealthId { get; set; }
        public Health Health { get; set; }

        [ForeignKey("Demeanor")]
        public int DemeanorId { get; set; }
        public Demeanor Demeanor { get; set; }
    }
}