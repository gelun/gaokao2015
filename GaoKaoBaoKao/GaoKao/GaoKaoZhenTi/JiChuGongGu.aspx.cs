using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class JiChuGongGu : Base
    {
        protected int intStudentId = 0;
        protected string strHtml = "";//页码显示
        protected int intZhiShiDianId = 0;
        protected string strZhiShiDianName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            intStudentId = userinfo.StudentId;

            Bind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        void Bind()
        {
            intZhiShiDianId = Basic.RequestHelper.GetQueryInt("id", 0);

            Entity.zhishidian infoZhiShiDian = DAL.zhishidian.zhishidianEntityGet(intZhiShiDianId);
            if (infoZhiShiDian == null)
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }
            else
            {
                strZhiShiDianName = infoZhiShiDian.name;

                //每页显示数量
                int intPageSize = 10;

                //总条数
                int intDataNumberAll = DAL.TengXB.ZhiShiDian.JiChuGongGuCount(DAL.Common.GetGaoKaoZhenTiTableName(infoZhiShiDian.subject_id), intZhiShiDianId);
                //总页数
                int intPageAll = Basic.PageNumber.GetPageAll(intDataNumberAll, intPageSize);
                //页码
                int intPageIndex = Basic.RequestHelper.GetQueryInt("p", 1);
                intPageIndex = Basic.PageNumber.GetCurrentPageNumber(intPageIndex, intPageAll);



                DataTable dtList = DAL.TengXB.ZhiShiDian.JiChuGongGuList(DAL.Common.GetGaoKaoZhenTiTableName(infoZhiShiDian.subject_id), intZhiShiDianId, intPageSize, intPageIndex);
                rpt_List.DataSource = dtList;
                rpt_List.DataBind();

                //分页
                strHtml = Basic.PageNumber.CreatPageNumber(intDataNumberAll, intPageSize, intPageIndex, 3, "JiChuGongGu.aspx?id=" + intZhiShiDianId + "&p=");
            }
        }
    }
}