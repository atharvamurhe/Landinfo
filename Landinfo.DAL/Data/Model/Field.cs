using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class Field
    {
        public Field()
        {
            PropertyInfo = new HashSet<PropertyInfo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [InverseProperty("Field")]
        public virtual ICollection<PropertyInfo> PropertyInfo { get; set; }
    }
}
