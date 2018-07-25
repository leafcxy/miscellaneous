/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:20
** 描述：ship_enclosure_info(船舶所处围栏信息)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
	[Serializable]
    public class ShipEnclosureInfo
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public ShipEnclosureInfo()
        {
            Id = Int64.MinValue;
            ShipId = Int32.MinValue;
            EnclosureId = String.Empty;
            AisHistoryId = Int64.MinValue;
            OperatePerson = String.Empty;
            OperateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            OperateType = String.Empty;
            BackUp1 = String.Empty;
            BackUp2 = String.Empty;
            BackUp3 = String.Empty;
            BackUp4 = String.Empty;
            BackUp5 = String.Empty;
        }
        
        #endregion
        
        #region 字段
        
        [Display(Name = "自增编号")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 自增编号 
        /// </summary>
        public long Id { get; set; } 
        
        [Display(Name = "船舶编号")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 船舶编号 
        /// </summary>
        public int ShipId { get; set; } 
        
        [Display(Name = "围栏编号")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 围栏编号 
        /// </summary>
        public string EnclosureId { get; set; } 
        
        [Display(Name = "船舶ais历史id")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 船舶ais历史id 
        /// </summary>
        public long AisHistoryId { get; set; } 
        
        [Display(Name = "操作人")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 操作人 
        /// </summary>
        public string OperatePerson { get; set; } 
        
        [Display(Name = "操作时间")]
          [Required(ErrorMessage="{0}是必填项")]
            /// 设置字段类型验证，如邮箱、电话等
            [DataType(DataType.DateTime)]            	
        /// <summary>
        /// 操作时间 
        /// </summary>
        public DateTime? OperateTime { get; set; } 
        
        [Display(Name = "操作类型")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 操作类型 
        /// </summary>
        public string OperateType { get; set; } 
        
        [Display(Name = "")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        ///  
        /// </summary>
        public string BackUp1 { get; set; } 
        
        [Display(Name = "")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        ///  
        /// </summary>
        public string BackUp2 { get; set; } 
        
        [Display(Name = "")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        ///  
        /// </summary>
        public string BackUp3 { get; set; } 
        
        [Display(Name = "")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        ///  
        /// </summary>
        public string BackUp4 { get; set; } 
        
        [Display(Name = "")]
           [StringLength(4000, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在4000个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        ///  
        /// </summary>
        public string BackUp5 { get; set; } 
        
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
                case "SHIPID":
                	value = ShipId;
                    break;
                case "ENCLOSUREID":
                	value = EnclosureId;
                    break;
                case "AISHISTORYID":
                	value = AisHistoryId;
                    break;
                case "OPERATEPERSON":
                	value = OperatePerson;
                    break;
                case "OPERATETIME":
                	value = OperateTime;
                    break;
                case "OPERATETYPE":
                	value = OperateType;
                    break;
                case "BACKUP1":
                	value = BackUp1;
                    break;
                case "BACKUP2":
                	value = BackUp2;
                    break;
                case "BACKUP3":
                	value = BackUp3;
                    break;
                case "BACKUP4":
                	value = BackUp4;
                    break;
                case "BACKUP5":
                	value = BackUp5;
                    break;
            }
            
            return value;
        }
   	}
}
