using FreiplatzApp.ViewModels;
using FreiplatzApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreiplatzApp.Helper;

namespace FreiplatzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        public FavoriteModel _favoriteModel;
        public FavoritePage()
        {
            InitializeComponent();
        }
    }
}