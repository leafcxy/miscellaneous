/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 19:05:35
** 描述：mg_popedom(权限管理
   
   )表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Management
{
	[Serializable]
    public class MgPopedom
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public MgPopedom()
        {
            Id = Int64.MinValue;
            RoleId = String.Empty;
            PrivilegeId = String.Empty;
            PrivilegeName = String.Empty;
            ParentPrivilegeId = String.Empty;
            PrivilegeType = String.Empty;
            PrivilegeFlag = String.Empty;
            Remark = String.Empty;
            SysCode = String.Empty;
            RecordTime = new DateTime(1900, 1, 1, 0, 0, 0);
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
        
        [Display(Name = "权限ID")]
        /// <summary>
        /// 权限ID 
        /// </summary>
        public long Id { get; set; } 
        
        [Display(Name = "角色id")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 角色id 
        /// </summary>
        public string RoleId { get; set; } 
        
        [Display(Name = "节点ID")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
          [Required(ErrorMessage="{0}是必填项")]
        /// <summary>
        /// 节点ID 
        /// </summary>
        public string PrivilegeId { get; set; } 
        
        [Display(Name = "权限说明")]
           [StringLength(4000, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在4000个以内.")]
        /// <summary>
        /// 权限说明 
        /// </summary>
        public string PrivilegeName { get; set; } 
        
        [Display(Name = "上级权限点ID")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 上级权限点ID 
        /// </summary>
        public string ParentPrivilegeId { get; set; } 
        
        [Display(Name = "权限类别")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 权限类别 
        /// </summary>
        public string PrivilegeType { get; set; } 
        
        [Display(Name = "权限标识")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 权限标识 
        /// </summary>
        public string PrivilegeFlag { get; set; } 
        
        [Display(Name = "备注")]
           [StringLength(4000, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在4000个以内.")]
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; } 
        
        [Display(Name = "系统代码")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 系统代码 
        /// </summary>
        public string SysCode { get; set; } 
        
        [Display(Name = "记录更新时间")]
            /// 设置字段类型验证，如邮箱、电话等
            [DataType(DataType.DateTime)]            	
        /// <summary>
        /// 记录更新时间 
        /// </summary>
        public DateTime RecordTime { get; set; } 
        
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
                case "ROLEID":
                	value = RoleId;
                    break;
                case "PRIVILEGEID":
                	value = PrivilegeId;
                    break;
                case "PRIVILEGENAME":
                	value = PrivilegeName;
                    break;
                case "PARENTPRIVILEGEID":
                	value = ParentPrivilegeId;
                    break;
                case "PRIVILEGETYPE":
                	value = PrivilegeType;
                    break;
                case "PRIVILEGEFLAG":
                	value = PrivilegeFlag;
                    break;
                case "REMARK":
                	value = Remark;
                    break;
                case "SYSCODE":
                	value = SysCode;
                    break;
                case "RECORDTIME":
                	value = RecordTime;
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
