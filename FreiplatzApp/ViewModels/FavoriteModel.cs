using FreiplatzApp.Helper;
using FreiplatzApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreiplatzApp.ViewModels
{
    public class FavoriteModel : ViewModelBase
    {
        public FavoriteModel() { }
        public FavoriteModel(LocationEntry location)
        {
            Location = location;
        }

        public LocationEntry Location { get; set; }

        
    }
}
