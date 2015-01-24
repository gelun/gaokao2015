using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SeniorMiddleSchool
	{
		#region SeniorMiddleSchool Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _schoolid;
		public int SchoolId
		{
			set { _schoolid = value;}
			get { return _schoolid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _schoolname;
		public string SchoolName
		{
			set { _schoolname = value;}
			get { return _schoolname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _address;
		public string Address
		{
			set { _address = value;}
			get { return _address;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _provinceid;
		public int ProvinceId
		{
			set { _provinceid = value;}
			get { return _provinceid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _cityid;
		public int CityId
		{
			set { _cityid = value;}
			get { return _cityid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _xianid;
		public int XianId
		{
			set { _xianid = value;}
			get { return _xianid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ischeck;
		public int IsCheck
		{
			set { _ischeck = value;}
			get { return _ischeck;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ispause;
		public int IsPause
		{
			set { _ispause = value;}
			get { return _ispause;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime _addtime;
		public DateTime AddTime
		{
			set { _addtime = value;}
			get { return _addtime;}
		}
		
		#endregion SeniorMiddleSchool Entity End
	}
}

