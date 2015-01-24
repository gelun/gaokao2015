using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class TiMuNeiRong
	{
		#region TiMuNeiRong Entity Begin
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
		private string _content;
		public string content
		{
			set { _content = value;}
			get { return _content;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _objective_answer;
		public string objective_answer
		{
			set { _objective_answer = value;}
			get { return _objective_answer;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _answer;
		public string answer
		{
			set { _answer = value;}
			get { return _answer;}
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
		
		#endregion TiMuNeiRong Entity End
	}
}

