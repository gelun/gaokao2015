using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.StudyVideo
{
    public partial class List : Base
    {
        public string strPage = "";
        public int xk = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            xk = Basic.RequestHelper.GetQueryInt("xk", 1);
            int intCurrentPageNumber = Basic.RequestHelper.GetQueryInt("p", 1);
            int intPageSize = 17;
            string strWhere = "";
            if (xk == 1)
                strWhere = "";
            else
                strWhere = " TypeId = " + xk;
            DataTable dt = DAL.ShiPin.ShiPinPageList(strWhere, intPageSize, intCurrentPageNumber);
            rp_List.DataSource = dt;
            rp_List.DataBind();


            int intDataAll = DAL.ShiPin.ShiPinCount(strWhere);
            int intPageAll = Basic.PageNumber.GetPageAll(intDataAll, intPageSize);
            intCurrentPageNumber = Basic.PageNumber.GetCurrentPageNumber(intCurrentPageNumber, intPageAll);
            strPage = strPage = Basic.PageNumber.CreatPageNumber(intDataAll, intPageSize, intCurrentPageNumber, 4, "List.aspx?xk="+ xk + "&p=");
        }
    }
}