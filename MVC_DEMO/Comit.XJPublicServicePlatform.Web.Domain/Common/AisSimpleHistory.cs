using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    public class AisSimpleHistory
    {
        public double Cog{ get; set; }
        public double Sog{ get; set; }
        public double Lat{ get; set; }
        public double Lng{ get; set; }
        public string ShipId { get; set; }
        public DateTime LastTime { get; set; }
    }
}