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
        public CarrierEntry Carrier { get; set; }
        public ManageProfileModel()
        {
            Carrier = new CarrierEntry();
        }
    }
}
