/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:21:53
** 描述：field(field)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
	[Serializable]
    public class Field
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public Field()
        {
            Id = Int32.MinValue;
            QueryId = String.Empty;
            FieldCode = String.Empty;
            FieldName = String.Empty;
            IsKey = Int32.MinValue;
            IsSelitem = Int32.MinValue;
            IsShow = Int32.MinValue;
            Width = String.Empty;
            Href = String.Empty;
            DataType = String.Empty;
            Formatter = String.Empty;
        }
        
        #endregion
        
        #region 字段
        
        [Display(Name = "自增ID")]
        /// <summary>
        /// 自增ID 
        /// </summary>
        public int Id { get; set; } 
        
        [Display(Name = "序列唯一标识")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 序列唯一标识 
        /// </summary>
        public string QueryId { get; set; } 
        
        [Display(Name = "字段名")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字段名 
        /// </summary>
        public string FieldCode { get; set; } 
        
        [Display(Name = "字段名称")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字段名称 
        /// </summary>
        public string FieldName { get; set; } 
        
        [Display(Name = "是否主键")]
        /// <summary>
        /// 是否主键 
        /// </summary>
        public int IsKey { get; set; } 
        
        [Display(Name = "是否可选")]
        /// <summary>
        /// 是否可选 
        /// </summary>
        public int IsSelitem { get; set; } 
        
        [Display(Name = "是否显示")]
        /// <summary>
        /// 是否显示 
        /// </summary>
        public int IsShow { get; set; } 
        
        [Display(Name = "字段宽")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 字段宽 
        /// </summary>
        public string Width { get; set; } 
        
        [Display(Name = "路径")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 路径 
        /// </summary>
        public string Href { get; set; } 
        
        [Display(Name = "数据类型")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 数据类型 
        /// </summary>
        public string DataType { get; set; } 
        
        [Display(Name = "格式设置")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 格式设置 
        /// </summary>
        public string Formatter { get; set; } 
        
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
                case "QUERYID":
                	value = QueryId;
                    break;
                case "FIELDCODE":
                	value = FieldCode;
                    break;
                case "FIELDNAME":
                	value = FieldName;
                    break;
                case "ISKEY":
                	value = IsKey;
                    break;
                case "ISSELITEM":
                	value = IsSelitem;
                    break;
                case "ISSHOW":
                	value = IsShow;
                    break;
                case "WIDTH":
                	value = Width;
                    break;
                case "HREF":
                	value = Href;
                    break;
                case "DATATYPE":
                	value = DataType;
                    break;
                case "FORMATTER":
                	value = Formatter;
                    break;
            }
            
            return value;
        }
   	}
}
