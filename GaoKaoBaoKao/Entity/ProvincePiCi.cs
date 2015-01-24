using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ProvincePiCi
	{
		#region ProvincePiCi Entity Begin
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
		private int _provinceid;
		public int ProvinceId
		{
			set { _provinceid = value;}
			get { return _provinceid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _leibie;
		public int LeiBie
		{
			set { _leibie = value;}
			get { return _leibie;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _cengci;
		public int CengCi
		{
			set { _cengci = value;}
			get { return _cengci;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pici;
		public int PiCi
		{
			set { _pici = value;}
			get { return _pici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pcleibie;
		public int PcLeiBie
		{
			set { _pcleibie = value;}
			get { return _pcleibie;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _pcname;
		public string PcName
		{
			set { _pcname = value;}
			get { return _pcname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _pcintro;
		public string PcIntro
		{
			set { _pcintro = value;}
			get { return _pcintro;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ckfsx;
		public int CkFsx
		{
			set { _ckfsx = value;}
			get { return _ckfsx;}
		}


        /// <summary>
        /// 
        /// </summary>
        private int _majorcount;
        public int MajorCount
        {
            set { _majorcount = value; }
            get { return _majorcount; }
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
		
		/// <summary>
		/// 
		/// </summary>
		private int _showorder;
		public int ShowOrder
		{
			set { _showorder = value;}
			get { return _showorder;}
		}
		
		#endregion ProvincePiCi Entity End
	}
}

