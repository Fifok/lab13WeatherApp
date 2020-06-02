using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab13WeatherApp
{
    public class WeatherService
    {
        public WeatherResponse GetWeather(Point coord)
        {
            RestClient client = new RestClient("https://api.openweathermap.org/data/2.5");

            var request = new RestRequest("onecall")
                .AddParameter("lat", coord.X)
                .AddParameter("lon", coord.Y)
                .AddParameter("appid", "17ad6d43cd925b3a89bb73a10ac2fb68")
                .AddParameter("exclude", "hourly, minutly")
                .AddParameter("lang", "pl")
                .AddParameter("units", "metric");

            var response = client.Execute<WeatherResponse>(request);
            
            if(response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

    }

    public class WeatherResponse
    {
        public List<DailyForecast> Daily { get; set; }
    }

    public class DailyForecast
    {
        public int Dt { get; set; }
        public List<WeatherDescription> Weather { get; set; }
    }

    public class WeatherDescription
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}


/*  "daily": [
{
  "dt": 1590487200,
  "sunrise": 1590461589,
  "sunset": 1590518240,
  "temp": {
    "day": 11.84,
    "min": 6.96,
    "max": 13.92,
    "night": 6.96,
    "eve": 13.92,
    "morn": 11.84
  },
  "feels_like": {
    "day": 9.91,
    "night": 4.74,
    "eve": 9.78,
    "morn": 9.91
  },
  "pressure": 1029,
  "humidity": 88,
  "dew_point": 9.92,
  "wind_speed": 2.79,
  "wind_deg": 333,
  "weather": [
    {
      "id": 500,
      "main": "Rain",
      "description": "słabe opady deszczu",
      "icon": "10d"
    }
  ],
  "clouds": 89,
  "rain": 0.63,
  "uvi": 6.03
},*/
