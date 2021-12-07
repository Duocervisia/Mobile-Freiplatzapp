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
            MUTTER_VATER_KIND = 19,
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

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
