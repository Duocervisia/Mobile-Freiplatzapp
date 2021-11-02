using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    class InstitutionEntry
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Enums.TypeOfCarrier TypeOfCarrier { get; set; }
        public LocationEntry[] Locations { get; set; }
    }
}

