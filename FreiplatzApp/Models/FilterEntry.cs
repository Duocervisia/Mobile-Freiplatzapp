using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using FreiplatzApp.Helper.Converter;

namespace FreiplatzApp.Models
{
    public class FilterEntry : ModelBase
    {
        public FilterEntry(){
            MinAge = 6;
            MaxAge = 18;

            List<ParagraphEntry> paragraphs = new List<ParagraphEntry>();
            foreach (Enums.Paragraphs e in Enum.GetValues(typeof(Enums.Paragraphs)))
            {
                ParagraphEntry entry = new ParagraphEntry();
                entry.Paragraph = e;
                entry.ParagraphName = e.GetDescription();
                paragraphs.Add(entry);
            }
            Paragraphs = paragraphs;
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }
        #endregion


        public List<ParagraphEntry> WantedParagraphs { 
            get {
                return Paragraphs.FindAll(x => x.Selected == true);
            } 
        }

        public List<ParagraphEntry> Paragraphs { get; set; }

        public string WritenSpace
        {
            get
            {
                if(_space == 0)
                {
                    return "beliebig";
                }
                return Convert.ToString(_space);
            }
        }
        public int _space = 0;
        public int Space
        {
            get { return _space; }
            set
            {
                if (_maxAge == value ) return;
                _space = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(WritenSpace));
            }
        }

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

    }
}
