using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserGO.Utils.DTO.Utils
{
    public enum  ExtendedInput
    {
        SIMPLE,
        ADVANCED
    }

    public class ConfigurationServer
    {
        public ExtendedInput ExtendedInput { get; set; }

    }
}
