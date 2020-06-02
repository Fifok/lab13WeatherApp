using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab13WeatherApp
{
    public class LocationService
    {
        private Dictionary<string, Point> _cities;

        public LocationService()
        {
            _cities = new Dictionary<string, Point>();

            _cities.Add("Bielsko-Biała", new Point(49.831797, 19.041428));
            _cities.Add("Hel", new Point(54.631342, 18.796442));
        }

        public Point GetLocation(string city)
        {
            if (_cities.ContainsKey(city))
            {
                return _cities[city];
            }
            else
            {
                return default;
            }
        }

        public IEnumerable<string> GetCities()
        {
            foreach (var city in _cities.Keys)
            {
                yield return city;
            }
        }
    }
}
