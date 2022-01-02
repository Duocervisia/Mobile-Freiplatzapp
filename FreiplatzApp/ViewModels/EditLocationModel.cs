using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using System.Runtime.CompilerServices;
using FreiplatzApp.Services;

namespace FreiplatzApp.ViewModels
{
    [QueryProperty(nameof(LocationID),nameof(LocationID))]
    class EditLocationModel : BindableObject
    {
        public Command CancelButtonPressedCommand { get; set; }
        public Command SaveButtonPressedCommand { get; set; }
        public Command EnumPopupButtonPressedCommand { get; set; }
        private bool _enumPopupVisibility = false;
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public CarrierEntry Carrier { get; set; }
        public string LocationID
        {
            set
            {
                LoadLocation(value);
            }
        }
        public bool EnumPopupVisibility
        {
            get { return _enumPopupVisibility; }
            set { SetProperty(ref _enumPopupVisibility, value); }
        }
        private List<Enums.Paragraphs> _paragraphs = new List<Enums.Paragraphs>();
        public List<Enums.Paragraphs> Paragraphs
        {get { return _paragraphs; } set {_paragraphs = value;OnPropertyChanged("Paragraphs");}}
        public List<Enum> ParsingParagraphs
        {
            set
            {
                List<Enums.Paragraphs> list = new List<Enums.Paragraphs>();
                foreach (Enum test in value)
                {
                    list.Add((Enums.Paragraphs)test);
                }
                Paragraphs = list;
            }
        }
        public bool ShowAvailableSpace { get; set; } = true;
        public EditLocationModel()
        {
            CancelButtonPressedCommand = new Command(() => CancelButtonPressed());
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            EnumPopupButtonPressedCommand = new Command(() => EnumPopupButtonPressed());
        }
        private void LoadLocation(string id)
        {
            Carrier = carrierStore.entries.First();
            LocationEntry Location = Carrier.Locations.Find(x => x.Id == id);
        }
        
        private async void CancelButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        private void EnumPopupButtonPressed()
        {
            EnumPopupVisibility = !EnumPopupVisibility;
        }
        
    }
}
