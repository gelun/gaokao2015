using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SchoolArticle
	{
		#region SchoolArticle Entity Begin
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
		private int _categoryid;
		public int CategoryId
		{
			set { _categoryid = value;}
			get { return _categoryid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _icon;
		public string Icon
		{
			set { _icon = value;}
			get { return _icon;}
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
		private string _shorttitle;
		public string ShortTitle
		{
			set { _shorttitle = value;}
			get { return _shorttitle;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metatitle;
		public string MetaTitle
		{
			set { _metatitle = value;}
			get { return _metatitle;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metakeywords;
		public string MetaKeyWords
		{
			set { _metakeywords = value;}
			get { return _metakeywords;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metadescription;
		public string MetaDescription
		{
			set { _metadescription = value;}
			get { return _metadescription;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _summary;
		public string Summary
		{
			set { _summary = value;}
			get { return _summary;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _content;
		public string Content
		{
			set { _content = value;}
			get { return _content;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime _publishtime;
		public DateTime PublishTime
		{
			set { _publishtime = value;}
			get { return _publishtime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _istuijian;
		public int IsTuiJian
		{
			set { _istuijian = value;}
			get { return _istuijian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isnew;
		public int IsNew
		{
			set { _isnew = value;}
			get { return _isnew;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _iszhiding;
		public int IsZhiDing
		{
			set { _iszhiding = value;}
			get { return _iszhiding;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime _zhidingtime;
		public DateTime ZhiDingTime
		{
			set { _zhidingtime = value;}
			get { return _zhidingtime;}
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
		private int _ischeck;
		public int IsCheck
		{
			set { _ischeck = value;}
			get { return _ischeck;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime _checktime;
		public DateTime CheckTime
		{
			set { _checktime = value;}
			get { return _checktime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _checkwid;
		public int CheckWid
		{
			set { _checkwid = value;}
			get { return _checkwid;}
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
		private int _ispause;
		public int IsPause
		{
			set { _ispause = value;}
			get { return _ispause;}
		}
		
		/// <summary>
		/// 
		/// </summary>
        private int _year;
		public int Year
		{
			set { _year = value;}
			get { return _year;}
		}
		
		#endregion SchoolArticle Entity End
	}
}

