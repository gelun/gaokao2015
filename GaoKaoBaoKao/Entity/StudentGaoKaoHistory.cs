using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class StudentGaoKaoHistory
	{
		#region StudentGaoKaoHistory Entity Begin
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
		private int _fenshu;
		public int FenShu
		{
			set { _fenshu = value;}
			get { return _fenshu;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _firstlevel;
		public int FirstLevel
		{
			set { _firstlevel = value;}
			get { return _firstlevel;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _secondlevel;
		public int SecondLevel
		{
			set { _secondlevel = value;}
			get { return _secondlevel;}
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
		private int _pczhuankefirst;
		public int PcZhuanKeFirst
		{
			set { _pczhuankefirst = value;}
			get { return _pczhuankefirst;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _pczhuankesecond;
		public int PcZhuanKeSecond
		{
			set { _pczhuankesecond = value;}
			get { return _pczhuankesecond;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _issetupfenshuxian;
		public int IsSetUpFenShuXian
		{
			set { _issetupfenshuxian = value;}
			get { return _issetupfenshuxian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _weici;
		public int WeiCi
		{
			set { _weici = value;}
			get { return _weici;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _issetupweici;
		public int IsSetUpWeiCi
		{
			set { _issetupweici = value;}
			get { return _issetupweici;}
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
		private int _isgaokao;
		public int IsGaoKao
		{
			set { _isgaokao = value;}
			get { return _isgaokao;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _islatest;
		public int IsLatest
		{
			set { _islatest = value;}
			get { return _islatest;}
		}
		
		#endregion StudentGaoKaoHistory Entity End
	}
}

