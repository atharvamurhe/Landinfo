using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class PropertyInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Unique ID")]
        public long UniqueId { get; set; } //Move to controller = (long) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        [Required(ErrorMessage = "Please enter a Map ID")]
        [Display(Name = "Map ID")]
        public int MapId { get; set; }

        [Display(Name = "Rural(911)")]
        public string Rural { get; set; }

        [Required]
        [Display(Name = "Dominion Land Survey (DLS)")]
        public string Dls { get; set; }

        [Required(ErrorMessage = "Please enter the Latitude value")]
        [Display(Name = "Lat:")]
        public double LocationLat { get; set; }

        [Required(ErrorMessage = "Please enter the Longitude value")]
        [Display(Name = "Long:")]
        public double LocationLong { get; set; }

        [Required(ErrorMessage = "Please enter the Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a Zip/Postal Code")]
        [Display(Name = "Zip/Postal Code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Please select a Country")]
        public Countries Country { get; set; }

        [Required(ErrorMessage = "Please select a State/Province")]
        [Display(Name = "State/Province")]
        public States State { get; set; }
        
        [Required(ErrorMessage = "Please select Company")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Please select Operating Area")]
        [Display(Name = "Operating Area")]
        public int OperatingAreaId { get; set; }

        [Required(ErrorMessage = "Please select Fields")]
        [Display(Name = "Fields")]
        public int FieldId { get; set; }

        [Required(ErrorMessage = "Please select a property")]
        [Display(Name = "Assign Property")]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("PropertyInfo")]
        public virtual Company Company { get; set; }

        [ForeignKey(nameof(OperatingAreaId))]
        [InverseProperty("PropertyInfo")]
        public virtual OperatingArea OperatingArea { get; set; }

        [ForeignKey(nameof(FieldId))]
        [InverseProperty("PropertyInfo")]
        public virtual Field Field { get; set; }

        [ForeignKey(nameof(PropertyId))]
        [InverseProperty("PropertyInfo")]
        public virtual Property Property { get; set; }
    }

    //Data taken from https://data.world
    public enum Countries
    {
        [Display(Name = "Canada")] Canada,
        [Display(Name = "India")] India,
        [Display(Name = "United Kingdom")] UK,
        [Display(Name = "United States of America")] USA
    }

    public enum States
    {
    }
}
