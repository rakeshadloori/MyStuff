using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceIntro
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IWeatherData
    {
        int i = 1;
        public string GetWeatherData(string value)
        {
            string output = "";
            i++;
            switch (value.ToLower())
            {
                case "lincoln":
                    output = "Max temp: 5 , Min temp: -12 " + i;
                    break;
                case "omaha":
                    output = "Max temp: 2, Min temp: -15 " + i;
                    break;
                case "texas":
                    output = "Max temp: 22, Min temp: 15 " + i;
                    break;
                case "california":
                    output = "Max temp: 18, Min temp: 10 " + i;
                    break;
                case "florida":
                    output = "Max temp: 20, Min temp: 12 " + i;
                    break;
                default:
                    output = "No data found for the specified location  " + i;
                    break;
            }
            return output;
        }
    }
}
