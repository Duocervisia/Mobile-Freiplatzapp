using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.Models
{
    public class EnumEntry : ModelBase
    {
        public EnumEntry(Enum value)
        {
            EnumValue = value;
        }

        public Enum EnumValue { get; set; }

        private bool _selected = true;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                OnPropertyChanged();
            }
        }    
    }
}
