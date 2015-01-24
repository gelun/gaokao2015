using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class cuotiben : Base
    {
        protected int intStudentId = 0;
        protected string strHtml = "";//页码显示

        protected void Page_Load(object sender, EventArgs e)
        {
            intStudentId = userinfo.StudentId;

            Bind();
        }

        /// <summary>
        /// 获取筛选条件
        /// </summary>
        string GetCondition()
        {
            string strCondition = " cuotiben.Wid = " + intStudentId;


            return strCondition;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        void Bind()
        {
            //每页显示数量
            int intPageSize = 10;

            //筛选条件
            string strCondition = GetCondition();
            //总条数
            int intDataNumberAll = DAL.tengxb.zhenti.CuoTiBenCount(strCondition);
            //总页数
            int intPageAll = Basic.PageNumber.GetPageAll(intDataNumberAll, intPageSize);
            //页码
            int intPageIndex = Basic.RequestHelper.GetQueryInt("p", 1);
            intPageIndex = Basic.PageNumber.GetCurrentPageNumber(intPageIndex, intPageAll);



            DataTable dtList = DAL.tengxb.zhenti.CuoTiBenPageList(strCondition, intPageSize, intPageIndex);
            rpt_List.DataSource = dtList;
            rpt_List.DataBind();

            //分页
            strHtml = Basic.PageNumber.CreatPageNumber(intDataNumberAll, intPageSize, intPageIndex, 3, "cuotiben.aspx?p=");
        }
    }
}