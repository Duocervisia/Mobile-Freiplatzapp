﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using FreiplatzApp.Helper;
using FreiplatzApp.Views;
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
            Carrier = carrierStore.getExampleEntry();
            SaveButtonPressedCommand = new Command(() => SaveButtonPressed());
            AddButtonPressedCommand = new Command((parameter) => AddButtonPressed(parameter));
        }
        public CarrierEntry transferLocations ()
        {
            return Carrier;
        }
        
        private void SaveButtonPressed()
        {

        }
       
        private async void AddButtonPressed(object parameter)
        {
            Animator.TapAnimation(parameter as Image);
            await Shell.Current.GoToAsync(nameof(LocationAddPage));
        }
    }
}