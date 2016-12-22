using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFwebHttpBinding
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IwebHttpBinding
    {
        public DataTable GetData()
        {

            DataTable dtAirline = AirlineDAL.AirDAL.getAirlineDetails();
            return dtAirline;

        }
        public void CreateData(AirlineBO.AirBO air)
        {
            AirlineDAL.AirDAL.createAirlineDetails(air);
        }
        
        public void DeleteData(int id)
        {
            AirlineDAL.AirDAL.deleteAirlineDetails(id);
        }
        
        public void UpdateData(AirlineBO.AirBO air)
        {
            AirlineDAL.AirDAL.updateAirlineDetails(air);
        }

        public DataTable GetClass()
        {
            return AirlineDAL.AirDAL.getClassDetails();
        }

        public string GetString()
        {
            return "Rakesh";
        }
    }
}
