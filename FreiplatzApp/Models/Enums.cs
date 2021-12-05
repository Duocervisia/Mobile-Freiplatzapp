using System;
using System.Collections.Generic;
using System.Linq;

public class Enums
{
  

    //Paragraphs from SGB 8 (Sozailgesetzbuch 8)
    //19 = "Gemeinsame Wohnformen f�r M�tter/V�ter und KInder" ,
    // 27 = "Hilfe zur Erziehung",
    // 28 = "Erziehungsberatung",
    // 29 = "Soziale Gruppenarbeit",
    // 34 = "Heimerziehung, sonstige betreute Wohnform", 
    // 41 = "Hilfe f�r junge Vollj�hrige"

    public enum Paragraphs
    {
        MUTTER_VATER_KIND = 19,
        HEIMERZIEHUNG = 34
    }

    //Art des Tr�gers
    public enum TypeOfCarrier
    {
        STATE_OWNED,
        CHRISTIAN,
        MUSLIM
    }
    public enum AvailableSpace
    {
        ALL,
        OCCUPIED,
        UNOCCUPIED
    }
}