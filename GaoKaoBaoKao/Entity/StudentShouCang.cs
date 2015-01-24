using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class StudentShouCang
	{
		#region StudentShouCang Entity Begin
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
		private int _schoolid;
		public int SchoolId
		{
			set { _schoolid = value;}
			get { return _schoolid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _zhuanyeid;
		public int ZhuanYeId
		{
			set { _zhuanyeid = value;}
			get { return _zhuanyeid;}
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
		private string _zhuanyename;
		public string ZhuanYeName
		{
			set { _zhuanyename = value;}
			get { return _zhuanyename;}
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
		
		#endregion StudentShouCang Entity End
	}
}

