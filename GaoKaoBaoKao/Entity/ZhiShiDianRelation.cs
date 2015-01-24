using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ZhiShiDianRelation
	{
		#region ZhiShiDianRelation Entity Begin
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
		private int _zhentizsdid;
		public int ZhenTiZSDId
		{
			set { _zhentizsdid = value;}
			get { return _zhentizsdid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _kmzsdid;
		public int KMZSDId
		{
			set { _kmzsdid = value;}
			get { return _kmzsdid;}
		}
		
		#endregion ZhiShiDianRelation Entity End
	}
}

