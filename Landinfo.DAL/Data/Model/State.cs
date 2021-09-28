using System;
using System.Collections.Generic;
using System.Text;

namespace Landinfo.DAL.Data.Model
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
