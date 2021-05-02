using ServiceChallenge.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceChallenge.Contracts
{
    [DataContract]
    public class WeekForecastContract
    {
        [DataMember]
        Collection<DayForecastSimpleContract> WeatherDaySimpleContracts;

        public WeekForecastContract(dynamic json)
        {
            WeatherDaySimpleContracts = new Collection<DayForecastSimpleContract>();
            int i = 0;
            foreach(object dayForecastJson in json.list)
            {
                if(i > 0)
                {
                    string day = DateTime.Now.AddDays(i).Date.ToString("dddd", new CultureInfo("es-ES"));
                    string icon = json.list[i]["weather"][0]["icon"];
                    Double temperatureInCelcius = (Double)json.list[i]["temp"]["day"];
                    Double temperatureInFarenheit = TemperaturesConverter.ConvertCelciusToFarenheit(temperatureInCelcius);
                    WeatherDaySimpleContracts.Add(new DayForecastSimpleContract(day, icon, temperatureInCelcius, temperatureInFarenheit));
                }
                i++;
            }

        }
    }
}