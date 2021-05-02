using ServiceChallenge.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceChallenge.Contracts
{
    [DataContract]
    public class DayForecastCompleteContract : DayForecastSimpleContract
    {
        [DataMember]
        string DescriptionWeather;
        [DataMember]
        Double ProbabilityOfPrecipitation;
        [DataMember]
        Double Humidity;
        [DataMember]
        Double WindSpeed;

        public DayForecastCompleteContract(string descriptionWeather, Double probabilityOfPrecipitation, Double humidity, Double windSpeed, string day, string icon, Double temperatureInCelcius, Double temperatureInFarenheit)
            :base(day, icon, temperatureInCelcius, temperatureInFarenheit)
        {
            DescriptionWeather = descriptionWeather;
            ProbabilityOfPrecipitation = probabilityOfPrecipitation;
            Humidity = humidity;
            WindSpeed = windSpeed;
        }

        public static DayForecastCompleteContract GetDayForecastCompleteFromJson(dynamic json)
        {
            string descriptionWeather = json.list[0]["weather"][0]["description"];
            Double probabilityOfPrecipitation = (Double)json.list[0]["pop"];
            Double humidity = (Double)json.list[0]["humidity"];
            Double windSpeed = (Double)json.list[0]["speed"];
            //
            string day = DateTime.Now.Date.ToString("dddd", new CultureInfo("es-ES"));
            string icon = json.list[0]["weather"][0]["icon"];
            Double temperatureInCelcius = (Double)json.list[0]["temp"]["day"];
            Double temperatureInFarenheit = TemperaturesConverter.ConvertCelciusToFarenheit(temperatureInCelcius);
            //
            return new DayForecastCompleteContract(descriptionWeather, probabilityOfPrecipitation, humidity, windSpeed, day, icon, temperatureInCelcius, temperatureInFarenheit);
        }
    }
}