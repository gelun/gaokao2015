using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ZhiYe
	{
		#region ZhiYe Entity Begin
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
		private string _code;
		public string Code
		{
			set { _code = value;}
			get { return _code;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhiyename;
		public string ZhiYeName
		{
			set { _zhiyename = value;}
			get { return _zhiyename;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _remark;
		public string Remark
		{
			set { _remark = value;}
			get { return _remark;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zhiyelevel;
		public int ZhiYeLevel
		{
			set { _zhiyelevel = value;}
			get { return _zhiyelevel;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _parentid;
		public int ParentId
		{
			set { _parentid = value;}
			get { return _parentid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _intro;
		public string Intro
		{
			set { _intro = value;}
			get { return _intro;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _clicknum;
		public int ClickNum
		{
			set { _clicknum = value;}
			get { return _clicknum;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _url;
		public string Url
		{
			set { _url = value;}
			get { return _url;}
		}
		
		#endregion ZhiYe Entity End
	}
}

