using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ZhiYeZhuanYe
	{
		#region ZhiYeZhuanYe Entity Begin
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
            set { _professionalid = value; }
            get { return _professionalid; }
		}
		
		#endregion ZhiYeZhuanYe Entity End
	}
}

