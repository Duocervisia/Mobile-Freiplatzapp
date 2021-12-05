using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    public class FilterEntry
    {
        public FilterEntry(){
            MinAge = 0;
            MaxAge = 18;
            AvailableSpace = Enums.AvailableSpace.ALL;
        }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Enums.TypeOfCarrier TypeOfCarrier { get; set; }
        public Enums.AvailableSpace AvailableSpace { get; set; }
        private List<Enums.Paragraphs> _paragraphs = new List<Enums.Paragraphs>();
        public List<Enums.Paragraphs> Paragraphs
        {
            get => _paragraphs;
            set
            {
                _paragraphs = value;
            }
        }
    }
}
