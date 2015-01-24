using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ShiPin
	{
		#region ShiPin Entity Begin
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
		private string _content;
		public string Content
		{
			set { _content = value;}
			get { return _content;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _video;
		public string Video
		{
			set { _video = value;}
			get { return _video;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _typename;
		public string TypeName
		{
			set { _typename = value;}
			get { return _typename;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _typeid;
		public int TypeId
		{
			set { _typeid = value;}
			get { return _typeid;}
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
		private int _ispause;
		public int IsPause
		{
			set { _ispause = value;}
			get { return _ispause;}
		}
		
		#endregion ShiPin Entity End
	}
}

