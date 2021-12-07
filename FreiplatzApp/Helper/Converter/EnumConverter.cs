using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

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
                        lO.Add(GetDescription((Enum)item));
                    }
                }
                return lO;
            }

            return GetDescription((Enum)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
}
