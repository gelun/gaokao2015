using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class edu_grade
	{
		#region edu_grade Entity Begin
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
		private string _code;
		public string code
		{
			set { _code = value;}
			get { return _code;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _grade_index;
		public int grade_index
		{
			set { _grade_index = value;}
			get { return _grade_index;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _display_flag;
		public int display_flag
		{
			set { _display_flag = value;}
			get { return _display_flag;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _section_id;
		public int section_id
		{
			set { _section_id = value;}
			get { return _section_id;}
		}
		
		#endregion edu_grade Entity End
	}
}

