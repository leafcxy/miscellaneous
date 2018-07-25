using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    [DataContract] 
    public class SearchRules
    {
        public SearchRules() { }
        //{"field":"Id","op":"eq","data":"123"}
        [DataMember]  
        public string field{ get; set;}
        [DataMember] 
        public string op{get;set;}
        [DataMember] 
        public string data{get;set;}
    }
}