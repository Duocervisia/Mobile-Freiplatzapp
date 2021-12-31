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
        public CarrierTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
            EditButtonPressedCommand = new Command((location) => EditButtonPressed(location));
        }

        public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(
            propertyName: nameof(Location),
            returnType: typeof(LocationEntry),
            declaringType: typeof(CarrierTile),
            propertyChanged: locationPropertyChanged);
        public static void locationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CarrierTile thisCarrierTile = bindable as CarrierTile;
            //thisCarrierTile.checkFavorite(null, true);
        }
        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        private bool EditVisibility = false;
        private void EditButtonPressed(object location)
        {
            Animator.TapAnimation(editImage);
            EditVisibility = true;

        }
    }
}