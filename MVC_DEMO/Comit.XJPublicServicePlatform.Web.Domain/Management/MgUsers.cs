/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-25 14:39:17
** 描述：mg_users(用户信息
   
   登录密码：按)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Management
{
    [Serializable]
    public class MgUsers
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MgUsers()
        {
            Id = Int64.MinValue;
            OrgId = String.Empty;
            UserCode = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;
            Sex = String.Empty;
            TelePhone = String.Empty;
            MobilePhone = String.Empty;
            Email = String.Empty;
            KeyPassword = String.Empty;
            KeyCode = String.Empty;
            CreateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            UpdateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            UserType = String.Empty;
            Status = String.Empty;
            Quarters = String.Empty;
            UserDuty = String.Empty;
            UserFax = String.Empty;
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

        [Display(Name = "用户ID")]
        /// <summary>
        /// 用户ID 
        /// </summary>
        public long Id { get; set; }

        [Display(Name = "用户组织")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 用户组织 
        /// </summary>
        public string OrgId { get; set; }

        [Display(Name = "用户帐号")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 用户标识 
        /// </summary>
        public string UserCode { get; set; }

        [Display(Name = "用户中文名")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 用户中文名 
        /// </summary>
        public string UserName { get; set; }

        [Display(Name = "登录密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 登录密码 
        /// </summary>
        public string Password { get; set; }

        [Display(Name = "性别")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 性别 
        /// </summary>
        public string Sex { get; set; }

        [Display(Name = "电话")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 电话 
        /// </summary>
        public string TelePhone { get; set; }

        [Display(Name = "手机号码")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 手机号码 
        /// </summary>
        public string MobilePhone { get; set; }

        [Display(Name = "电子邮件")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 电子邮件 
        /// </summary>
        public string Email { get; set; }

        [Display(Name = "数字证书密码")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 数字证书密码 
        /// </summary>
        public string KeyPassword { get; set; }

        [Display(Name = "数字证书微缩图")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 数字证书微缩图 
        /// </summary>
        public string KeyCode { get; set; }

        [Display(Name = "创建时间")]
        /// 设置字段类型验证，如邮箱、电话等
        [DataType(DataType.DateTime)]
        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }

        [Display(Name = "更新时间")]
        /// 设置字段类型验证，如邮箱、电话等
        [DataType(DataType.DateTime)]
        /// <summary>
        /// 更新时间 
        /// </summary>
        public DateTime UpdateTime { get; set; }

        [Display(Name = "用户类别")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 用户类别 
        /// </summary>
        public string UserType { get; set; }

        [Display(Name = "操作方法")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 操作方法 
        /// </summary>
        public string Status { get; set; }

        [Display(Name = "岗位")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 岗位 
        /// </summary>
        public string Quarters { get; set; }

        [Display(Name = "职务")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 职务 
        /// </summary>
        public string UserDuty { get; set; }

        [Display(Name = "传真")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 传真 
        /// </summary>
        public string UserFax { get; set; }

        [Display(Name = "操作人")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
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
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 操作类型 
        /// </summary>
        public string OperateType { get; set; }

        [Display(Name = "备用字段1")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 备用字段1 
        /// </summary>
        public string BackUp1 { get; set; }

        [Display(Name = "备用字段2")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 备用字段2 
        /// </summary>
        public string BackUp2 { get; set; }

        [Display(Name = "备用字段3")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 备用字段3 
        /// </summary>
        public string BackUp3 { get; set; }

        [Display(Name = "备用字段4")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 备用字段4 
        /// </summary>
        public string BackUp4 { get; set; }

        [Display(Name = "备用字段5")]
        [StringLength(4000, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在4000个以内.")]
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
                case "ORGID":
                    value = OrgId;
                    break;
                case "USERCODE":
                    value = UserCode;
                    break;
                case "USERNAME":
                    value = UserName;
                    break;
                case "PASSWORD":
                    value = Password;
                    break;
                case "SEX":
                    value = Sex;
                    break;
                case "TELEPHONE":
                    value = TelePhone;
                    break;
                case "MOBILEPHONE":
                    value = MobilePhone;
                    break;
                case "EMAIL":
                    value = Email;
                    break;
                case "KEYPASSWORD":
                    value = KeyPassword;
                    break;
                case "KEYCODE":
                    value = KeyCode;
                    break;
                case "CREATETIME":
                    value = CreateTime;
                    break;
                case "UPDATETIME":
                    value = UpdateTime;
                    break;
                case "USERTYPE":
                    value = UserType;
                    break;
                case "STATUS":
                    value = Status;
                    break;
                case "QUARTERS":
                    value = Quarters;
                    break;
                case "USERDUTY":
                    value = UserDuty;
                    break;
                case "USERFAX":
                    value = UserFax;
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
