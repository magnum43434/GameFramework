using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameLibrary.Handlers.ConfigFileHelper
{
    public class XMLReader
    {
        public static T ReadGameConfiguration<T>()
        {
            try
            {
                XmlSerializer xmlszl = new XmlSerializer(typeof(T),
                    new XmlRootAttribute("GameConfig"));
                StreamReader reader = new StreamReader("GameConfig.xml");
                using (reader)
                {
                    var x = (T)xmlszl.Deserialize(reader);
                    return x;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }
    }
}