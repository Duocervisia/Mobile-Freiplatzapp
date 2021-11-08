using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FreiplatzApp.Models;
using FreiplatzApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSearchBar : ContentView
    {
        //public IDataStore<PostalEntry> DataStorePostalEntries => DependencyService.Get<IDataStore<PostalEntry>>();

        public CustomSearchBar()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty PlaceholderProperty =
                    BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEntry), null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry), null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}