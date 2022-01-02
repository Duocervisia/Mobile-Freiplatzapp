using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreiplatzApp.Models;
using FreiplatzApp.Helper;
using System.Collections;

namespace FreiplatzApp.Views.ContentViews.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnumPopup : ContentView
    {
        private Type EnumType;
        private Type ListType;

        public List<Enum> CopySelectedItems { get; set; } = new List<Enum>();
        public ObservableCollection<EnumEntry> ItemSource { get; set; } = new ObservableCollection<EnumEntry>();

        public EnumPopup()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty OwnVisibilityProperty =
           BindableProperty.Create(nameof(OwnVisibility), typeof(bool), typeof(EnumPopup), null);

        public bool OwnVisibility
        {
            get { return (bool)GetValue(OwnVisibilityProperty); }
            set { SetValue(OwnVisibilityProperty, value); }
        }

        public static readonly BindableProperty SelectedItemsProperty =
           BindableProperty.Create(nameof(SelectedItems), typeof(object), typeof(EnumPopup), propertyChanged: SelectedItemsPropertyChanged);

        public object SelectedItems
        {
            get { return (object)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly BindableProperty EnumItemSourceProperty =
          BindableProperty.Create(nameof(EnumItemSource), typeof(List<Enum>), typeof(EnumPopup));

        public List<Enum> EnumItemSource
        {
            get { return (List<Enum>)GetValue(EnumItemSourceProperty); }
            set { SetValue(EnumItemSourceProperty, value); }
        }

        public static readonly BindableProperty EnumParsingProperty =
         BindableProperty.Create(nameof(EnumParsing), typeof(List<Enum>), typeof(EnumPopup));

        public List<Enum> EnumParsing
        {
            get { return (List<Enum>)GetValue(EnumParsingProperty); }
            set { SetValue(EnumParsingProperty, value); }
        }

        public static void SelectedItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue != null)
            {
                EnumPopup enumPopup = bindable as EnumPopup;
                enumPopup.ListType = newValue.GetType();
                enumPopup.EnumType = enumPopup.ListType.GetGenericArguments().Single();
                //Array list = Enum.GetValues(EnumType);
                //enumPopup.ItemSource = list;
                //might solve: https://stackoverflow.com/questions/32935297/how-to-use-local-variable-as-a-type-compiler-says-it-is-a-variable-but-is-used
                //List<object> newValueList = newValue as EnumType;
                //List<object> myAnythingList = (newValue as IEnumerable<object>).Cast<object>().ToList();
                //enumPopup.CopySelectedItems = new List<object>(newValueList);
                enumPopup.CopySelectedItems = ((ICollection)newValue).Cast<Enum>().ToList();
                enumPopup.init();
            }
        }

        private void init() {

            List<Enum> list = Enum.GetValues(EnumType).Cast<Enum>().ToList();
            ItemSource.Clear();

            foreach (Enum enumValue in list)
            {
                EnumEntry enumEntry = new EnumEntry(enumValue);
                enumEntry.Selected = CopySelectedItems.Contains(enumValue);
                ItemSource.Add(enumEntry);
            }
        }
    

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            OwnVisibility = false;
            Device.BeginInvokeOnMainThread(init);
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            OwnVisibility = false;
            Task.Run(save);
        }
        private void save()
        {

            List<Enum> newEnumList = new List<Enum>();
            foreach (EnumEntry enumEntry in ItemSource)
            {
                if (enumEntry.Selected)
                {
                    newEnumList.Add(enumEntry.EnumValue);
                }
            }

            EnumParsing = newEnumList;
        }



        private void TappedCheckboxLabel(object sender, EventArgs e)
        {
            var d = (TappedEventArgs)e;
            EnumEntry enumEntry = d.Parameter as EnumEntry;
            enumEntry.Selected = !enumEntry.Selected;
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