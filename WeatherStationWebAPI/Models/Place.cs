using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStationWebAPI.Models
{
    public class Place
    {
        public string Name { get; set; }
        public double Latitude { get; set; }    // gps-coordinates latitude
        public double Longitude { get; set; }   // gps-coordinates longitude
    }
}
