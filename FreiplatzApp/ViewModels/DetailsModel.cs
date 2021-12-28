using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using System.Threading.Tasks;


namespace FreiplatzApp.ViewModels
{
    public class DetailsModel : ViewModelBase
    {
        
        public DetailsModel(LocationEntry location) {
            Location = location;
        }

        public LocationEntry Location { get; set; }


    }
}
