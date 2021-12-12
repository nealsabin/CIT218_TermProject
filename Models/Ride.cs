using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Ride
    {
        [Key]
        public int RideId { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Display(Name = "Ride Name")]
        [Column("Ride Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a value for days.")]
        [Range(0,2000, ErrorMessage = "Number must be greater than 0.")]
        public int? Days { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a value for miles.")]
        [Range(0, 10000, ErrorMessage = "Number must be greater than 0.")]
        public int? Miles { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(300, MinimumLength = 20)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "Please enter a difficulty rating.")]
        [ForeignKey("DifficultyID")]
        public string DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

        [Required(ErrorMessage = "Please enter a bike.")]
        [ForeignKey("BikeId")]
        public int BikeId { get; set; }
        public Bike Bike { get; set; }
    }
}
