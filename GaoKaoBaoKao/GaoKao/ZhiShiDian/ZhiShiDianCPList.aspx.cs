using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhiShiDian
{
    public partial class ZhiShiDianCPList : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Basic.RequestHelper.GetQueryString("ty");
                if (strType == "zsd")
                {
                    int intSubjectId = Basic.RequestHelper.GetQueryInt("index", 0) + 1;
                    DataTable dt = DAL.TengXB.ZhiShiDian.ZhiShiDianList(DAL.Common.GetGaoKaoZhenTiTableName(intSubjectId));

                    string strHtml = "";
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strHtml += "<li><input type=\"checkbox\" class=\"rad\" k='" + dt.Rows[i]["Id"].ToString() + "' v='" + dt.Rows[i]["name"].ToString() + "' />" + dt.Rows[i]["name"].ToString() + "</li>";
                        }
                    }

                    Response.Write(strHtml);
                    Response.End();
                }
            }
        }

    }
}