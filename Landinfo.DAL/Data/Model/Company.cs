using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class Company
    {
        public Company()
        {
            PropertyInfo = new HashSet<PropertyInfo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<PropertyInfo> PropertyInfo { get; set; }
    }
}
