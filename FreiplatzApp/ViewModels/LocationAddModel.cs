using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Views;
using System.Threading.Tasks;
using FreiplatzApp.Services;
using System.Linq;

namespace FreiplatzApp.ViewModels
{
    [QueryProperty(nameof(LocationID), nameof(LocationID))]
    class LocationAddModel : ViewModelBase
    {
        public Command CancelButtonPressedCommand { get; set; }
        public Command SaveButtonPressedCommand { get; set; }
        public Command EnumPopupButtonPressedCommand { get; set; }
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public CarrierEntry Carrier { get; set; }
        private LocationEntry location;
        public LocationEntry Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged();
            }
        }
        private bool _enumPopupVisibility = false;
        public bool _editableLocation = false;
        public string LocationID
        {
            set
            {
                _editableLocation = true;
                LoadLocation(value);
            }
        }
        public bool EnumPopupVisibility
        {
            get { return _enumPopupVisibility; }
            set { SetProperty(ref _enumPopupVisibility, value); }
        }
        public LocationAddModel()
        {
            if (_editableLocation == false)
            {
                Location = new LocationEntry();
            }
            CancelButtonPressedCommand = new Command(() => CancelButtonPressed());
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            EnumPopupButtonPressedCommand = new Command(() => EnumPopupButtonPressed());
        }
        private async void LoadLocation(string id)
        {
            Carrier = await carrierStore.GetItemAsync("1");
            Location = Carrier.Locations.Find(x => x.Id == id);
        }

        private async void CancelButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveButtonPressed()
        {
            if (!_editableLocation)
            {
                Carrier = await carrierStore.GetItemAsync("1");
                Location.Id = LocationStore.GetInstance().GenerateSeededGuid().ToString();
                Location.Carrierentry = Carrier;
                List<LocationEntry> newLocations = new List<LocationEntry>();
                foreach (LocationEntry location in Carrier.Locations)
                {
                   newLocations.Add(location);
                }
                newLocations.Add(Location);
                Carrier.Locations = newLocations;
                await carrierStore.UpdateItemAsync(Carrier);
            }
            else
            {
                Carrier = Location.Carrierentry;
                List<LocationEntry> newLocations = new List<LocationEntry>();
                foreach (LocationEntry location in Carrier.Locations)
                {
                    if(Location.Id == location.Id)
                    {
                        newLocations.Add(Location);
                    }
                    else
                    {
                        newLocations.Add(location);
                    }
                }
                Carrier.Locations = newLocations;
                await carrierStore.UpdateItemAsync(Carrier);
            }
            await Shell.Current.GoToAsync("..");
        }

        private void EnumPopupButtonPressed()
        {
            EnumPopupVisibility = !EnumPopupVisibility;
        }
    }
}
