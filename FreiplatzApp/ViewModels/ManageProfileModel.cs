using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using System.Threading.Tasks;

namespace FreiplatzApp.ViewModels
{
    class ManageProfileModel: ViewModelBase
    {
        public Command SaveButtonPressedCommand { get; set; }
        public CarrierEntry Carrier { get; set; }
        public ManageProfileModel()
        {
            Carrier = new CarrierEntry();
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
        }
        private void SaveButtonPressed()
        {

        }
    }
}
