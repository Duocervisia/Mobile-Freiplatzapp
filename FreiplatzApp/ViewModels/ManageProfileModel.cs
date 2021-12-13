using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;
using System.Threading.Tasks;

namespace FreiplatzApp.ViewModels
{
    class ManageProfileModel: ViewModelBase
    {
        public LocationEntry Location { get; set; }
        public ManageProfileModel()
        {
            Location = new LocationEntry();
        }
    }
}
