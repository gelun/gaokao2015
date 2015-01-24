using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class DingDan
	{
		#region DingDan Entity Begin
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
		private int _state;
		public int State
		{
			set { _state = value;}
			get { return _state;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _dingdanhao;
		public string DingDanHao
		{
			set { _dingdanhao = value;}
			get { return _dingdanhao;}
		}
            
		/// <summary>
		/// 
		/// </summary>
		private string _subject;
        public string Subject
		{
            set { _subject = value; }
            get { return _subject; }
		}

		/// <summary>
		/// 
		/// </summary>
		private string _body;
		public string Body
		{
			set { _body = value;}
			get { return _body;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _count;
		public int Count
		{
			set { _count = value;}
			get { return _count;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private decimal _danjia;
		public decimal DanJia
		{
			set { _danjia = value;}
			get { return _danjia;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private decimal _dingdanjine;
		public decimal DingDanJinE
		{
			set { _dingdanjine = value;}
			get { return _dingdanjine;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cellname;
		public string CellName
		{
			set { _cellname = value;}
			get { return _cellname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cellmobile;
		public string CellMobile
		{
			set { _cellmobile = value;}
			get { return _cellmobile;}
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
		private string _memo;
		public string Memo
		{
			set { _memo = value;}
			get { return _memo;}
        }

        /// <summary>
        /// 
        /// </summary>
        private int _provinceid;
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _wenli;
        public int WenLi
        {
            set { _wenli = value; }
            get { return _wenli; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _address;
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
		
		#endregion DingDan Entity End


        /// <summary>
        /// 
        /// </summary>
        private int _category;
        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }
	}
}

