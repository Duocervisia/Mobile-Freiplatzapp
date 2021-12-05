using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FreiplatzApp.Models
{
    public class FilterEntry : INotifyPropertyChanged
    {
        public FilterEntry(){
            MinAge = 6;
            MaxAge = 18;
            AvailableSpace = Enums.AvailableSpace.ALL;
        }

        public int _minAge;
        public int MinAge
        {
            get { return _minAge; }
            set
            {
                if (_minAge == value || value > MaxAge) return;
                _minAge = value;
                MaxSliderEnabled = value == 18 ? false : true;
                OnPropertyChanged(nameof(MinAge));
                OnPropertyChanged(nameof(MinAgeSlider));
            }
        }

        public int _maxAge;
        public int MaxAge
        {
            get { return _maxAge; }
            set
            {
                if (_maxAge == value || value < MinAge) return;
                _maxAge = value;

                MinSliderEnabled = value == 0 ? false : true;
                OnPropertyChanged(nameof(MaxAge));
                OnPropertyChanged(nameof(MaxAgeSlider));
            }
        }

        #region AgeSlider

        public int MaxAgeSlider { get { return _maxAge > 0 ? _maxAge : 1; }}
        private bool _minSliderEnabled = true;
        public bool MinSliderEnabled
        {
            get { return _minSliderEnabled; }
            set
            {
                if (_minSliderEnabled == value) return;
                _minSliderEnabled = value;
                OnPropertyChanged(nameof(MinSliderEnabled));
            }
        }

        public int MinAgeSlider { get { return _minAge < 18 ? _minAge : 17; } }
        private bool _maxSliderEnabled = true;
        public bool MaxSliderEnabled
        {
            get { return _maxSliderEnabled; }
            set
            {
                if (_maxSliderEnabled == value) return;
                _maxSliderEnabled = value;
                OnPropertyChanged(nameof(MaxSliderEnabled));
            }
        }
        #endregion

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
