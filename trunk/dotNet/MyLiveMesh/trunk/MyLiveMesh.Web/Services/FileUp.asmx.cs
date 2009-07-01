﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Diagnostics;

namespace MyLiveMesh.Web.Services
{
    /// <summary>
    /// Description résumée de FileUp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class FileUp : System.Web.Services.WebService
    {

        [WebMethod]
        public string Upload(string mode, string path, string name, string filedata, bool overwrite)
        {
            string filename = string.Empty;
            try
            {
                filename = Server.MapPath("~") + @"\" + path.Replace("/", @"\") + name;
                if (File.Exists(filename) == false)
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                if (mode == "new")
                {
                    if (overwrite)
                        File.Delete(filename);
                    else
                        return "File Already Exists";
                    Debug.WriteLine("Writing file: " + filename);
                    WriteFile(filename, Convert.FromBase64String(filedata), FileMode.Create);
                }
                else
                    WriteFile(filename, Convert.FromBase64String(filedata), FileMode.Append);
            }
            catch (Exception ex)
            {
                File.Delete(filename);
                return "File Write Error: " + ex.Message;
            }
            return "ok";
        }
        
        private void WriteFile(string filename, byte[] content, FileMode fileMode)
        {
            Stream target = null;
            BinaryWriter writer = null;
            try
            {
                target = File.Open(filename, fileMode);
                writer = new BinaryWriter(target);
                writer.Write(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not write to file: " + filename + " - " + ex.Message);
            }
            finally
            {
                if (target != null)
                {
                    target.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
