using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SchoolDisciplines
	{
		#region SchoolDisciplines Entity Begin
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
		private int _schoolid;
		public int SchoolId
		{
			set { _schoolid = value;}
			get { return _schoolid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _disciplinesid;
		public int DisciplinesId
		{
			set { _disciplinesid = value;}
			get { return _disciplinesid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _professionalcount;
		public int ProfessionalCount
		{
			set { _professionalcount = value;}
			get { return _professionalcount;}
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
		
		#endregion SchoolDisciplines Entity End
	}
}

