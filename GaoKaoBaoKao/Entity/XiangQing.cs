using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class XiangQing
    {
        #region XiangQing Entity Begin
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
        private int _loginid;
        public int LoginId
        {
            set { _loginid = value; }
            get { return _loginid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _ykstudentxinxiid;
        public int YKStudentXinXiId
        {
            set { _ykstudentxinxiid = value; }
            get { return _ykstudentxinxiid; }
        }

        #endregion XiangQing Entity End
    }
}
