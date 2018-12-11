using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WCFServicioRebel.CLASES
{
    public class Rebel
    {

        private readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region "PROPIERTIES"
        public string name;
        public string planet;
        #endregion

        #region "FUNCTIONS"
        public bool SaveFile(List<Rebel> LRebels)  //Function to save a new rebel in file.
        {
            bool saveOK = false;
            try
            {
                Log.Debug("In function SaveFile");
                string Line;
                var originProgramFile = AppDomain.CurrentDomain.BaseDirectory; //program's origin path
                if (Directory.Exists(originProgramFile))
                {
                    string nameFile = "REGISTERS"; //the folder's name where I save the new rebels
                    string pathFile = Path.Combine(originProgramFile, nameFile);
                    Directory.CreateDirectory(pathFile);
                    if (Directory.Exists(pathFile))
                    {
                        try
                        {
                            Log.Debug("Exist REGISTERS and then start streamwriter object");
                            StreamWriter obj = File.CreateText(pathFile + "\\RegisterRebels.txt"); //the file's name where I save the new rebels
                            foreach (Rebel v in LRebels.ToArray())
                            {
                                Line = "Rebeld " + v.name + " on " + v.planet + " at " + DateTime.Today.ToShortDateString();
                                obj.WriteLine(Line);

                            }
                            obj.Close();
                            Log.Debug("Object closed");
                            obj.Dispose();
                            saveOK = true;
                        }
                        catch(Exception exp)
                        {
                            Log.Error("Can't save the rebel correctly"+ "Error" + exp);
                            saveOK = false;
                        }
                        
                    }
                    else
                    {
                        Log.Error("The program's origin folder path doesn't exist or can't find it");
                        saveOK = false;
                    }
                }
                else
                {
                    Log.Error("The specific folder for save the rebels' name doesn't exist or can't find it");
                    saveOK = false;
                }

            }
            catch(Exception exp)
            {
                Log.Error("There is an error" + exp);
            }
            return saveOK;
        }
        #endregion
    }
}