using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FreiplatzApp.Models
{
    public static class Enums
    {


        //Paragraphs from SGB 8 (Sozailgesetzbuch 8)
        //19 = "Gemeinsame Wohnformen für Mütter/Väter und KInder" ,
        // 27 = "Hilfe zur Erziehung",
        // 28 = "Erziehungsberatung",
        // 29 = "Soziale Gruppenarbeit",
        // 34 = "Heimerziehung, sonstige betreute Wohnform", 
        // 41 = "Hilfe für junge Volljährige"

        public enum Paragraphs
        {
            [Description("Mutter / Vater / Kind")]
            MUTTER_VATER_KIND = 19,
            [Description("Heimerziehung")]
            HEIMERZIEHUNG = 34
        }

        //Art des Trägers
        public enum TypeOfCarrier
        {
            [Description("Alle")]
            ALL,
            [Description("Staatlich")]
            STATE_OWNED,
            [Description("Religiös")]
            RELIGIOUS
        }

   
        public static string GetDescription(this Enum en)
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
