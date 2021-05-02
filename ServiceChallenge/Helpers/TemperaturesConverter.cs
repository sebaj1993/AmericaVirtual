using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceChallenge.Helpers
{
    public static class TemperaturesConverter
    {
        public static Double ConvertCelciusToFarenheit(Double celcius)
        {
            return (celcius * 9 / 5) + 32;
        }
    }
}