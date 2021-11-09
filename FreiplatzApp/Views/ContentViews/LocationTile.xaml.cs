using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreiplatzApp.Models;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationTile : ContentView
    {
        public LocationTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(nameof(Location), typeof(LocationEntry), typeof(LocationTile));

        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
    }
}