using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class YuSheChengJi
	{
		#region YuSheChengJi Entity Begin
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
		private int _studentid;
		public int StudentId
		{
			set { _studentid = value;}
			get { return _studentid;}
        }

        /// <summary>
        /// 
        /// </summary>
        private int _kelei;
        public int KeLei
        {
            set { _kelei = value; }
            get { return _kelei; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		private int _fenshu;
		public int FenShu
		{
            set { _fenshu = value; }
            get { return _fenshu; }
		}

        /// <summary>
        /// 
        /// </summary>
        private int _pcfirst;
        public int PcFirst
        {
            set { _pcfirst = value; }
            get { return _pcfirst; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		private int _pcsecond;
		public int PcSecond
		{
			set { _pcsecond = value;}
			get { return _pcsecond;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pcthird;
		public int PcThird
		{
			set { _pcthird = value;}
			get { return _pcthird;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pczhuanke;
		public int PcZhuanKe
		{
			set { _pczhuanke = value;}
			get { return _pczhuanke;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _allowchangecount;
        public int AllowChangeCount
		{
            set { _allowchangecount = value; }
            get { return _allowchangecount; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _havechangecount;
		public int HaveChangeCount
		{
            set { _havechangecount = value; }
            get { return _havechangecount; }
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
		
		#endregion YuSheChengJi Entity End
	}
}

