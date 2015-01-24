using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class zhishidian
	{
		#region zhishidian Entity Begin
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
		private int _subject_id;
		public int subject_id
		{
			set { _subject_id = value;}
			get { return _subject_id;}
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
		
		#endregion zhishidian Entity End
	}
}

