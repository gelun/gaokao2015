using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class cuotiben
	{
		#region cuotiben Entity Begin
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
		private int _wid;
		public int Wid
		{
			set { _wid = value;}
			get { return _wid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _timuid;
		public int TiMuId
		{
			set { _timuid = value;}
			get { return _timuid;}
		}

        private string _answer;
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _rightanswer;
        public string RightAnswer
        {
            set { _rightanswer = value; }
            get { return _rightanswer; }
        }
            
		#endregion cuotiben Entity End
	}
}

