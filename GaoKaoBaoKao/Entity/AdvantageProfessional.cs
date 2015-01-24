using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class AdvantageProfessional
	{
		#region AdvantageProfessional Entity Begin
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
		private int _professionalid;
		public int ProfessionalId
		{
			set { _professionalid = value;}
			get { return _professionalid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _istese;
		public int IsTeSe
		{
			set { _istese = value;}
			get { return _istese;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _tesepici;
		public string TeSePiCi
		{
			set { _tesepici = value;}
			get { return _tesepici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isxuekepaiming;
		public int IsXueKePaiMing
		{
			set { _isxuekepaiming = value;}
			get { return _isxuekepaiming;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isyijizhongdian;
		public int IsYiJiZhongDian
		{
			set { _isyijizhongdian = value;}
			get { return _isyijizhongdian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _iserjizhongdian;
		public int IsErJiZhongDian
		{
			set { _iserjizhongdian = value;}
			get { return _iserjizhongdian;}
		}
		
		#endregion AdvantageProfessional Entity End
	}
}

