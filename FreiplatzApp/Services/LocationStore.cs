using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FreiplatzApp.Services
{
    class LocationStore : StoreBase<LocationStore, LocationEntry>
    {
        public LocationEntry getRandomEntry(CarrierEntry carrierEntry)
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = GenerateSeededGuid().ToString();
            locationEntry.HousingName = RandomString(5);
            locationEntry.Description = RandomString(50);
            locationEntry.MinAge = random.Next(1, 10);
            locationEntry.MaxAge = random.Next(11, 18);

            //random paragraph
            Array values = Enum.GetValues(typeof(Enums.Paragraphs));
            Enums.Paragraphs randomParagraph = (Enums.Paragraphs)values.GetValue(random.Next(values.Length));
            locationEntry.Paragraphs.Add(randomParagraph);

            locationEntry.Space = random.Next(1, 6);
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.Street = RandomString(15) + " " + "23";
            locationEntry.PostalNumber = locationEntry.PostalEntry.Code;
            locationEntry.ContactPerson = RandomString(15);
            locationEntry.TelephoneNumber = "01548408468";
            locationEntry.Website = RandomString(30);
            locationEntry.EMail = RandomString(15);
            locationEntry.Carrierentry = carrierEntry; //hier ist Verbindung zum Carrier


            return locationEntry;
        }


        public async Task<IEnumerable<LocationEntry>> GetItemsAsyncSearch(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return await Task.FromResult(entries);
            searchText = searchText.ToLower();
            return await Task.FromResult(entries.Where(p => p.IsInSearch(searchText)));
        }

        public LocationEntry getExampleLocationOne(CarrierEntry carrierEntry)
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = "1";
            locationEntry.HousingName = "Kriseneinrichtung KIWI";
            locationEntry.Description = "Die Elternaktivierende Wohngruppe nach § 34 SGB VIII dient der befristeten Unterbringung von Kindern im Alter von null bis sechs Jahren in Krisensituationen. Dabei wird gleichzeitig Krisenclearing mit intensiver Elternarbeit zur Einschätzung der Gefährdungslage des Kindes/der Kinder, ggf. auch aufsuchend im elterlichen Umfeld durchgeführt.";
            locationEntry.MinAge = 12;
            locationEntry.MaxAge = 17;
            locationEntry.Paragraphs.Add(Enums.Paragraphs.CHILD_PROTECTION_AND_CLEARING);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.CRISIS_FACILITY_ANDEMERGENCY_SERVICE);
            locationEntry.Space = 2;
            locationEntry.Street = "Neue Str.2";
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.PostalEntry.District = "Karow";
            locationEntry.PostalEntry.Code = 13125;
            locationEntry.PostalNumber = locationEntry.PostalEntry.Code;
            locationEntry.ContactPerson = "Frau Martinez";
            locationEntry.TelephoneNumber = "030 20215080";
            locationEntry.Website = "www.kjhv-bb.de/hilfsangebote/elternaktivierende-kurzzeitunterbringung";
            locationEntry.EMail = "e.wiesenthal@kjhv.de";
            locationEntry.Carrierentry = carrierEntry; //hier ist Verbindung zum Carrier
            return locationEntry;
        }
        public LocationEntry getExampleLocationTwo(CarrierEntry carrierEntry)
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = "2";
            locationEntry.HousingName = "2-er BEW in Berlin Mitte, Gesundbrunnen";
            locationEntry.Description = "Unbegleitete minderjährige Flüchtlinge, Verselbstständigung. Nur Jungen und Männer";
            locationEntry.MinAge = 15;
            locationEntry.MaxAge = 21;
            locationEntry.Paragraphs.Add(Enums.Paragraphs.CHILD_PROTECTION_AND_CLEARING);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.EDUCATIONAL_ASSISTANCE_AND_CAREGIVER);
            locationEntry.Space = 1;
            locationEntry.Street = "Breite Str.16";
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.PostalEntry.Code = 10245;
            locationEntry.PostalNumber = locationEntry.PostalEntry.Code;
            locationEntry.ContactPerson = "Frau Grunert";
            locationEntry.TelephoneNumber = "030 39404830";
            locationEntry.Website = "www.kjhv-bb.de/hilfsangebote/begleiteter-umgang";
            locationEntry.EMail = "h.vierck@kjhv.de";
            locationEntry.Carrierentry = carrierEntry; //hier ist Verbindung zum Carrier
            return locationEntry;
        }
        public LocationEntry getExampleLocationThree(CarrierEntry carrierEntry)
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = "3";
            locationEntry.HousingName = "Gemeinsame Wohnform für Mütter/Väter und Kinder";
            locationEntry.Description = "Alleinerziehend, Bezugsbetreuersystem, Frühförderung, Interkultureller Ansatz, Individuelle Förderung, Mutter / Vater-Kind, Stärkung Erziehungskompetenz. Nur Familien. Aufnahme von Geschwistern möglich. ";
            locationEntry.MinAge = 0;
            locationEntry.MaxAge = 6;
            locationEntry.Paragraphs.Add(Enums.Paragraphs.FAMILY_HELP);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.FATHER_MOTHER_CHILD_FACILITY);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.SOCIAL_PEDAGOGUE_ACCOMPANIED_HOUSING);
            locationEntry.Space = 3;
            locationEntry.Street = "Lange Str.20";
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.PostalEntry.Code = 10119;
            locationEntry.PostalNumber = locationEntry.PostalEntry.Code;
            locationEntry.ContactPerson = "Frau Grunert";
            locationEntry.TelephoneNumber = "030 4174960";
            locationEntry.Website = "www.kjhv-bb.de/hilfsangebote/aufsuchende-familienunterbringung";
            locationEntry.EMail = "s.koch-dames@kjhv.de";
            locationEntry.Carrierentry = carrierEntry; //hier ist Verbindung zum Carrier
            return locationEntry;
        }
        public LocationEntry getExampleLocationFour(CarrierEntry carrierEntry)
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = "4";
            locationEntry.HousingName = "Kinderwohngruppe Eisbären";
            locationEntry.Description = "Begleitende Elternarbeit, Familientherapie, Intensivgruppe / Intensivwohnform, Individuelle Förderung, Kinderschutz / Kindeswohlgefährdung, Mutter- / Vater-Kindbindung, Stärkung Erziehungskompetenz, Verhaltensauffälligkeit. Gemischt, keine Einschränkungen.";
            locationEntry.MinAge = 4;
            locationEntry.MaxAge = 18;
            locationEntry.Paragraphs.Add(Enums.Paragraphs.FULL_TIME_CARE_AND_FOSTER_FAMILY);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.HOUSEHOLD_ORGANIZATION_TRAINING);
            locationEntry.Space = 1;
            locationEntry.Street = "Dunckerstr.64";
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.PostalEntry.Code = 10439;
            locationEntry.PostalEntry.District = "Prenzlauer Berg";
            locationEntry.PostalNumber = locationEntry.PostalEntry.Code;
            locationEntry.ContactPerson = "Frau Martinez";
            locationEntry.TelephoneNumber = "030 61390718";
            locationEntry.Website = "www.kjhv-bb.de/hilfsangebote/erziehungsbeistand";
            locationEntry.EMail = "n.engelmann@kjhv.de";
            locationEntry.Carrierentry = carrierEntry; //hier ist Verbindung zum Carrier
            return locationEntry;
        }
    }
}
