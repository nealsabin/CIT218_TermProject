using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TermProject.Models
{
    public class Difficulty
    {
        [Key]
        public string DifficultyId { get; set; }
        public string Rating { get; set; }
        //public Rating DifficultyRating { get; set; }

        //public enum Rating
        //{
        //    Easy = 1,
        //    Medium = 2,
        //    Hard = 3
        //}
    }
}
