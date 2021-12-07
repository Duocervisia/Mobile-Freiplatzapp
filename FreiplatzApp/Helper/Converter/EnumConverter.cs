using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using FreiplatzApp.Models;

namespace FreiplatzApp.Helper.Converter
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            Type type = value.GetType();
            bool isList = type != null
                       && type.IsGenericType
                       && type.GetGenericTypeDefinition() == typeof(List<>);
            
            if (isList)
            {
                List<object> lO = new List<object>();

                IEnumerable enumerable = value as IEnumerable;

                if (enumerable != null)
                {
                    foreach (object item in enumerable)
                    {
                        
                        lO.Add(Enums.GetDescription((Enum)item));
                    }
                }
                return lO;
            }

            return Enums.GetDescription((Enum)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
