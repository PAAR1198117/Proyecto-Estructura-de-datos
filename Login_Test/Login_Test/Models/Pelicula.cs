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
    //
    //    var pelicula = Pelicula.FromJson(jsonString);
    public partial class Pelicula :IComparable
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Tipo")]
        public string Tipo { get; set; }

        [JsonProperty("Año")]
        public long Año { get; set; }

        [JsonProperty("Genero")]
        public String Genero { get; set; }

        public int CompareTo(object obj)
        {
            Pelicula compareToObj = (Pelicula)obj;
            if(obj.GetType() == typeof(string))
                return this.Nombre.CompareTo(compareToObj.Nombre);
            if (obj.GetType() == typeof(long))
                return this.Año.CompareTo(compareToObj.Año);
            else
                return this.Genero.CompareTo(compareToObj.Genero);
        }

    }
    public class peliculas : IComparable
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public long Año { get; set; }
        public String Genero { get; set; }
        public int ordenar = 0;
        public peliculas(string Nombre, string Tipo, long Año, String Genero, int ordenar)
        {
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.Año = Año;
            this.Genero = Genero;
            this.ordenar = ordenar;
        }
        public int CompareTo(object obj)
        {
            Pelicula compareToObj = (Pelicula)obj;
            if (ordenar==0)
                return this.Nombre.CompareTo(compareToObj.Nombre);
            if (ordenar==1)
                return this.Año.CompareTo(compareToObj.Año);
            else
                return this.Genero.CompareTo(compareToObj.Genero);
        }
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