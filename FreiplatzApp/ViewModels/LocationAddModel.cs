using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Views;
using System.Threading.Tasks;

namespace FreiplatzApp.ViewModels
{
    class LocationAddModel : ViewModelBase
    {
        public Command CancelButtonPressedCommand { get; set; }
        public Command SaveButtonPressedCommand { get; set; }
        public Command EnumPopupButtonPressedCommand { get; set; }

        public LocationEntry Location { get; set; }
        private bool _enumPopupVisibility = false;
        public bool EnumPopupVisibility
        {
            get { return _enumPopupVisibility; }
            set { SetProperty(ref _enumPopupVisibility, value); }
        }
        public LocationAddModel()
        {
            Location = new LocationEntry();
            Location.Paragraphs.Add(Enums.Paragraphs.CRISIS_FACILITY_ANDEMERGENCY_SERVICE);
            CancelButtonPressedCommand = new Command(() => CancelButtonPressed());
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            EnumPopupButtonPressedCommand = new Command(() => EnumPopupButtonPressed());
        }

        private async void CancelButtonPressed()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveButtonPressed()
        {
         
        }

        private void EnumPopupButtonPressed()
        {
            EnumPopupVisibility = !EnumPopupVisibility;
        }
    }
}
