/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:18
** 描述：ais_basic_info_history(船舶AIS基础数据)表的映射(自动生成 )
*********************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Comit.XJPublicServicePlatform.Web.Common;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    /// <summary>
    /// 新增该类专门用于轨迹回放
    /// 这样能够减少无谓的默认值数据在网络间传输
    /// </summary>
    [Serializable]
    public class AisHistoryVideo
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public AisHistoryVideo()
        {
            Id = Int64.MinValue;
            ShipId = String.Empty;
            Lat = Int32.MinValue;
            Lng = Int32.MinValue;
            Hdg = Int32.MinValue;
            Sog = 0;
            Cog = Int32.MinValue;
            Length = Int32.MinValue;
            ShipType = String.Empty;
            Name = String.Empty;
            DataSource = String.Empty; 
            LastTime = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        #endregion

        #region 字段

        [Display(Name = "自增id")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 自增id 
        /// </summary>
        public long Id { get; set; }

        [Display(Name = "航速")]
        [Required(ErrorMessage = "{0}是必填项")]

        /// <summary>
        /// 航速 
        /// </summary>
        public decimal Sog { get; set; }

        [Display(Name = "航迹向")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 航迹向 
        /// </summary>
        public decimal Cog { get; set; } 

        //[Display(Name = "ShipRegistry")]
        //[Required(ErrorMessage = "{0}是必填项")]

        ///// <summary>
        ///// 
        ///// </summary>
        //public string ShipRegistry { get; set; }


        [Display(Name = "船舶编号")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 船舶编号 
        /// </summary>
        public string ShipId { get; set; }


        [Display(Name = "纬度")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 纬度 
        /// </summary>
        public double Lat { get; set; }

        [Display(Name = "经度")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 经度 
        /// </summary>
        public double Lng { get; set; }

        [Display(Name = "航首向")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 航首向 
        /// </summary>
        public decimal Hdg { get; set; }


        //[Display(Name = "船舶类型")]
        //[StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        //[Required(ErrorMessage = "{0}是必填项")]
        ///// <summary>
        ///// 船舶类型 
        ///// </summary>
        //public string ShipType { get; set; }


        [Display(Name = "船名")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 船名 
        /// </summary>
        public string Name { get; set; }

        [Display(Name = "船长")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// <summary>
        /// 船长 
        /// </summary>
        public int Length { get; set; }

        [Display(Name = "船舶类型")]
        [Required(ErrorMessage = "{0}是必填项")]

        /// <summary>
        /// 船舶类型 
        /// </summary>
        public String ShipType { get; set; }

        [Display(Name = "")]
        [StringLength(100, ErrorMessage = "{0} 您输入的字符超过最大限度，请控制在100个以内.")]
        /// <summary>
        ///  
        /// </summary>
        public string DataSource { get; set; }

        [Display(Name = "最近时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        /// 设置字段类型验证，如邮箱、电话等
        [DataType(DataType.DateTime)]
        /// <summary>
        /// 最近时间 
        /// </summary>
        public DateTime LastTime { get; set; }

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
                case "SOG":
                    value = Sog;
                    break;
                case "COG":
                    value = Cog;
                    break;
                case "LAT":
                    value = Lat;
                    break;
                case "LNG":
                    value = Lng;
                    break;
                case "HDG":
                    value = Hdg;
                    break;
                case "SHIPTYPE":
                    value = ShipType;
                    break;
                case "Length":
                    value = Length;
                    break;
                case "NAME":
                    value = Name;
                    break;
                case "LASTTIME":
                    value = LastTime;
                    break;
                case "DATASOURCE":
                    value = DataSource;
                    break;
            }

            return value;
        }
    }
}
