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
            [Description("§ 8a Schutzauftrag bei Kindeswohlgefährdung")]
            CHILD_PROTECTION_AND_CLEARING,
            [Description("§ 13.1 Jugendsozialarbeit / sozialpädagogische Hilfen")]
            YOUTH_SOCIAL_WORK_AND_SOCIO_EDUCATIONAL_AIDS,
            [Description("§ 13.2 Ausbildungs- / Beschäftigungsmaßnahme")]
            TRAINING_AND_EMPLOYMENT_MEARURE,
            [Description("§ 13.3 Sozialpäd. begleitete Wohnform")]
            SOCIAL_PEDAGOGUE_ACCOMPANIED_HOUSING,
            [Description("§ 16 Familienbildung")]
            FAMILY_EDUCATION,
            [Description("§ 18.3 Begleiteter Umgang")]
            ACCOMPANIED_HANDLING,
            [Description("§ 19 Väter- / Mütter-Kind-Einrichtung")]
            FATHER_MOTHER_CHILD_FACILITY,
            [Description("§ 20 Betreuung, Versorgung des Kindes in Notsituation")]
            CARE_OF_CHILD_IN_EMERGENCY,
            [Description("§ 27.2 Familienrat")]
            FAMILY_COUNSELING,
            [Description("§ 27.2 Haushalts-Organisations-Training (HOT)")]
            HOUSEHOLD_ORGANIZATION_TRAINING,
            [Description("§ 27.2 Hilfen zur Erziehung")]
            EDUCATION_AIDS,
            [Description("§ 27.2 indiv. stationäre Familienhilfe")]
            INDIVIDUAL_INPATIENT_FAMILY_HELP,
            [Description("§ 27.3 Therapeutische Leistung")]
            THERAPEUTIC_SERVICE,
            [Description("§ 28 Erziehungsberatung")]
            EDUCATIONAL_EDVICE,
            [Description("§ 29 Soziale Gruppenarbeit")]
            SOCIAL_GROUP_WORK,
            [Description("§ 30 Erziehungsbeistand / Betreuungshelfer")]
            EDUCATIONAL_ASSISTANCE_AND_CAREGIVER,
            [Description("§ 31 Familienhilfe")]
            FAMILY_HELP,
            [Description("§ 32 Tagesgruppe")]
            DAY_GROUP,
            [Description("§ 32 / 35a Förderschule")]
            SPECIAL_SCHOOL,
            [Description("§ 33 Vollzeitpflege / Pflegefamilie")]
            FULL_TIME_CARE_AND_FOSTER_FAMILY,
            [Description("§ 34 (§ 34 )Erziehungswohngruppe")]
            EDUCATIONAL_LIVING_GROUP,
            [Description("§ 35 Intensive Sozialpädagogische Einzelbetreuung (ISE)")]
            INTENSIVE_SOCIAL_PEDAGOGICAL_INDIVIDUAL_SUPPORT,
            [Description("§ 35a Ambulante Eingliederungshilfe")]
            OUTPATIENT_INTEGRATION_ASSISTANCE,
            [Description("§ 35a Stationäre Eingliederungshilfe")]
            INPATIENT_INTEGRATION_ASSISTANCE,
            [Description("§ 35a Teilstationäre Eingliederungshilfe")]
            PARTIAL_INPATIENT_INTEGRATION_ASSISTANCE,
            [Description("§ 35a Therapeutische Leistung")]
            THERAPEUTICAL_SERVICE,
            [Description("§ 41 Hilfe für junge Volljährige")]
            HELP_FOR_YOUNG_ADULTS,
            [Description("§ 42 Inobhutnahme / Kriseneinrichtung / Notdienst")]
            CRISIS_FACILITY_ANDEMERGENCY_SERVICE,
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
