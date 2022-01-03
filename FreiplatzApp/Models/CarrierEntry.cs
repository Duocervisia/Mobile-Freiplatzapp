using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    public class CarrierEntry : ModelBase
    {
        private string carrierName;
        public string CarrierName
        {
            get
            {
                return carrierName;
            }
            set
            {
                carrierName = value;
                OnPropertyChanged();
            }
        }
        public string Description { get; set; }
        public string Street { get; set; }
        public PostalEntry PostalEntry { get; set; }
        public int PostalNumber { get; set; }
        public string TextPostalNumber
        {
            get => Convert.ToString(PostalNumber);
            set
            {
                if (value == "") PostalNumber = 0;
                else PostalNumber = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }

        public Enums.TypeOfCarrier _typeOfCarrier = Enums.TypeOfCarrier.ALL;
        public Enums.TypeOfCarrier TypeOfCarrier
        {
            get { return _typeOfCarrier; }
            set
            {
                if (_typeOfCarrier == value) return;
                _typeOfCarrier = value;

                OnPropertyChanged();
            }
        }

        private List<LocationEntry> locations = new List<LocationEntry>();
        public List<LocationEntry> Locations
        {
            get => locations;
            set
            {
                locations = value;
                OnPropertyChanged();
            }
        }

        public List<LocationEntry> getSearchLocations(string searchText, FilterEntry filter)
        {
            List<LocationEntry> entries = new List<LocationEntry>();

            if(filter.TypeOfCarrier != Enums.TypeOfCarrier.ALL &&
                TypeOfCarrier != filter.TypeOfCarrier)
            {
                return entries;
            }

            Locations.ForEach(entry => {
                if (entry.IsInSearch(searchText) &&
                   (entry.MinAge <= filter.MaxAge && entry.MaxAge >= filter.MinAge) &&
                    entry.HasParagraph(filter) &&
                    entry.HasSpace(filter)
                )
                {
                    entries.Add(entry);
                }
            });

            return entries;
        }
    }
}

