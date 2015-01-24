using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SchoolCategory
	{
		#region SchoolCategory Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _int;
		public int Int
		{
			set { _int = value;}
			get { return _int;}
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
		private int _sort;
		public int Sort
		{
			set { _sort = value;}
			get { return _sort;}
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
		
		#endregion SchoolCategory Entity End
	}
}

