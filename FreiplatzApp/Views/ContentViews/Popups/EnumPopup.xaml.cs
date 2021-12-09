using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreiplatzApp.Views.ContentViews.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnumPopup : ContentView
    {
        public ObservableCollection<string> MyList { get; set; } = new ObservableCollection<string>();

        public EnumPopup()
        {
            InitializeComponent();
            Content.BindingContext = this;

            MyList.Add("Item 1");
            MyList.Add("Item 2");
            MyList.Add("Item 3");
            MyList.Add("Item 4");
            MyList.Add("Item 5");
            MyList.Add("Item 6");
            MyList.Add("Item 7");
        }

        public static readonly BindableProperty OwnVisibilityProperty =
           BindableProperty.Create(nameof(OwnVisibility), typeof(bool), typeof(EnumPopup), null);

        public bool OwnVisibility
        {
            get { return (bool)GetValue(OwnVisibilityProperty); }
            set { SetValue(OwnVisibilityProperty, value); }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            OwnVisibility = false;
            //Execute(CancelCommand);
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            OwnVisibility = false;
            //Execute(SaveCommand);
        }

















        public static readonly BindableProperty SaveCommandProperty =
            BindableProperty.Create(nameof(SaveCommand), typeof(ICommand), typeof(EnumPopup), null);

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), typeof(EnumPopup), null);

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

    
        // Helper method for invoking commands safely
        private void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}