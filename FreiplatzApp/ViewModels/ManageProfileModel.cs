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
    class ManageProfileModel: ViewModelBase
    {
        public Command SaveButtonPressedCommand { get; set; }
        public Command AddButtonPressedCommand { get; set; }
        public Command PageAppearingCommand { get; set; }

        public CarrierEntry carrier;
        public CarrierEntry Carrier
        {
            get { return carrier; }
            set { carrier = value; OnPropertyChanged(); }
        }
        public CarrierStore carrierStore = CarrierStore.GetInstance();
        public List<Enums.TypeOfCarrier> TypeOfCarrier
        {
            get
            {
                return Enum.GetValues(typeof(Enums.TypeOfCarrier)).Cast<Enums.TypeOfCarrier>().ToList();
            }
        }
        public ManageProfileModel()
        {
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            AddButtonPressedCommand = new Command(async () => await AddButtonPressed());
            PageAppearingCommand = new Command(() => OnAppearing());
        }

        private void SaveButtonPressed()
        {

        }
       
        private async Task AddButtonPressed()
        {
            await Shell.Current.GoToAsync(nameof(LocationAddPage));
        }

        private async void OnAppearing()
        {
            Carrier = await carrierStore.GetItemAsync("1");
        }
    }
}
