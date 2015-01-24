using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class area_province
	{
		#region area_province Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private string _id;
		public string id
		{
			set { _id = value;}
			get { return _id;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _name;
		public string Name
		{
			set { _name = value;}
			get { return _name;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _country_id;
		public string country_id
		{
			set { _country_id = value;}
			get { return _country_id;}
		}
		
		#endregion area_province Entity End
	}
}

