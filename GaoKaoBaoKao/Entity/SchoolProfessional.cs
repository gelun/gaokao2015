using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SchoolProfessional
	{
		#region SchoolProfessional Entity Begin
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
		private int _schooldisciplinesid;
		public int SchoolDisciplinesId
		{
			set { _schooldisciplinesid = value;}
			get { return _schooldisciplinesid;}
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
		private string _professionalname;
		public string ProfessionalName
		{
			set { _professionalname = value;}
			get { return _professionalname;}
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
		private int _istese;
		public int IsTeSe
		{
			set { _istese = value;}
			get { return _istese;}
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
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime _addtime;
		public DateTime AddTime
		{
			set { _addtime = value;}
			get { return _addtime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _addwid;
		public int AddWid
		{
			set { _addwid = value;}
			get { return _addwid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _clicknum;
		public int ClickNum
		{
			set { _clicknum = value;}
			get { return _clicknum;}
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
		
		#endregion SchoolProfessional Entity End



        /// <summary>
        /// 
        /// </summary>
        private int _schoolid;
        public int SchoolId
        {
            set { _schoolid = value; }
            get { return _schoolid; }
        }
	}
}

