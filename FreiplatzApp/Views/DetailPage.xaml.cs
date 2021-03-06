using FreiplatzApp.Models;
using FreiplatzApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(LocationEntry location)
        {
            InitializeComponent();
            Content.BindingContext = new DetailsModel(location);
        }
    }
}