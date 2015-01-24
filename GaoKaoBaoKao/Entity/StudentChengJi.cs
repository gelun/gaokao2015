using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class StudentChengJi
	{
		#region StudentZhiYuan Entity Begin

        //StudentChengJiPiCi = 1;
        //        StudentChengJiXianChaShang = 0;//上一批次的线差
        //        StudentChengJiXianCha = FenShu - PcFirst;//批次线差
        //        StudentChengJiPiCiXian = PcFirst;

		/// <summary>
		/// 
		/// </summary>
        private int _PiCi;
        public int PiCi
		{
            set { _PiCi = value; }
            get { return _PiCi; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _XianChaShang;
		public int XianChaShang
		{
			set { _XianChaShang = value;}
			get { return _XianChaShang;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _XianCha;
        public int XianCha
		{
			set { _XianCha = value;}
			get { return _XianCha;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _PiCiXian;
        public int PiCiXian
		{
			set { _PiCiXian = value;}
			get { return _PiCiXian;}
		}

        private string _PiCiMingCheng;
        public string PiCiMingCheng
		{
            set { _PiCiMingCheng = value; }
            get { return _PiCiMingCheng; }
		}


        private int _ZhuanHuanFenCha;
        public int ZhuanHuanFenCha
        {
            set { _ZhuanHuanFenCha = value; }
            get { return _ZhuanHuanFenCha; }
        }


        private int _FenShu;
        public int FenShu
        {
            set { _FenShu = value; }
            get { return _FenShu; }
        }

        
        private int _WeiCi;
        public int WeiCi
        {
            set { _WeiCi = value; }
            get { return _WeiCi; }
        }


        private int _RenShu;
        public int RenShu
        {
            set { _RenShu = value; }
            get { return _RenShu; }
        }


        private int _LeiJiRenShu;
        public int LeiJiRenShu
        {
            set { _LeiJiRenShu = value; }
            get { return _LeiJiRenShu; }
        }

		#endregion StudentZhiYuan Entity End

	}
}

