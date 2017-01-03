using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherCityApp.Model.Entities;

namespace WeatherCityApp.Model.Services
{
    public class RestService
    {

        private static HttpClient client;

        public static HttpClient Client => client ?? (client = new HttpClient());

        protected string BaseUrlWeather { get; set; } = "http://api.openweathermap.org/data/2.5/weather?q={CityName},{CountryCode}&appid=a81173bfc08ea4aaa85721c2b4541953&lang=en&units=metric";

        protected string BaseUrlCountrie { get; set; } = "https://restcountries.eu/rest/v1/capital/";

        public ObservableCollection<CityWeather> Materials { get; private set; }

        public RestService()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<City> GetCityInfoAsync(string cityName)
        {
            var city = new City();
            var completeUrl = BaseUrlCountrie + cityName;

            var response = await Client.GetAsync(completeUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(content))
                {
                    JArray o = JArray.Parse(content);

                    city.Name = o[0]["capital"].ToString();
                    city.Country = o[0]["name"].ToString();
                    city.CountryCode = o[0]["alpha2Code"].ToString();
                }
            }
            return city;

        }

        public async Task<CityWeather> GetCityWeatherInfoAsync(City city)
        {
            var cityWeather = new CityWeather();
            var Url = BaseUrlWeather.Replace("{CityName}", city.Name).Replace("{CountryCode}", city.CountryCode ?? "");

            var response = await Client.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(content))
                {
                    JObject o = JObject.Parse(content);

                    cityWeather.CityName = o["name"].ToString();
                    cityWeather.CityCountry = o["sys"]["country"].ToString();
                    cityWeather.Weather = o["weather"][0]["description"].ToString();
                    cityWeather.Temp = o["main"]["temp"].ToString() + " " + Convert.ToChar(186);
                    cityWeather.TempMin = o["main"]["temp_min"].ToString() + " " + Convert.ToChar(186);
                    cityWeather.TempMax = o["main"]["temp_max"].ToString() + " " + Convert.ToChar(186);
                    cityWeather.Pressure = o["main"]["pressure"].ToString();
                    cityWeather.Humidity = o["main"]["humidity"].ToString();
                    cityWeather.WindSpeed = o["wind"]["speed"].ToString();
                    cityWeather.WindDirection = o["wind"]["deg"].ToString() + " " + Convert.ToChar(186);
                }
            }
            return cityWeather;

        }

    }


}

