using System;
using System.Collections.Generic;
using FreiplatzApp.Models;

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
                OnPropertyChanged();
            } 
        }
        public int Space { get; set; }
        //Todo: Replace with something useful
        public string Location { get; set; }
        public PostalEntry PostalEntry { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }
        public bool showAvailableSpace { get; set; }
        public InstitutionEntry Institution { get; set; }

        public List<Enum> ParsingParagraphs
        {
            set
            {
                List<Enums.Paragraphs> list = new List<Enums.Paragraphs>();
                foreach (Enum test in value){
                    list.Add((Enums.Paragraphs)test);
                }
                Paragraphs = list;
            }
        }

        public bool IsInSearch(string searchText)
        {
            return PostalEntry.IsInSearch(searchText);
        }
        public bool HasParagraph(FilterEntry filter)
        {
            foreach(ParagraphEntry entry in filter.WantedParagraphs)
            {
                if (entry.Contains(Paragraphs))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasSpace(FilterEntry filter)
        {
            if(filter.Space == 0 || showAvailableSpace || filter.Space <= Space)
            {
                return true;
            }
            return false;
        }
    }
}
