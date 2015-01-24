using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class SchoolCampus
	{
		#region SchoolCampus Entity Begin
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
		private string _campus;
		public string Campus
		{
			set { _campus = value;}
			get { return _campus;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _pano;
		public string Pano
		{
			set { _pano = value;}
			get { return _pano;}
        }

        /// <summary>
        /// 
        /// </summary>
        private string _heading;
        public string Heading
        {
            set { _heading = value; }
            get { return _heading; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _pitch;
        public string Pitch
        {
            set { _pitch = value; }
            get { return _pitch; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _zoom;
        public string Zoom
        {
            set { _zoom = value; }
            get { return _zoom; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _url;
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
		
		#endregion SchoolCampus Entity End
	}
}

