using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class ProvinceZhiYuan
	{
		#region ProvinceZhiYuan Entity Begin
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
        private int _provincepcId;
        public int ProvincePcId
		{
            set { _provincepcId = value; }
            get { return _provincepcId; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhiyuanming;
		public string ZhiYuanMing
		{
			set { _zhiyuanming = value;}
			get { return _zhiyuanming;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _suggestion;
		public string Suggestion
		{
			set { _suggestion = value;}
			get { return _suggestion;}
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
		
		/// <summary>
		/// 
		/// </summary>
		private int _ispause;
		public int IsPause
		{
			set { _ispause = value;}
			get { return _ispause;}
		}
		
		#endregion ProvinceZhiYuan Entity End
	}
}

