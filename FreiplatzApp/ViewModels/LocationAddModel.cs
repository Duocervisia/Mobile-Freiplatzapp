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
        public LocationEntry Location { get; set; }
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
        private void LoadLocation(string id)
        {   
            Carrier = carrierStore.entries.First();
            Location = Carrier.Locations.Find(x => x.Id == id);
        }

        private async void CancelButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private void EnumPopupButtonPressed()
        {
            EnumPopupVisibility = !EnumPopupVisibility;
        }
    }
}
