using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class shijuan
	{
		#region shijuan Entity Begin
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
		private int _oldid;
		public int OldId
		{
			set { _oldid = value;}
			get { return _oldid;}
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
		private int _exam_type;
		public int exam_type
		{
			set { _exam_type = value;}
			get { return _exam_type;}
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
		private int _section_id;
		public int section_id
		{
			set { _section_id = value;}
			get { return _section_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _grade_id;
		public int grade_id
		{
			set { _grade_id = value;}
			get { return _grade_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _province_id;
		public string province_id
		{
			set { _province_id = value;}
			get { return _province_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _content;
		public string content
		{
			set { _content = value;}
			get { return _content;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _year;
		public string year
		{
			set { _year = value;}
			get { return _year;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _score;
		public int score
		{
			set { _score = value;}
			get { return _score;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _source;
		public string source
		{
			set { _source = value;}
			get { return _source;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _exam_time;
		public int exam_time
		{
			set { _exam_time = value;}
			get { return _exam_time;}
		}
		
		#endregion shijuan Entity End
	}
}

