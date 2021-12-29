using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.ViewModels;
using FreiplatzApp.Views;


namespace FreiplatzApp.ViewModels
{
    [QueryProperty(nameof(LocationEntry),nameof(LocationEntry))]
    class EditLocationModel : BindableObject
    {
        public Command CancelButtonPressedCommand { get; set; }
        public Command SaveButtonPressedCommand { get; set; }
        string location = "";
        public string LocationEntry
        {
            get => location;
            set
            {
                location = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PerformOperation(location);
            }
        }
        private string housingname { get; set; }
        public string HousingName
        {
            get { return housingname; }
            set
            {
                housingname = value;
                OnPropertyChanged("HousingName");
            }
        }
        private string description { get; set; }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private void PerformOperation(string getcont)
        {
            var location = JsonConvert.DeserializeObject<LocationEntry>(getcont);
            HousingName = location.HousingName;
            Description = location.Description;
        }
        public EditLocationModel()
        {
            CancelButtonPressedCommand = new Command(() => CancelButtonPressed());
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
        }
        private async void CancelButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
