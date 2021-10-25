using FreiplatzApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FreiplatzApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}