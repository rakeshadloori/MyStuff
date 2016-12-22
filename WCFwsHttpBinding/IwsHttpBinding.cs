using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFwsHttpBinding
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IwsHttpBinding
    {

        [OperationContract]
        DataTable GetData();

        [OperationContract]
        void CreateData(AirlineBO.AirBO air);

        [OperationContract]
        void UpdateData(AirlineBO.AirBO air);

        [OperationContract]
        void DeleteData(int id);

        [OperationContract]
        DataTable GetClass();
    }
}
