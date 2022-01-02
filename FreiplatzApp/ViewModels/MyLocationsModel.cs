using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using FreiplatzApp.Helper;
using FreiplatzApp.Views;
using System.Threading.Tasks;
using System.Linq;

namespace FreiplatzApp.ViewModels
{
    class MyLocationsModel : ViewModelBase
    {
        public Command AddButtonPressedCommand { get; set; }
        public CarrierEntry Carrier { get; set; }
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public MyLocationsModel ()
        {
            Carrier = carrierStore.entries.First();
            AddButtonPressedCommand = new Command(async () => await AddButtonPressed());
        }
        private async Task AddButtonPressed()
        {
            await Shell.Current.GoToAsync(nameof(LocationAddPage));
        }
    }
}
