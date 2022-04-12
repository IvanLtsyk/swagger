using System;
using WebApiCore.Data.Domain;

namespace WebApiCore.Data.Models
{
    public class CurrentWeather : IdentifibleEntityIntBase
    {
        public string Status { get; set; }
        public float Temp { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }
    }
}
