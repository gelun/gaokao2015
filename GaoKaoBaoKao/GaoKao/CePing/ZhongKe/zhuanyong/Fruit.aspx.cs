using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhongKe
{
    public partial class Fruit : System.Web.UI.Page
    {
        bool isMember = true;
        #region   学习力

        int group_BeiDong = 0;    //学习被动值
        int group_YanXue = 0;     //厌学度
        int group_XinXiCaiJi = 0; //生动类信息采集量
        int group_FangFa = 0;  //学习方法
        int group_BiJiao = 0; //学习比较性
        int group_ZiJian = 0;  //学习自检性
        int group_QuDao = 0; //学习参与渠道

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //isMember = DAL.Comm.JCJH(user.StudentId);

                Panel1.Visible = isMember;
                Analyse();
            }
        }

        //解析
        void Analyse()
        {
            if (Request.Cookies["zhongkeCook"] != null)
            {
                if (Request.Cookies["zhongkeCook"]["group_BeiDong"] != null)
                {
                    group_BeiDong = int.Parse(Request.Cookies["zhongkeCook"]["group_BeiDong"]);
                }
                if (Request.Cookies["zhongkeCook"]["group_YanXue"] != null)
                {
                    group_YanXue = int.Parse(Request.Cookies["zhongkeCook"]["group_YanXue"]);
                }

                if (Request.Cookies["zhongkeCook"]["group_XinXiCaiJi"] != null)
                {
                    group_XinXiCaiJi = int.Parse(Request.Cookies["zhongkeCook"]["group_XinXiCaiJi"]);
                }
                if (Request.Cookies["zhongkeCook"]["group_FangFa"] != null)
                {
                    group_FangFa = int.Parse(Request.Cookies["zhongkeCook"]["group_FangFa"]);
                }
                if (Request.Cookies["zhongkeCook"]["group_BiJiao"] != null)
                {
                    group_BiJiao = int.Parse(Request.Cookies["zhongkeCook"]["group_BiJiao"]);
                }

                if (Request.Cookies["zhongkeCook"]["group_ZiJian"] != null)
                {
                    group_ZiJian = int.Parse(Request.Cookies["zhongkeCook"]["group_ZiJian"]);
                }

                if (Request.Cookies["zhongkeCook"]["group_QuDao"] != null)
                {
                    group_QuDao = int.Parse(Request.Cookies["zhongkeCook"]["group_QuDao"]);
                }

            }



            beidong.Text = group_BeiDong.ToString();
            yanxue.Text = group_YanXue.ToString();
            caiji.Text = group_XinXiCaiJi.ToString();
            fangfa.Text = group_FangFa.ToString();
            bijiao.Text = group_BiJiao.ToString();
            zijian.Text = group_ZiJian.ToString();
            qudao.Text = group_QuDao.ToString();


       

        }
    }
}