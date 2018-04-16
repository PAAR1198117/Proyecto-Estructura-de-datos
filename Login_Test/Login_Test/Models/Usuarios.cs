using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Login_Test.Models
{
    public partial class Usuarios
    {
        [JsonProperty("Edad")]
        public int Edad { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }

    public partial class Usuarios
    {
        public static Usuarios FromJson(string json) => JsonConvert.DeserializeObject<Usuarios>(json, Login_Test.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Usuarios self) => JsonConvert.SerializeObject(self, Login_Test.Models.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}