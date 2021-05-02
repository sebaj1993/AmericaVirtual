using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using ServiceChallenge.Helpers;
using ServiceChallenge.Contracts;

namespace ServiceChallenge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceWeather : IServiceWeather
    {
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/

        public WeekForecastContract WeekForecastForCity(int idCity)
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast/daily?id={idCity.ToString()}&cnt=6&appid=e4f18bdc7ad126886707758d185a9ed4&lang=sp&units=metric";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return null;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();

                        var serializer = new JavaScriptSerializer();
                        serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

                        dynamic obj = serializer.Deserialize(responseBody, typeof(object));
                        return new WeekForecastContract(obj);
                    }
                }
            }
        }

        public DayForecastCompleteContract DayForecastForCity(int idCity)
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast/daily?id={idCity.ToString()}&cnt=1&appid=e4f18bdc7ad126886707758d185a9ed4&lang=sp&units=metric";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return null;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();

                        var serializer = new JavaScriptSerializer();
                        serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

                        dynamic obj = serializer.Deserialize(responseBody, typeof(object));
                        return DayForecastCompleteContract.GetDayForecastCompleteFromJson(obj);
                    }
                }
            }
        }
    }
}
