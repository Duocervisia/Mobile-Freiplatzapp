using System;

namespace FreiplatzApp.Models
{
    public class LocationEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Enums.Paragraphs[] Paragraphs { get; set; }
        public int Space { get; set; }
        //Todo: Replace with something useful
        public string Location { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }
        public InstitutionEntry Institution { get; set; }
    }
}
