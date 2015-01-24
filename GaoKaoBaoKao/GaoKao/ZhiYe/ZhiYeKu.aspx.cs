using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ZhiYe
{
    public partial class ZhiYeKu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Bind();
        }

        //void Bind()
        //{
        //    DataTable dt = DAL.ZhiYe.ZhiYeList("ZhiYeLevel = 1 AND ParentId = 0");
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        rptListYiJi.DataSource = dt;
        //        rptListYiJi.DataBind();
        //    }
        //}

        //protected void rptListYiJi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {

        //        Repeater rptListErJi = e.Item.FindControl("rptListErJi") as Repeater;
        //        DataRowView rowv = (DataRowView)e.Item.DataItem;// 
        //        int ZhiYeId = Convert.ToInt32(rowv["Id"]); //
        //        DataTable dt = DAL.ZhiYe.ZhiYeList("ZhiYeLevel = 2 AND ParentId = " + ZhiYeId);
        //        rptListErJi.DataSource = dt;
        //        rptListErJi.DataBind();
        //    }
        //}
    }
}