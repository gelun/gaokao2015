using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class Province
	{
		#region Province Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _provinceid;
		public int ProvinceID
		{
			set { _provinceid = value;}
			get { return _provinceid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _provincename;
		public string ProvinceName
		{
			set { _provincename = value;}
			get { return _provincename;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _provincepinyin;
		public string ProvincePinYin
		{
			set { _provincepinyin = value;}
			get { return _provincepinyin;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _provincecode;
		public string ProvinceCode
		{
			set { _provincecode = value;}
			get { return _provincecode;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _admincode;
		public string AdminCode
		{
			set { _admincode = value;}
			get { return _admincode;}
		}
		
		#endregion Province Entity End
	}
}

