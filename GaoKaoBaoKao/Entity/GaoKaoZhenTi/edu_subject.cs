using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class edu_subject
	{
		#region edu_subject Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _id;
		public int id
		{
			set { _id = value;}
			get { return _id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _name;
		public string name
		{
			set { _name = value;}
			get { return _name;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _subject_code;
		public string subject_code
		{
			set { _subject_code = value;}
			get { return _subject_code;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _subject_index;
		public int subject_index
		{
			set { _subject_index = value;}
			get { return _subject_index;}
		}
		
		#endregion edu_subject Entity End
	}
}

