/******************************************************************************** 
** 作者：张权
** 时间：2016-05-25 11:49:22
** 描述：employee(员工信息)表的映射(自动生成 )
*********************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.employee
{
    [Serializable]
    public class Employee
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Employee()
        {
            Id = Int32.MinValue;
            Name = String.Empty;
            Idcard = String.Empty;
            Age = Int32.MinValue;
            Sex = String.Empty;
            Mobile = String.Empty;
            Address = String.Empty;
            Height = Int32.MinValue;
            National = String.Empty;
            Birth = new DateTime(1900, 1, 1, 0, 0, 0);
            Province = String.Empty;
            City = String.Empty;
            HouseholdType = String.Empty;
            PoliticalLandscape = String.Empty;
            Hobbies = String.Empty;
            Remark = String.Empty;
            State = Int32.MinValue;
            OperatePerson = String.Empty;
            OperateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            OperateType = String.Empty;
        }

        #endregion

        #region 字段

        [Display(Name = "主键")]
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "姓名")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 姓名 
        /// </summary>
        public string Name { get; set; }

        [Display(Name = "身份证号码")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 身份证号码 
        /// </summary>
        public string Idcard { get; set; }

        [Display(Name = "年龄")]
        /// <summary>
        /// 年龄 
        /// </summary>
        public int Age { get; set; }

        [Display(Name = "性别-单选")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 性别-单选 
        /// </summary>
        public string Sex { get; set; }

        [Display(Name = "手机")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 手机 
        /// </summary>
        public string Mobile { get; set; }

        [Display(Name = "联系地址")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 联系地址 
        /// </summary>
        public string Address { get; set; }

        [Display(Name = "身高")]
        /// <summary>
        /// 身高 
        /// </summary>
        public int Height { get; set; }

        [Display(Name = "民族")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 民族 
        /// </summary>
        public string National { get; set; }

        [Display(Name = "出生年月")]
        /// 设置字段类型验证，如邮箱、电话等
        [DataType(DataType.DateTime)]
        /// <summary>
        /// 出生年月 
        /// </summary>
        public DateTime Birth { get; set; }

        [Display(Name = "出生地省-下拉")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 出生地省-下拉 
        /// </summary>
        public string Province { get; set; }

        [Display(Name = "出生地市-下拉")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 出生地市-下拉 
        /// </summary>
        public string City { get; set; }

        [Display(Name = "户籍类型-单选")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 户籍类型-单选 
        /// </summary>
        public string HouseholdType { get; set; }

        [Display(Name = "户籍类型")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        /// 户籍类型 
        /// </summary>
        public string PoliticalLandscape { get; set; }

        [Display(Name = "兴趣爱好-多选")]
        [StringLength(500, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在500个以内.")]
        /// <summary>
        /// 兴趣爱好-多选 
        /// </summary>
        public string Hobbies { get; set; }

        [Display(Name = "备注")]
        [StringLength(1000, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在1000个以内.")]
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        [Display(Name = "状态")]
        /// <summary>
        /// 状态 
        /// </summary>
        public int State { get; set; }

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
                case "NAME":
                    value = Name;
                    break;
                case "IDCARD":
                    value = Idcard;
                    break;
                case "AGE":
                    value = Age;
                    break;
                case "SEX":
                    value = Sex;
                    break;
                case "MOBILE":
                    value = Mobile;
                    break;
                case "ADDRESS":
                    value = Address;
                    break;
                case "HEIGHT":
                    value = Height;
                    break;
                case "NATIONAL":
                    value = National;
                    break;
                case "BIRTH":
                    value = Birth;
                    break;
                case "PROVINCE":
                    value = Province;
                    break;
                case "CITY":
                    value = City;
                    break;
                case "HOUSEHOLDTYPE":
                    value = HouseholdType;
                    break;
                case "POLITICALLANDSCAPE":
                    value = PoliticalLandscape;
                    break;
                case "HOBBIES":
                    value = Hobbies;
                    break;
                case "REMARK":
                    value = Remark;
                    break;
                case "STATE":
                    value = State;
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
            }

            return value;
        }
    }
}
