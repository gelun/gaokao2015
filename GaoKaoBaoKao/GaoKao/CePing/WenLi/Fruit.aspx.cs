using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.WenLi
{
    public partial class Fruit : UserBase
    {
        protected int WenKe = 0;
        protected int LiKe = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DAL.Join_TestWLResults.Join_TestWLResultsList(" UserId=" + this.user.StudentId);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                WenKe = int.Parse(dr["WK"].ToString()) + 100;
                LiKe = int.Parse(dr["LK"].ToString()) + 100;
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您还未进行文理分科测评，请先进行测评", "Default.aspx");
            }
        }
    }
}