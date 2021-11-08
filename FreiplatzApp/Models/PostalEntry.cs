using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FreiplatzApp.Models
{
    class PostalEntry
    {
        public PostalEntry()
        {
            State = "Berlin";
        }

        public string Id { get; set; }

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
    }
}
