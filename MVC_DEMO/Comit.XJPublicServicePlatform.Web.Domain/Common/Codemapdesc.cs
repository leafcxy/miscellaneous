/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
	[Serializable]
    public class Codemapdesc
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public Codemapdesc()
        {
            CodemapdescId = Int32.MinValue;
            Id = String.Empty;
            Fieldval = String.Empty;
            Fielddesc = String.Empty;
            StateId = String.Empty;
        }
        
        #endregion
        
        #region 字段
        
        [Display(Name = "自增ID")]
        /// <summary>
        /// 自增ID 
        /// </summary>
        public int CodemapdescId { get; set; } 
        
        [Display(Name = "字典ID")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字典ID 
        /// </summary>
        public string Id { get; set; } 
        
        [Display(Name = "字段值")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字段值 
        /// </summary>
        public string Fieldval { get; set; } 
        
        [Display(Name = "字段说明")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字段说明 
        /// </summary>
        public string Fielddesc { get; set; } 
        
        [Display(Name = "状态ID")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 状态ID 
        /// </summary>
        public string StateId { get; set; } 
        
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
                case "CODEMAPDESCID":
                	value = CodemapdescId;
                    break;
                case "ID":
                	value = Id;
                    break;
                case "FIELDVAL":
                	value = Fieldval;
                    break;
                case "FIELDDESC":
                	value = Fielddesc;
                    break;
                case "STATEID":
                	value = StateId;
                    break;
            }
            
            return value;
        }
   	}
}
