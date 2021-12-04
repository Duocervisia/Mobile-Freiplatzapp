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
        private List<LocationEntry> locations = new List<LocationEntry>();
        public List<LocationEntry> Locations
        {
            get => locations;
            set
            {
                locations = value;
            }
        }

        public List<LocationEntry> getSearchLocations(string searchText)
        {
            List<LocationEntry> entries = new List<LocationEntry>();

            Locations.ForEach(entry => {
                if (entry.IsInSearch(searchText))
                {
                    entries.Add(entry);
                }
            });

            return entries;
        }
    }
}

