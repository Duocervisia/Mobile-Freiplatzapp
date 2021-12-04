
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

using FreiplatzApp.Helper;
using FreiplatzApp.Models;

namespace FreiplatzApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Initializer.init();
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
