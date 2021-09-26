using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class OperatingArea
    {
        public OperatingArea()
        {
            PropertyInfo = new HashSet<PropertyInfo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Area Name")]
        public string AreaName { get; set; }

        [InverseProperty("OperatingArea")]
        public virtual ICollection<PropertyInfo> PropertyInfo { get; set; }
    }
}
