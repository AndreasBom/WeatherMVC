using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApp.Domain.Services
{
    public class DefaultConfig : DefaultConfigBase
    {
        /// <summary>
        /// Get and sets a start location
        /// </summary>

        private readonly string _path;

        /// <summary>
        /// provide path to xml-file
        /// </summary>
        /// <param name="path"></param>
        public DefaultConfig(string path)
        {
            _path = path;
        }

        //Read config.xml
        public override string GetDefaultLocation()
        {
            XDocument doc = XDocument.Load(_path);
            var location = (string)(from c in doc.Descendants("startLocation")
                                       select c).FirstOrDefault();

            return location;
        }

        //Write to config.xml
        public override void SetDefaultLocation(string location)
        {
            XDocument doc = XDocument.Load(_path);
            var defaultLocation = (from c in doc.Descendants("config")
                                  select c).FirstOrDefault();

            defaultLocation.SetElementValue("startLocation", location);
            doc.Save(_path);
        }
    }
}
