using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStationWebAPI.Models
{
    // Vi skal nok lave "Sted" (Place) som sin egen entitet, og så lave many-to-one relationship mellem Place og WeatherObservation

    public class WeatherObservation
    {
        public long ID { get; set; }
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public  int Humidity { get; set; }
        public float Pressure { get; set; }

    }
}
