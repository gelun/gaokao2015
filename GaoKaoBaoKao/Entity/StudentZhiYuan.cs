using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class StudentZhiYuan
	{
		#region StudentZhiYuan Entity Begin
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
		private int _provincepcid;
		public int ProvincePcId
		{
			set { _provincepcid = value;}
			get { return _provincepcid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _provincezhiyuanid;
		public int ProvinceZhiYuanId
		{
			set { _provincezhiyuanid = value;}
			get { return _provincezhiyuanid;}
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
		private string _schoolname;
		public string SchoolName
		{
			set { _schoolname = value;}
			get { return _schoolname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _majorlist;
		public string MajorList
		{
			set { _majorlist = value;}
			get { return _majorlist;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _majorcount;
		public int MajorCount
		{
			set { _majorcount = value;}
			get { return _majorcount;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _istiaoji;
		public int IsTiaoJi
		{
			set { _istiaoji = value;}
			get { return _istiaoji;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isallmajor;
		public int IsAllMajor
		{
			set { _isallmajor = value;}
			get { return _isallmajor;}
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
		
		#endregion StudentZhiYuan Entity End
	}
}

