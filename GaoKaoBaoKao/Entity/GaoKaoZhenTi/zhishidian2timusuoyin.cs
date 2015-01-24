using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class zhishidian2timusuoyin
	{
		#region zhishidian2timusuoyin Entity Begin
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
		private int _zhishidianid;
		public int ZhiShiDianId
		{
			set { _zhishidianid = value;}
			get { return _zhishidianid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _timusuoyinid;
		public int TiMuSuoYinId
		{
			set { _timusuoyinid = value;}
			get { return _timusuoyinid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _gid;
		public string gid
		{
			set { _gid = value;}
			get { return _gid;}
		}
		
		#endregion zhishidian2timusuoyin Entity End
	}
}

