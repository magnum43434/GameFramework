using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Handlers.ConfigFileHelper
{
    public class XmlConfigurations
    {
        public List<XmlHelper> EnemyNamesList { get; set; }

        public XmlConfigurations()
        {
        }

        public struct XmlHelper
        {
            public string Name { get; set; }
        }
    }
}