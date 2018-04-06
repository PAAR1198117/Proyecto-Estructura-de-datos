using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Login_Test.Clases
{
    public class registros
    {

        public void escribirArchivo(string escribe)
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\Pedro\\Desktop\\Test.json");

                //Write a line of text
                sw.WriteLine(escribe);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}