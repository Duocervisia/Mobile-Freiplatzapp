using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FreiplatzApp.Models
{
    public class PostalEntry : ModelBase
    {
        public PostalEntry()
        {
            State = "Berlin";
        }


        private int _code;

        [JsonProperty(PropertyName = "PLZ")]
        public int Code {
            get => _code;
            set{
                _code = value;
                Id = Convert.ToString(value);
            }
        }
        [JsonProperty(PropertyName = "Stadtteil")]

        public string District { get; set; }
        public string State { get; set; }

        public bool IsInSearch(string searchText)
        {
            if (District.ToLower().Contains(searchText) || Code.ToString().Contains(searchText))
                return true;
            return false;
        }
    }
}
