using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Threading;
using FreiplatzApp.Models;
using Newtonsoft.Json;

namespace FreiplatzApp.Helper
{
    class LocalStorage
    {
        //stolen from: https://stackoverflow.com/questions/39470162/persistent-storage-using-application-current-properties-not-working
        #region Instance

        private static Lazy<ISettings> _appSettings;

        public static ISettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = new Lazy<ISettings>(() => CrossSettings.Current, LazyThreadSafetyMode.PublicationOnly);
                }

                return _appSettings.Value;
            }
            set
            {
                _appSettings = new Lazy<ISettings>(() => value, LazyThreadSafetyMode.PublicationOnly);
            }
        }

        #endregion

        private static readonly string LocalLocationsDefault = "[]"; 
        private const string favoriteLocationIdsKey = "favoriteLocationIds"; 
        public static List<string> favoriteLocationIds
        {
            get
            {
                string json = AppSettings.GetValueOrDefault(favoriteLocationIdsKey, LocalLocationsDefault);
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
            set {
                AppSettings.AddOrUpdateValue(favoriteLocationIdsKey, JsonConvert.SerializeObject(value)); 
            }
        }

        public static void removeAll()
        {
            AppSettings.Remove(favoriteLocationIdsKey);
        }
    }
}
