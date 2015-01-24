using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ShiJuan2TiMu
	{
		#region ShiJuan2TiMu Entity Begin
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
		private int _exam_id;
		public int exam_id
		{
			set { _exam_id = value;}
			get { return _exam_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _question_id;
		public string question_id
		{
			set { _question_id = value;}
			get { return _question_id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _q_index;
		public int q_index
		{
			set { _q_index = value;}
			get { return _q_index;}
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
		private int _id;
		public int Id
		{
			set { _id = value;}
			get { return _id;}
		}
		
		#endregion ShiJuan2TiMu Entity End
	}
}

