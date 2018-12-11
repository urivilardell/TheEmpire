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
            string message = "";
            Log.Debug("In function registerRebel");
            try
            {
                
                Rebel obj = new Rebel();
                if (!notRepeat(name, planet))
                {
                    Log.Info("The rebeld isn't repeat!");
                    obj.name = name;
                    obj.planet = planet;
                    LRebels.Add(obj);

                    if (obj.SaveFile(LRebels))
                    {
                        message = "Rebel save correctly";
                    }
                    else
                    {
                        message = "Error. Can't to save the Rebel";
                    }
                     
                }
                else
                {
                    message = "The rebel is repeat";
                }
            }
            catch(Exception exp)
            {
                Log.Error("Can't register the rebel correctly", exp);
                message = "Error: "+exp.ToString();
            }
            
            return message;
        }

        private bool notRepeat(string name, string planet)
        {
            bool resp = false;
            Log.Debug("In function NotRepeat");
            try
            {
                foreach (Rebel reb in LRebels)
                {
                    if (reb.name == name && reb.planet == planet)
                    {
                        resp = true;
                        Log.Info("The rebeld is repeat!");
                    }
                }
            }
            catch(Exception exp)
            {
                Log.Error("Error Function NotRepeat", exp);
            }
           
            return resp;
        }
    }
}
