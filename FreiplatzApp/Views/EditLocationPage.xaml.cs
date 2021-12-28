using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using FreiplatzApp.Helper;
using FreiplatzApp.ViewModels;
using FreiplatzApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(LocationEntry), nameof(LocationEntry))]
    public partial class EditLocationPage : ContentPage
    {
        public EditLocationPage()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }
        public static BindableProperty LocationProperty =
        BindableProperty.Create(
            propertyName: nameof(Location),
            returnType: typeof(LocationEntry),
            declaringType: typeof(EditLocationPage));
        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
    }
}