using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class S_City
	{
		#region S_Province Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _cityid;
        public int CityID
		{
            set { _cityid = value; }
            get { return _cityid; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cityname;
        public string CityName
		{
            set { _cityname = value; }
            get { return _cityname; }
		}
		
		#endregion S_Province Entity End
	}
}

