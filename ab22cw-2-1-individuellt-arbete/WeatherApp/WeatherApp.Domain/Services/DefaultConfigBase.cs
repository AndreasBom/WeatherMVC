using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Services
{
    public abstract class DefaultConfigBase : IDefaultConfig
    {
        public abstract string GetDefaultLocation();

        public abstract void SetDefaultLocation(string location);
    }
}
