using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ShengKongXianArticle
	{
		#region ShengKongXianArticle Entity Begin
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
		private string _title;
		public string Title
		{
			set { _title = value;}
			get { return _title;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metatitle;
		public string Metatitle
		{
			set { _metatitle = value;}
			get { return _metatitle;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metakeywords;
		public string Metakeywords
		{
			set { _metakeywords = value;}
			get { return _metakeywords;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _metadescription;
		public string Metadescription
		{
			set { _metadescription = value;}
			get { return _metadescription;}
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
		private int _datayear;
		public int DataYear
		{
			set { _datayear = value;}
			get { return _datayear;}
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
		
		#endregion ShengKongXianArticle Entity End
	}
}

