using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    [DataContract] 
    public class JQGrilBind
    {
        public JQGrilBind()
        {}
        //filters:{"groupOp":"AND","rules":["field":"Id","op":"eq","data":"123"},{"field":"Id","op":"eq","data":"123"}]}
        [DataMember] 
        public string groupOp{ get;set; }
        [DataMember] 
        public SearchRules[] rules { get; set; }
        
    }
}