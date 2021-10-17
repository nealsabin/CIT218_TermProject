using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Ride
    {
        public int RideId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the trip.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a value for days.")]
        [Range(0,2000, ErrorMessage = "Number must be greater than 0.")]
        public int? Days { get; set; }

        [Required(ErrorMessage = "Please enter a value for miles.")]
        [Range(0, 10000, ErrorMessage = "Number must be greater than 0.")]
        public int? Miles { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
    }
}
