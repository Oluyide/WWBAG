using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WWBG.Models
{
    public class ProfileModels
    {
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Academic Level")]
        public string AcademicLevel { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public string Faculty { get; set; }

        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "Date of birth ")]
        public DateTime DateBirth { get; set; }

    }
}