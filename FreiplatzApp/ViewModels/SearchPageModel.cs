using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using Xamarin.Forms;

namespace FreiplatzApp.ViewModels
{
    class SearchPageModel
    {
        public IDataStore<PostalEntry> DataStore => DependencyService.Get<IDataStore<PostalEntry>>();

        public SearchPageModel()
        {
            DataStore.init();
        }
    }
}
