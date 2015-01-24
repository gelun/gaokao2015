using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class Log
	{
		#region Log Entity Begin
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
		private string _title;
		public string Title
		{
			set { _title = value;}
			get { return _title;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _urllink;
		public string UrlLink
		{
			set { _urllink = value;}
			get { return _urllink;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _categoryname;
		public string CategoryName
		{
			set { _categoryname = value;}
			get { return _categoryname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _beizhu;
		public string BeiZhu
		{
			set { _beizhu = value;}
			get { return _beizhu;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _caozuoleibie;
		public string CaoZuoLeiBie
		{
			set { _caozuoleibie = value;}
			get { return _caozuoleibie;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _addwid;
		public int AddWid
		{
			set { _addwid = value;}
			get { return _addwid;}
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
		
		#endregion Log Entity End
	}
}

