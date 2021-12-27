using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using FreiplatzApp.Helper;
using System.Threading.Tasks;

namespace FreiplatzApp.ViewModels
{
    class ManageProfileModel: ViewModelBase
    {
        public Command SaveButtonPressedCommand { get; set; }
        public Command AddButtonPressedCommand { get; set; }
        public CarrierEntry Carrier { get; set; }
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public ManageProfileModel()
        {
            Carrier = carrierStore.getRandomEntry();
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            AddButtonPressedCommand = new Command((parameter) => AddButtonPressed(parameter));
        }
        private void SaveButtonPressed()
        {

        }
        private bool _addVisibility = false;
        public bool AddVisibility
        {
            get { return _addVisibility; }
            set { SetProperty(ref _addVisibility, value); }
        }
        private void AddButtonPressed(object parameter)
        {
            Animator.TapAnimation(parameter as Image);
            AddVisibility = !AddVisibility;

        }
    }
}
