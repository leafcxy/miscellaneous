/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:08
** 描述：TreeNodes(菜单节点)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Management
{
	[Serializable]
    public class Treenodes
    {
        #region 构造函数
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public Treenodes()
        {
            Id = Int64.MinValue;
            PrivilegeId = String.Empty;
            NodeName = String.Empty;
            ParentId = String.Empty;
            Url = String.Empty;
            AddUrl = String.Empty;
            DelUrl = String.Empty;
            SelUrl = String.Empty;
            Window = String.Empty;
            Orderby = Int32.MinValue;
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
        
        [Display(Name = "自增主键")]
        /// <summary>
        /// 自增主键 
        /// </summary>
        public long Id { get; set; } 
        
        [Display(Name = "节点ID")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 节点ID 
        /// </summary>
        public string PrivilegeId { get; set; } 
        
        [Display(Name = "菜单节点")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 菜单节点 
        /// </summary>
        public string NodeName { get; set; } 
        
        [Display(Name = "父节点ID")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 父节点ID 
        /// </summary>
        public string ParentId { get; set; } 
        
        [Display(Name = "节点链接")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 节点链接 
        /// </summary>
        public string Url { get; set; } 
        
        [Display(Name = "增加链接")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 增加链接 
        /// </summary>
        public string AddUrl { get; set; } 
        
        [Display(Name = "删除链接")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 删除链接 
        /// </summary>
        public string DelUrl { get; set; } 
        
        [Display(Name = "查看链接")]
           [StringLength(500, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 查看链接 
        /// </summary>
        public string SelUrl { get; set; } 
        
        [Display(Name = "窗口标识")]
           [StringLength(100, ErrorMessage="{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 窗口标识 
        /// </summary>
        public string Window { get; set; } 
        
        [Display(Name = "排序标识")]
        /// <summary>
        /// 排序标识 
        /// </summary>
        public int Orderby { get; set; } 
        
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
        public DateTime? OperateTime { get; set; } 
        
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
                case "PRIVILEGEID":
                	value = PrivilegeId;
                    break;
                case "NODENAME":
                	value = NodeName;
                    break;
                case "PARENTID":
                	value = ParentId;
                    break;
                case "URL":
                	value = Url;
                    break;
                case "ADDURL":
                	value = AddUrl;
                    break;
                case "DELURL":
                	value = DelUrl;
                    break;
                case "SELURL":
                	value = SelUrl;
                    break;
                case "WINDOW":
                	value = Window;
                    break;
                case "ORDERBY":
                	value = Orderby;
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
