using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class aaa
	{
		#region aaa Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _id;
		public int Id
		{
			set { _id = value;}
			get { return _id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhuanye;
		public string ZhuanYe
		{
			set { _zhuanye = value;}
			get { return _zhuanye;}
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
		
		#endregion aaa Entity End
	}
}

