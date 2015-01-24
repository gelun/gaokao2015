using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class OldProfessional
	{
		#region OldProfessional Entity Begin
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
		private string _code;
		public string Code
		{
			set { _code = value;}
			get { return _code;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _professionalname;
		public string ProfessionalName
		{
			set { _professionalname = value;}
			get { return _professionalname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _remark;
		public string Remark
		{
			set { _remark = value;}
			get { return _remark;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _professionalgrade;
		public int ProfessionalGrade
		{
			set { _professionalgrade = value;}
			get { return _professionalgrade;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _parentid;
		public int ParentId
		{
			set { _parentid = value;}
			get { return _parentid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _professionalintro;
		public string ProfessionalIntro
		{
			set { _professionalintro = value;}
			get { return _professionalintro;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isben;
		public int IsBen
		{
			set { _isben = value;}
			get { return _isben;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _newprofessionalid;
		public int NewProfessionalId
		{
			set { _newprofessionalid = value;}
			get { return _newprofessionalid;}
		}
		
		#endregion OldProfessional Entity End
	}
}

