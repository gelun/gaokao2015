using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class Join_MbitAnswer
	{
		#region Join_MbitAnswer Entity Begin
		/// <summary>
		/// 
		/// </summary>
		private int _answerid;
		public int AnswerId
		{
			set { _answerid = value;}
			get { return _answerid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _testid;
		public int TestId
		{
			set { _testid = value;}
			get { return _testid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _answercontent;
		public string AnswerContent
		{
			set { _answercontent = value;}
			get { return _answercontent;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _opetion;
		public string Opetion
		{
			set { _opetion = value;}
			get { return _opetion;}
		}
		
		#endregion Join_MbitAnswer Entity End
	}
}

