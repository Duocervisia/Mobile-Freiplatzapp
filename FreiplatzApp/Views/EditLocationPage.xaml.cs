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
    public partial class EditLocationPage : ContentPage
    {
        public EditLocationPage()
        {
            InitializeComponent();
            BindingContext = new EditLocationModel();
        }
    }
}