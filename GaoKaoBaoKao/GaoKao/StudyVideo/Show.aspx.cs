using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.StudyVideo
{
    public partial class Show : Base
    {
        public string strTitle = "", strContent = "", strVideo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Basic.RequestHelper.GetQueryInt("id", 0);
            if (Id == 0)
                Response.Redirect("List.aspx");

            Entity.ShiPin shipin = DAL.ShiPin.ShiPinEntityGet(Id);
            strTitle = shipin.Title;
            strContent = shipin.Content;
            strVideo = shipin.Video;
        }
    }
}