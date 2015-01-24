using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class FenShengYuanXiaoLuQu
	{
		#region FenShengYuanXiaoLuQu Entity Begin
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
		private int _datayear;
		public int DataYear
		{
			set { _datayear = value;}
			get { return _datayear;}
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
		private string _shengshi;
		public string ShengShi
		{
			set { _shengshi = value;}
			get { return _shengshi;}
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
		private int _kelei;
		public int KeLei
		{
			set { _kelei = value;}
			get { return _kelei;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _keleimingcheng;
		public string KeLeiMingCheng
		{
			set { _keleimingcheng = value;}
			get { return _keleimingcheng;}
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
		private int _schoolprovinceid;
		public int SchoolProvinceId
		{
			set { _schoolprovinceid = value;}
			get { return _schoolprovinceid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _yuanxiaodaima;
		public string YuanXiaoDaiMa
		{
			set { _yuanxiaodaima = value;}
			get { return _yuanxiaodaima;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _yuanxiaomingcheng;
		public string YuanXiaoMingCheng
		{
			set { _yuanxiaomingcheng = value;}
			get { return _yuanxiaomingcheng;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zuigaofen;
		public int ZuiGaoFen
		{
			set { _zuigaofen = value;}
			get { return _zuigaofen;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pingjunfen;
		public int PingJunFen
		{
			set { _pingjunfen = value;}
			get { return _pingjunfen;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zuidifen;
		public int ZuiDiFen
		{
			set { _zuidifen = value;}
			get { return _zuidifen;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zuidaweici;
		public int ZuiDaWeiCi
		{
			set { _zuidaweici = value;}
			get { return _zuidaweici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pingjunweici;
		public int PingJunWeiCi
		{
			set { _pingjunweici = value;}
			get { return _pingjunweici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zuixiaoweici;
		public int ZuiXiaoWeiCi
		{
			set { _zuixiaoweici = value;}
			get { return _zuixiaoweici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _picixian;
		public int PiCiXian
		{
			set { _picixian = value;}
			get { return _picixian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pingjunxiancha;
		public int PingJunXianCha
		{
			set { _pingjunxiancha = value;}
			get { return _pingjunxiancha;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _jihuashu;
		public int JiHuaShu
		{
			set { _jihuashu = value;}
			get { return _jihuashu;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _toudangbili;
		public int TouDangBiLi
		{
			set { _toudangbili = value;}
			get { return _toudangbili;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _touchushu;
		public int TouChuShu
		{
			set { _touchushu = value;}
			get { return _touchushu;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _luqushu;
		public int LuQuShu
		{
			set { _luqushu = value;}
			get { return _luqushu;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _touchuzuidifen;
		public int TouChuZuiDiFen
		{
			set { _touchuzuidifen = value;}
			get { return _touchuzuidifen;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _touchuzuigaofen;
		public int TouChuZuiGaoFen
		{
			set { _touchuzuigaofen = value;}
			get { return _touchuzuigaofen;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _touchuzuixiaoweici;
		public int TouChuZuiXiaoWeiCi
		{
			set { _touchuzuixiaoweici = value;}
			get { return _touchuzuixiaoweici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _touchuzuidaweici;
		public int TouChuZuiDaWeiCi
		{
			set { _touchuzuidaweici = value;}
			get { return _touchuzuidaweici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isbulu;
		public int IsBuLu
		{
			set { _isbulu = value;}
			get { return _isbulu;}
		}
		
		#endregion FenShengYuanXiaoLuQu Entity End
	}
}

