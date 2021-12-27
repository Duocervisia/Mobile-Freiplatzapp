using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using FreiplatzApp.Helper;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrierTile : ContentView
    {
        public Command EditButtonPressedCommand { get; set; }
        public LocationEntry location { get; set; }
        public CarrierTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
            EditButtonPressedCommand = new Command((location) => EditButtonPressed(location));
        }
        private bool _editVisibility = false;
        
        private void EditButtonPressed(object location)
        {
            _editVisibility = true;

        }
    }
}