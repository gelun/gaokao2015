using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Persional
{
    public partial class LetterForParent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProvinceId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "ProvinceId"), 0);//省份id
            if (ProvinceId == 72)//新疆乌鲁木齐咨询中心
            {
                Entity.AreaJson infoAreaJson = DAL.AnalysisArea.GetAreaModel();
                if (infoAreaJson != null)
                {
                    if (infoAreaJson.code == "0")
                    {
                        if (infoAreaJson.data.city_id == "653100")
                        {
                            //新疆乌鲁木齐咨询中心的卡不能在喀什地区使用
                            Basic.MsgHelper.AlertUrlMsg("该卡不能在喀什地区使用", "/logout.aspx");
                        }
                    }
                }
            }
        }
    }
}