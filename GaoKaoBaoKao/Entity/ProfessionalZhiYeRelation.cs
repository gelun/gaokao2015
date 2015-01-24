using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ProfessionalZhiYeRelation
	{
		#region ProfessionalZhiYeRelation Entity Begin
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
		private int _zhiyeid;
		public int ZhiYeId
		{
			set { _zhiyeid = value;}
			get { return _zhiyeid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _professionalid;
		public int ProfessionalId
		{
			set { _professionalid = value;}
			get { return _professionalid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _professionalcode;
		public string ProfessionalCode
		{
			set { _professionalcode = value;}
			get { return _professionalcode;}
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
		
		#endregion ProfessionalZhiYeRelation Entity End
	}
}

