using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class Join_Card
	{
		#region Join_Card Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _cardid;
		public int CardId
		{
			set { _cardid = value;}
			get { return _cardid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cardbank;
		public string CardBank
		{
			set { _cardbank = value;}
			get { return _cardbank;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cardpass;
		public string CardPass
		{
			set { _cardpass = value;}
			get { return _cardpass;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isvalid;
		public int IsValid
		{
			set { _isvalid = value;}
			get { return _isvalid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _usestate;
		public int UseState
		{
			set { _usestate = value;}
			get { return _usestate;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _dianid;
		public int DianId
		{
			set { _dianid = value;}
			get { return _dianid;}
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
		private DateTime _opencardtime;
		public DateTime OpenCardTime
		{
			set { _opencardtime = value;}
			get { return _opencardtime;}
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
		private DateTime _usetime;
		public DateTime UseTime
		{
			set { _usetime = value;}
			get { return _usetime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _useip;
		public string UseIp
		{
			set { _useip = value;}
			get { return _useip;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _istest;
		public int IsTest
		{
			set { _istest = value;}
			get { return _istest;}
		}
		
		#endregion Join_Card Entity End
	}
}

