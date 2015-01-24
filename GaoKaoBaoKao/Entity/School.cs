using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
	public class School
	{
		#region School Entity Begin
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
		private string _schoolname;
		public string SchoolName
		{
			set { _schoolname = value;}
			get { return _schoolname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _schoolenname;
		public string SchoolEnName
		{
			set { _schoolenname = value;}
			get { return _schoolenname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _logo;
		public string Logo
		{
			set { _logo = value;}
			get { return _logo;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cengyongming;
		public string CengYongMing
		{
			set { _cengyongming = value;}
			get { return _cengyongming;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _schoolwebsite;
		public string SchoolWebSite
		{
			set { _schoolwebsite = value;}
			get { return _schoolwebsite;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhaoshengwebsite;
		public string ZhaoShengWebSite
		{
			set { _zhaoshengwebsite = value;}
			get { return _zhaoshengwebsite;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhaoshengtel;
		public string ZhaoShengTel
		{
			set { _zhaoshengtel = value;}
			get { return _zhaoshengtel;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _provinceid;
		public int ProvinceId
		{
			set { _provinceid = value;}
			get { return _provinceid;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _provincename;
		public string ProvinceName
		{
			set { _provincename = value;}
			get { return _provincename;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _cityname;
		public string CityName
		{
			set { _cityname = value;}
			get { return _cityname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _address;
		public string Address
		{
			set { _address = value;}
			get { return _address;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _foundingtime;
		public string FoundingTime
		{
			set { _foundingtime = value;}
			get { return _foundingtime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _yuanshi;
		public string YuanShi
		{
			set { _yuanshi = value;}
			get { return _yuanshi;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zhongdianxueke;
		public string ZhongDianXueKe
		{
			set { _zhongdianxueke = value;}
			get { return _zhongdianxueke;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _boshidian;
		public string BoShiDian
		{
			set { _boshidian = value;}
			get { return _boshidian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _shuoshidian;
		public string ShuoShiDian
		{
			set { _shuoshidian = value;}
			get { return _shuoshidian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _schoolintro;
		public string SchoolIntro
		{
			set { _schoolintro = value;}
			get { return _schoolintro;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _schoolcengci;
		public int SchoolCengCi
		{
			set { _schoolcengci = value;}
			get { return _schoolcengci;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _schoolnature;
		public int SchoolNature
		{
			set { _schoolnature = value;}
			get { return _schoolnature;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _yuanxiaoleixingid;
		public int YuanXiaoLeiXingId
		{
            set { _yuanxiaoleixingid = value; }
            get { return _yuanxiaoleixingid; }
		}

        /// <summary>
        /// 
        /// </summary>
        private string _yuanxiaoleixing;
        public string YuanXiaoLeiXing
        {
            set { _yuanxiaoleixing = value; }
            get { return _yuanxiaoleixing; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		private int _belong;
		public int Belong
		{
			set { _belong = value;}
			get { return _belong;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _belongname;
		public string BeLongName
		{
			set { _belongname = value;}
			get { return _belongname;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _is211;
		public int Is211
		{
			set { _is211 = value;}
			get { return _is211;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _is985;
		public int Is985
		{
			set { _is985 = value;}
			get { return _is985;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isgraduateschool;
		public int IsGraduateSchool
		{
			set { _isgraduateschool = value;}
			get { return _isgraduateschool;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isindependentrecruitment;
		public int IsIndependentRecruitment
		{
			set { _isindependentrecruitment = value;}
			get { return _isindependentrecruitment;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isnationaldefense;
		public int IsNationalDefense
		{
			set { _isnationaldefense = value;}
			get { return _isnationaldefense;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isexcellent;
		public int IsExcellent
		{
			set { _isexcellent = value;}
			get { return _isexcellent;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ismini211;
		public int IsMiNi211
		{
			set { _ismini211 = value;}
			get { return _ismini211;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isruralspecial;
		public int IsRuralSpecial
		{
			set { _isruralspecial = value;}
			get { return _isruralspecial;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isartspecialty;
		public int IsArtSpecialty
		{
			set { _isartspecialty = value;}
			get { return _isartspecialty;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ishighlevelathletes;
		public int IsHighLevelAthletes
		{
			set { _ishighlevelathletes = value;}
			get { return _ishighlevelathletes;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _isshidian;
		public int IsShiDian
		{
			set { _isshidian = value;}
			get { return _isshidian;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _wushulianranking;
		public int WuShuLianRanking
		{
			set { _wushulianranking = value;}
			get { return _wushulianranking;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _xiaoyouhuiranking;
		public int XiaoYouHuiRanking
		{
			set { _xiaoyouhuiranking = value;}
			get { return _xiaoyouhuiranking;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _minbanranking;
		public int MinBanRanking
		{
			set { _minbanranking = value;}
			get { return _minbanranking;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _dulixueyuanranking;
		public int DuLiXueYuanRanking
		{
			set { _dulixueyuanranking = value;}
			get { return _dulixueyuanranking;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _clicknum;
		public int ClickNum
		{
			set { _clicknum = value;}
			get { return _clicknum;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _ispause;
		public int IsPause
		{
			set { _ispause = value;}
			get { return _ispause;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private int _banxueleixing;
		public int BanXueLeiXing
		{
			set { _banxueleixing = value;}
			get { return _banxueleixing;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _email;
		public string Email
		{
			set { _email = value;}
			get { return _email;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _zipcode;
		public string ZipCode
		{
			set { _zipcode = value;}
			get { return _zipcode;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _collectionbooks;
		public string CollectionBooks
		{
			set { _collectionbooks = value;}
			get { return _collectionbooks;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _pic;
		public string Pic
		{
			set { _pic = value;}
			get { return _pic;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _studentcount;
		public string StudentCount
		{
			set { _studentcount = value;}
			get { return _studentcount;}
		}
		
		#endregion School Entity End
	}
}

