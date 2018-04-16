using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Login_Test.Models
{ 
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using Lab2_reposicion;
    //
    //    var pelicula = Pelicula.FromJson(jsonString);
    public partial class Pelicula
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Tipo")]
        public string Tipo { get; set; }

        [JsonProperty("Año")]
        public long Año { get; set; }

        [JsonProperty("Genero")]
        public string Genero { get; set; }
    }

    public partial class Pelicula
    {
        public static Dictionary<string, Pelicula> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, Pelicula>>(json, Login_Test.Models.Converter.Settings);
    }

    public static class Serialize1
    {
        public static string ToJson(this Dictionary<string, Pelicula> self) => JsonConvert.SerializeObject(self, Login_Test.Models.Converter.Settings);
    }

    internal class Converter1
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