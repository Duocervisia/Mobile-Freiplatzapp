using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using System.Threading.Tasks;

namespace FreiplatzApp.ViewModels
{
    class ManageProfileModel: ViewModelBase
    {
        public Command SaveButtonPressedCommand { get; set; }
        public CarrierEntry Carrier { get; set; }
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public ManageProfileModel()
        {
            Carrier = carrierStore.getRandomEntry();
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
        }
        private void SaveButtonPressed()
        {

        }
    }
}
