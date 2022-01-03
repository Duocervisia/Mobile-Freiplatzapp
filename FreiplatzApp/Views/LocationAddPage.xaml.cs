using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreiplatzApp.Models;
using FreiplatzApp.ViewModels;

namespace FreiplatzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationAddPage : ContentPage
    {
        public LocationAddPage()
        {
            InitializeComponent();
            BindingContext = new LocationAddModel();
        }
    }
}