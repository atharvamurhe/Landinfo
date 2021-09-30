using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class SurfaceDevelopment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a type")]
        public Types Type { get; set; }

        [Display(Name = "Sub Type")]
        [Required(ErrorMessage = "Please select a sub type")]
        public SubTypes SubType { get; set; }
        public string Comment { get; set; }

        [Required(ErrorMessage = "Please select a status")]
        public Statuses Status { get; set; }
        public OtherStatuses? OtherStatus { get; set; }
        public Sensitivities? Sensitivity { get; set; }
    }

    public enum Types
    {
        [Display(Name = "Residence")] Residence = 1,
        [Display(Name = "Non Residence Land Users")] NonResidence = 2,
        [Display(Name = "Public Facility")] PublicFacility = 3
    }

    public enum SubTypes
    {

    }

    public enum Statuses
    { 

    }

    public enum OtherStatuses
    {

    }

    public enum Sensitivities
    {
        [Display(Name = "Mild")] Mild = 1,
        [Display(Name = "Medium")] Medium = 2,
        [Display(Name = "High")] High = 3,
        [Display(Name = "Very High")] VeryHigh = 3
    }
}
