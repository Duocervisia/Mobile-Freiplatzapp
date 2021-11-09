using System;
using System.Collections.Generic;
namespace FreiplatzApp.Models
{
    public class LocationEntry : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        private List<Enums.Paragraphs> _paragraphs = new List<Enums.Paragraphs>();
        public List<Enums.Paragraphs> Paragraphs {
            get => _paragraphs;
            set {
                _paragraphs = value;
            } 
        }
        public int Space { get; set; }
        //Todo: Replace with something useful
        public string Location { get; set; }
        public int postalCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }
        public InstitutionEntry Institution { get; set; }
    }
}
