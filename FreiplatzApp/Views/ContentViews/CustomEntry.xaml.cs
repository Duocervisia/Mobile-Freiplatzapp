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
    public partial class CustomEntry : ContentView
    {
        public CustomEntry()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty KeyboardProperty =
                   BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(CustomEntry), Keyboard.Default);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
                    BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEntry), null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry), null, BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set {SetValue(TextProperty, (string) value); }
        }
    }
}