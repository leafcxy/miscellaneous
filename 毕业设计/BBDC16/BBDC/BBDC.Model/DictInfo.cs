using System;
namespace BBDC.Model
{
	/// <summary>
	/// dict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DictInfo
	{
		public DictInfo()
		{}
		#region Model
		private string _describe;
		private string _bookid;
		/// <summary>
		/// 
		/// </summary>
		public string describe
		{
			set{ _describe=value;}
			get{return _describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bookid
		{
			set{ _bookid=value;}
			get{return _bookid;}
		}
		#endregion Model

	}
}

