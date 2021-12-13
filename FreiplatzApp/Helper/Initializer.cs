using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Services;
using FreiplatzApp.Views;

namespace FreiplatzApp.Helper
{
    class Initializer
    {
       public static async void init()
       {
            await PostalCodeStore.GetInstance().init();
            CarrierStore.GetInstance().init();
        }
    }
}
