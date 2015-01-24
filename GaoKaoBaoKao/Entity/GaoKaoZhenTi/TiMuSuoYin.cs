using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class TiMuSuoYin
	{
		#region TiMuSuoYin Entity Begin
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
		private string _gid;
		public string gid
		{
			set { _gid = value;}
			get { return _gid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zh_knowledge;
		public string zh_knowledge
		{
			set { _zh_knowledge = value;}
			get { return _zh_knowledge;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _difficulty;
		public int difficulty
		{
			set { _difficulty = value;}
			get { return _difficulty;}
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
		private int _objective_flag;
		public int objective_flag
		{
			set { _objective_flag = value;}
			get { return _objective_flag;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _option_count;
		public int option_count
		{
			set { _option_count = value;}
			get { return _option_count;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _group_count;
		public int group_count
		{
			set { _group_count = value;}
			get { return _group_count;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _question_type;
		public string question_type
		{
			set { _question_type = value;}
			get { return _question_type;}
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
		private int _grade_id;
		public int grade_id
		{
			set { _grade_id = value;}
			get { return _grade_id;}
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
		private int _edu_question_type_id;
		public int edu_question_type_Id
		{
			set { _edu_question_type_id = value;}
			get { return _edu_question_type_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zhishidian_id;
		public int zhishidian_id
		{
			set { _zhishidian_id = value;}
			get { return _zhishidian_id;}
		}
		
		#endregion TiMuSuoYin Entity End
	}
}

