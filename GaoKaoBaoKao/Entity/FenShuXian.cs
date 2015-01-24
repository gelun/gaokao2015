using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class FenShuXian
	{
		#region FenShuXian Entity Begin
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
		private string _province;
		public string Province
		{
			set { _province = value;}
			get { return _province;}
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
		private int _kelei;
		public int KeLei
		{
			set { _kelei = value;}
			get { return _kelei;}
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
		private int _pcfirst;
		public int PcFirst
		{
			set { _pcfirst = value;}
			get { return _pcfirst;}
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
		private int _zkfirst;
		public int ZkFirst
		{
			set { _zkfirst = value;}
			get { return _zkfirst;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zksecond;
		public int ZkSecond
		{
			set { _zksecond = value;}
			get { return _zksecond;}
		}
		
		#endregion FenShuXian Entity End
	}
}

