/******************************************************************************** 
** 作者：余穗海
** 时间：2015-04-01 10:20:46
** 描述：login_record(用户登录记录表;)表的映射(自动生成 )
*********************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
	[Serializable]
    public class LoginRecord
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginRecord()
        {
            Id = Int64.MinValue;
            UserCode = String.Empty;
            LoginTime = new DateTime(1900, 1, 1, 0, 0, 0);
            LoginIp = String.Empty;
        }
        
        #endregion
        
        #region 字段
        
        [Display(Name = "登录ID")]
        /// <summary>
        /// 登录ID 
        /// </summary>
        public long Id { get; set; } 
        
        [Display(Name = "用户名")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserCode { get; set; } 
        
        [Display(Name = "登录时间")]
            /// 设置字段类型验证，如邮箱、电话等
            [DataType(DataType.DateTime)]            	
        /// <summary>
        /// 登录时间 
        /// </summary>
        public DateTime LoginTime { get; set; } 
        
        [Display(Name = "登录用户IP")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 登录用户IP 
        /// </summary>
        public string LoginIp { get; set; } 
        
		#endregion
		
		/// <summary>
        /// 获得指定字段值
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public object GetValue(string field)
        {
            object value = null;

            switch (field.ToUpper())
            {
                case "ID":
                	value = Id;
                    break;
                case "USERCODE":
                	value = UserCode;
                    break;
                case "LOGINTIME":
                	value = LoginTime;
                    break;
                case "LOGINIP":
                	value = LoginIp;
                    break;
            }
            
            return value;
        }
   	}
}
