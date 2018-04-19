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
    public partial class Usuarios : IComparable
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

        public int CompareTo(object obj)
        {
            Usuarios compareToObj = (Usuarios)obj;
            if (obj.GetType() == typeof(string))
                return this.Username.CompareTo(compareToObj.Username);
            if (obj.GetType() == typeof(long))
                return this.Password.CompareTo(compareToObj.Password);
            else
                return this.Nombre.CompareTo(compareToObj.Nombre);
        }
    }
    public partial class users : IComparable
    {        
        public int Edad { get; set; }        
        public string Nombre { get; set; }        
        public string Apellido { get; set; }       
        public string Username { get; set; }        
        public string Password { get; set; }
        public users(int Edad,string Nombre, string apellido, string username, string password )
        {
            this.Edad = Edad;
            this.Nombre = Nombre;
            this.Apellido = apellido;
            this.Username = username;
            this.Password = password;
        }
        public int CompareTo(object obj)
        {
            users compareToObj = (users)obj;           
                return this.Username.CompareTo(compareToObj.Username);           
        }
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