using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceChallenge.Contracts
{
    [DataContract]
    public class DayForecastSimpleContract
    {
        [DataMember]
        protected string Day;
        [DataMember]
        protected string Icon;
        [DataMember]
        protected Double TemperatureInCelcius;
        [DataMember]
        protected Double TemperatureInFarenheit;

        public DayForecastSimpleContract(string day, string icon, Double temperatureInCelcius, Double temperatureInFarenheit)
        {
            Day = day;
            Icon = icon;
            TemperatureInCelcius = temperatureInCelcius;
            TemperatureInFarenheit = temperatureInFarenheit;
        }
    }
}