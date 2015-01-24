using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class S_District
	{
		#region S_Province Entity Begin
		/// <summary>
		/// 
		/// </summary>
        private int _districtid;
        public int DistrictID
		{
            set { _districtid = value; }
            get { return _districtid; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _districtname;
        public string DistrictName
		{
            set { _districtname = value; }
            get { return _districtname; }
		}
		
		#endregion S_Province Entity End
	}
}

