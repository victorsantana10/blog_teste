using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Test_Minuto_Seguro.Model;

namespace Test_Minuto_Seguro.Services
{
    public static class ReadXml
    {
        public static BlogMinutoXml GetObjectByXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BlogMinutoXml));
            var reader = new StreamReader("feed.xml");
            var result = (BlogMinutoXml)serializer.Deserialize(reader);
            result.OrderByLastListFeeds();
            return result;
        }
    }
}
