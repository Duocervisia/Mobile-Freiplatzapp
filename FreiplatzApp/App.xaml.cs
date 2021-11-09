﻿using FreiplatzApp.Services;
using FreiplatzApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            PostalCodeStore.GetInstance().init();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
