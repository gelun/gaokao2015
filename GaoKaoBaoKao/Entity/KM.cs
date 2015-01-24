using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class KM
	{
		#region KM Entity Begin
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
		private int _parentid;
		public int ParentId
		{
			set { _parentid = value;}
			get { return _parentid;}
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
		
		/// <summary>
		/// 
		/// </summary>
		private string _content1;
		public string Content1
		{
			set { _content1 = value;}
			get { return _content1;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _linkid;
		public int LinkId
		{
			set { _linkid = value;}
			get { return _linkid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _classty;
		public int ClassTy
		{
			set { _classty = value;}
			get { return _classty;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _content2;
		public string Content2
		{
			set { _content2 = value;}
			get { return _content2;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _content3;
		public string Content3
		{
			set { _content3 = value;}
			get { return _content3;}
		}
		
		#endregion KM Entity End
	}
}

