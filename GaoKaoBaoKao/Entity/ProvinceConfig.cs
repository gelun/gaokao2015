using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class ProvinceConfig
    {
        #region ProvinceConfig Entity Begin
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _provinceid;
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _latestprovinceweiciyear;
        public int LatestProvinceWeiCiYear
        {
            set { _latestprovinceweiciyear = value; }
            get { return _latestprovinceweiciyear; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _latestbenkeyear;
        public int LatestBenKeYear
        {
            set { _latestbenkeyear = value; }
            get { return _latestbenkeyear; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _latestbenkezhuanyeyear;
        public int LatestBenKeZhuanYeYear
        {
            set { _latestbenkezhuanyeyear = value; }
            get { return _latestbenkezhuanyeyear; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _haszhuanke;
        public int HasZhuanKe
        {
            set { _haszhuanke = value; }
            get { return _haszhuanke; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _latestzhuankeyear;
        public int LatestZhuanKeYear
        {
            set { _latestzhuankeyear = value; }
            get { return _latestzhuankeyear; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _haszhuankezhuanye;
        public int HasZhuanKeZhuanYe
        {
            set { _haszhuankezhuanye = value; }
            get { return _haszhuankezhuanye; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _hastiqianpi;
        public int HasTiQianPi
        {
            set { _hastiqianpi = value; }
            get { return _hastiqianpi; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _hastiqianpizhuanye;
        public int HasTiQianPiZhuanYe
        {
            set { _hastiqianpizhuanye = value; }
            get { return _hastiqianpizhuanye; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _tiqianpidatabeginyea;
        public int TiQianPiDataBeginYea
        {
            set { _tiqianpidatabeginyea = value; }
            get { return _tiqianpidatabeginyea; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _owntable;
        public int OwnTable
        {
            set { _owntable = value; }
            get { return _owntable; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime _changeendtime;
        public DateTime ChangeEndTime
        {
            set { _changeendtime = value; }
            get { return _changeendtime; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime _restarttime;
        public DateTime ReStartTime
        {
            set { _restarttime = value; }
            get { return _restarttime; }
        }

        #endregion ProvinceConfig Entity End
    }
}
