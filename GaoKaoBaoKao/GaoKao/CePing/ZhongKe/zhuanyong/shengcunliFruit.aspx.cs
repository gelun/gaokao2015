using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhongKe
{
    public partial class shengcunliFruit : UserBase
    {
        bool isMember = true;

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
            DataTable dt = DAL.Join_ZhongKeResults.Join_ZhongKeResultsList("UserId=" + this.user.StudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                //beidong.Text = dt.Rows[0]["BeiDong"].ToString();
                //yanxue.Text = dt.Rows[0]["YanXue"].ToString();
                //caiji.Text = dt.Rows[0]["XinXiCaiJi"].ToString();
                //fangfa.Text = dt.Rows[0]["FangFa"].ToString();
                //bijiao.Text = dt.Rows[0]["BiJiao"].ToString();
                //zijian.Text = dt.Rows[0]["ZiJian"].ToString();
                //qudao.Text = dt.Rows[0]["QuDao"].ToString();


                //*/
                fenxi.Text = dt.Rows[0]["FenXi"].ToString();
                zikong.Text = dt.Rows[0]["ZiKong"].ToString();
                goutong.Text = dt.Rows[0]["GouTong"].ToString();
                siwei.Text = dt.Rows[0]["SiWei"].ToString();
                chengdan.Text = dt.Rows[0]["ChengDan"].ToString();


            }

        }
    }
}