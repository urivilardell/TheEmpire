using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Web;

namespace WCFServicioRebel.CLASES
{
    public class Rebel
    {
        #region "PROPIEDADES"
        public string name;
        public string planet;
        #endregion

        #region "Funciones"
        public void GrabarArchivo(List<Rebel> LRebels)
        {
            StreamWriter obj = File.CreateText(@"C:\Users\ALBA\Desktop\WCFServicioRebel\WCFServicioRebel\REGISTROS\RegistroRebels.txt");
    
            string Linea;
            for (int v = 0; v < LRebels.ToArray().Length; v++)
            {
                Linea = "Rebeld " + LRebels[v].name + " on " + LRebels[v].planet + " at " + DateTime.Today.ToShortDateString();
                obj.WriteLine(Linea);
                
            }
            obj.Close();
        }
        #endregion
    }
}