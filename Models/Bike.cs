using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Bike
    {
        [Key]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "Please enter a value for make.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Display(Name = "Bike Make")]
        [Column("Bike Make")]
        [StringLength(50)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter a value for model.")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a value for wheel size.")]
        public double WheelSize { get; set; }

    }
}
