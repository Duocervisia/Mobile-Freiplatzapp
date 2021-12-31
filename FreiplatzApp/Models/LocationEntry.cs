using System;
using System.Collections.Generic;
using FreiplatzApp.Models;

namespace FreiplatzApp.Models
{
    public class LocationEntry : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; } = 0;
        public string TextMinAge
        {
            get => Convert.ToString(MinAge);
            set
            {
                if (value == "") MinAge = 0;
                else MinAge = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        public int MaxAge { get; set; } = 18;
        public string TextMaxAge
        {
            get => Convert.ToString(MaxAge);
            set
            {
                if (value == "") MaxAge = 0;
                else MaxAge = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        private List<Enums.Paragraphs> _paragraphs = new List<Enums.Paragraphs>();
        public List<Enums.Paragraphs> Paragraphs {
            get => _paragraphs;
            set {
                _paragraphs = value;
                OnPropertyChanged();
            } 
        }
        public int Space { get; set; }
        public string TextSpace {
            get => Convert.ToString(Space);
            set
            {
                if (value == "") Space = 0;
                else Space = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }

        public string Street { get; set; }
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
        public PostalEntry PostalEntry { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }
        public bool ShowAvailableSpace { get; set; } = true;
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
            if(filter.Space == 0 || ShowAvailableSpace || filter.Space <= Space)
            {
                return true;
            }
            return false;
        }
    }
}
