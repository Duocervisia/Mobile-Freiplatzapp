using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    public class ParagraphEntry : ModelBase
    {
        public Enums.Paragraphs Paragraph { get; set; }

        public string ParagraphName {
            get
            {
                switch (Paragraph)
                {
                    case Enums.Paragraphs.MUTTER_VATER_KIND:
                        return "Mutter / Vater / Kind";
                    case Enums.Paragraphs.HEIMERZIEHUNG:
                        return "Heimerziehung";
                }
                return "";
            }
        }

        private bool _selected = true;
        public bool Selected { 
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                OnPropertyChanged();
            }

        }
        public bool Contains(List<Enums.Paragraphs> paragraphs)
        {
            return paragraphs.Contains(Paragraph);
        }
    }
}
