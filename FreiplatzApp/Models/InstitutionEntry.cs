using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    public class InstitutionEntry : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Enums.TypeOfCarrier TypeOfCarrier { get; set; }
        public List<LocationEntry> Locations { get; set; }
    }
}

