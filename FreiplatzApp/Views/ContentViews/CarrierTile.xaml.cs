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
using FreiplatzApp.ViewModels;
using FreiplatzApp.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrierTile : ContentView
    {
        //public Command EditButtonPressedCommand { get; set; }
        public CarrierTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
            //EditButtonPressedCommand = new Command((parameter) => EditButtonPressed(parameter));
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
        }
        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
        private async void edit_Clicked(object sender, EventArgs e)
        {
            Animator.TapAnimation(editImage);
            Routing.RegisterRoute(nameof(EditLocationPage), typeof(EditLocationPage));
            var jsonStr = JsonConvert.SerializeObject((Location),new JsonSerializerSettings()
            {ReferenceLoopHandling = ReferenceLoopHandling.Ignore,});
            await Shell.Current.GoToAsync($"{nameof(EditLocationPage)}?LocationEntry={jsonStr}");
        }
    }
}