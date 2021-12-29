﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using System.Runtime.CompilerServices;


namespace FreiplatzApp.ViewModels
{
    [QueryProperty(nameof(LocationEntry),nameof(LocationEntry))]
    class EditLocationModel : BindableObject
    {
        public Command CancelButtonPressedCommand { get; set; }
        public Command SaveButtonPressedCommand { get; set; }
        public Command EnumPopupButtonPressedCommand { get; set; }
        private bool _enumPopupVisibility = false;
        public bool EnumPopupVisibility
        {
            get { return _enumPopupVisibility; }
            set { SetProperty(ref _enumPopupVisibility, value); }
        }
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
        { get { return housingname; } set {housingname = value;OnPropertyChanged("HousingName");}}
        private string description { get; set; }
        public string Description
        {get { return description; } set { description = value; OnPropertyChanged("Description");}}
        private string textMinAge { get; set; }
        public string TextMinAge
        {get { return textMinAge; } set { textMinAge = value; OnPropertyChanged("TextMinAge"); } }
        private string textMaxAge { get; set; }
        public string TextMaxAge
        {get { return textMaxAge; } set { textMaxAge = value; OnPropertyChanged("TextMaxAge");}}

        private List<Enums.Paragraphs> _paragraphs = new List<Enums.Paragraphs>();
        public List<Enums.Paragraphs> Paragraphs
        {get { return _paragraphs; } set {_paragraphs = value;OnPropertyChanged("Paragraphs");}}
        public bool ShowAvailableSpace { get; set; } = true;
        private string textSpace { get; set; }
        public string TextSpace
        { get { return textSpace; } set { textSpace = value; OnPropertyChanged("TextSpace");}}
        private string street { get; set; }
        public string Street
        { get { return street; } set { street = value; OnPropertyChanged("Street"); } }
        private string textPostalNumber { get; set; }
        public string TextPostalNumber
        { get { return textPostalNumber; } set { textPostalNumber = value; OnPropertyChanged("PostalNumber"); } }
        private string telephoneNumber { get; set; }
        public string TelephoneNumber
        { get { return telephoneNumber; } set { telephoneNumber = value; OnPropertyChanged("TelephoneNumber"); } }
        private string website { get; set; }
        public string Website
        { get { return website; } set { website = value; OnPropertyChanged("Website"); } }
        private string email { get; set; }
        public string EMail
        { get { return email; } set { email = value; OnPropertyChanged("EMail"); } }
        private string carriername { get; set; }
        public string CarrierName
        { get { return carriername; } set { carriername = value; OnPropertyChanged("CarrierName"); } }
        private void PerformOperation(string getcont)
        {
            var location = JsonConvert.DeserializeObject<LocationEntry>(getcont);
            HousingName = location.HousingName;
            Description = location.Description;
            TextMinAge = location.TextMinAge;
            TextMaxAge = location.TextMaxAge;
            Paragraphs = location.Paragraphs;
            TextSpace = location.TextSpace;
            Street = location.Street;
            TextPostalNumber = location.TextPostalNumber;
            TelephoneNumber = location.TelephoneNumber;
            Website = location.Website;
            EMail = location.EMail;
            CarrierName = location.Carrierentry.CarrierName;
        }
        public EditLocationModel()
        {
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
            await Shell.Current.GoToAsync("..");
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        private void EnumPopupButtonPressed()
        {
            EnumPopupVisibility = !EnumPopupVisibility;
        }
        
    }
}
