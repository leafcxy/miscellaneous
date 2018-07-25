/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 17:04:57
** 描述：user_role_relate(用户和角色的关系)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Management
{
	[Serializable]
    public class UserRoleRelate
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserRoleRelate()
        {
            Id = Int64.MinValue;
            UserCode = String.Empty;
            RoleId = String.Empty;
            UpdateTime = new DateTime(1900, 1, 1, 0, 0, 0);
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
        
        [Display(Name = "角色编号")]
        /// <summary>
        /// 角色编号 
        /// </summary>
        public long Id { get; set; } 
        
        [Display(Name = "用户标识")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 用户标识 
        /// </summary>
        public string UserCode { get; set; } 
        
        [Display(Name = "角色id")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 角色id 
        /// </summary>
        public string RoleId { get; set; } 
        
        [Display(Name = "更新时间")]
            /// 设置字段类型验证，如邮箱、电话等
            [DataType(DataType.DateTime)]            	
        /// <summary>
        /// 更新时间 
        /// </summary>
        public DateTime UpdateTime { get; set; } 
        
        [Display(Name = "操作人")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 操作人 
        /// </summary>
        public string OperatePerson { get; set; } 
        
        [Display(Name = "操作时间")]
            /// 设置字段类型验证，如邮箱、电话等
            [DataType(DataType.DateTime)]            	
        /// <summary>
        /// 操作时间 
        /// </summary>
        public DateTime OperateTime { get; set; } 
        
        [Display(Name = "操作类型")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 操作类型 
        /// </summary>
        public string OperateType { get; set; } 
        
        [Display(Name = "备用字段1")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 备用字段1 
        /// </summary>
        public string BackUp1 { get; set; } 
        
        [Display(Name = "备用字段2")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 备用字段2 
        /// </summary>
        public string BackUp2 { get; set; } 
        
        [Display(Name = "备用字段3")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 备用字段3 
        /// </summary>
        public string BackUp3 { get; set; } 
        
        [Display(Name = "备用字段4")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 备用字段4 
        /// </summary>
        public string BackUp4 { get; set; } 
        
        [Display(Name = "备用字段5")]
           [StringLength(4000, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在4000个以内.")]
        /// <summary>
        /// 备用字段5 
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
                case "USERCODE":
                	value = UserCode;
                    break;
                case "ROLEID":
                	value = RoleId;
                    break;
                case "UPDATETIME":
                	value = UpdateTime;
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
