using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class Property
    {
        public Property()
        {
            PropertyInfo = new HashSet<PropertyInfo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [InverseProperty("Property")]
        public virtual ICollection<PropertyInfo> PropertyInfo { get; set; }
    }
}
