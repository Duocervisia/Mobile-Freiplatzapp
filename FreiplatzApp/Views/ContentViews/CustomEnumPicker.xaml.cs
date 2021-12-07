using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEnumPicker : ContentView
    {
        public CustomEnumPicker()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty ItemsSourceProperty =
                  BindableProperty.Create(nameof(ItemsSource), typeof(object), typeof(object), null);

        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
                BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(object), null);

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}