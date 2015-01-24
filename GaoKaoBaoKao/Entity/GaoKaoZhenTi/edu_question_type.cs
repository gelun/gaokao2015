using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class edu_question_type
	{
		#region edu_question_type Entity Begin
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
		private int _subject_id;
		public int subject_id
		{
			set { _subject_id = value;}
			get { return _subject_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _type_name;
		public string type_name
		{
			set { _type_name = value;}
			get { return _type_name;}
		}
		
		#endregion edu_question_type Entity End
	}
}

