using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioRebel.CLASES;

namespace WCFServicioRebel
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
    public class Servicio : IServicio
    {
        List<Rebel> LRebels = new List<Rebel>();
        private readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string registerRebel(string name, string planet)
        {
            string mensaje = "";
            Rebel obj = new Rebel();
            if (!NotRepeat(name,planet))
            {
                Log.Info("The rebeld isn't repeat!");
                obj.name = name;
                obj.planet = planet;
                LRebels.Add(obj);
                obj.GrabarArchivo(LRebels);
                mensaje = "Rebel save correctly";
            }
            else
            {
                mensaje = "Rebel doesn't save correctly";
            }
            return mensaje;
        }

        private bool NotRepeat(string name, string planet)
        {
            bool resp = false;
            for(int i = 0; i < LRebels.Count; i++)
            {
                if(LRebels[i].name == name && LRebels[i].planet == planet)
                {
                    resp = true;
                    Log.Info("The rebeld is repeat!");
                }
            }
            return resp;
        }
    }
}
