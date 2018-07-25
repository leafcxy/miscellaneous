using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    public class AisTrailHistory
    {
        public double Lat{ get; set; }
        public double Lng{ get; set; }
        public string ShipId { get; set; }
        public DateTime LastTime { get; set; }
    }
}