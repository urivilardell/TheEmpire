using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServicioRebel
{
    
    [ServiceContract]
    public interface IServicio
    {
        [OperationContract]
        string registerRebel(string name, string planet);
    }
}
