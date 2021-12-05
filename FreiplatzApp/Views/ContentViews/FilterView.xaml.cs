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
    public partial class FilterView : ContentView
    {
        public FilterView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty FilterProperty =
        BindableProperty.Create(nameof(Filter), typeof(FilterEntry), typeof(FilterEntry), null, BindingMode.TwoWay);

        public FilterEntry Filter
        {
            get { return (FilterEntry)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        private void ResetSelectedParagraphs(object sender, EventArgs e)
        {
            foreach(ParagraphEntry paragraph in Filter.Paragraphs)
            {
                paragraph.Selected = false;
            }
        }

        private void AllSelectedParagraphs(object sender, EventArgs e)
        {
            foreach (ParagraphEntry paragraph in Filter.Paragraphs)
            {
                paragraph.Selected = true;
            }
        }

        private void AdaptSpace(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if(button.Text == "+")
            {
                Filter.Space += 1;
                Button minus = this.FindByName<Button>("minus");
                minus.IsEnabled = true;
            }
            else
            {
                Filter.Space -= 1;

                if (Filter.Space == 0)
                {
                    button.IsEnabled = false;
                }
            }
        }
    }
}