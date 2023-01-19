using Newtonsoft.Json;
using DataModels;
using System.Configuration;
using System.Reflection;

namespace LocationHelpers
{
    public class LocationHelper
    {
        public static string GetDayNumberSuffix(DateTime date)

        {
            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static string GetWeatherClass(string weatherDesc)
        {
            switch (weatherDesc)
            {
                case "01":
                    return "clear-sky-card";
                case "02":
                    return "few-clouds-card";
                case "03":
                    return "scattered-clouds-card";
                case "04":
                    return "broken-clouds-card";
                case "09":
                    return "shower-rain-card";
                case "10":
                    return "rain-card";
                case "11":
                    return "thunderstorm-card";
                case "13":
                    return "snow-card";
                case "50":
                    return "mist-card";
                default: return "";
            }
        }

        async public static Task<OpenWeatherAPIObject> GetOpenWeatherAPIObject(string searchQuery, string apiKey)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/forecast?q=" + searchQuery + "&units=metric&appid=" + apiKey);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OpenWeatherAPIObject>(jsonString);

            }
            else
            {
                return null;
            }

        }
    }
}