using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class student2tm
	{
		#region student2tm Entity Begin
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
		private int _type;
		public int Type
		{
			set { _type = value;}
			get { return _type;}
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
		
		/// <summary>
		/// 
		/// </summary>
		private string _answer;
		public string Answer
		{
			set { _answer = value;}
			get { return _answer;}
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
		
		/// <summary>
		/// 
		/// </summary>
		private int _result;
		public int Result
		{
			set { _result = value;}
			get { return _result;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zubie;
		public string ZuBie
		{
			set { _zubie = value;}
			get { return _zubie;}
		}

        /// <summary>
        /// 
        /// </summary>
        private int _sx;
        public int sx
        {
            set { _sx = value; }
            get { return _sx; }
        }
		
		#endregion student2tm Entity End
	}
}

