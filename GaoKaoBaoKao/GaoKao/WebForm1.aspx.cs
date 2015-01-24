//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.IO;

namespace GaoKao
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "";
            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQu_AllList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int SchoolId = Basic.TypeConverter.StrToInt(dt.Rows[i]["SchoolId"].ToString(), 0);
                int ProfessionalId = Basic.TypeConverter.StrToInt(dt.Rows[i]["ZyId"].ToString(), 0);
                if (DAL.FenShengZhuanYeLuQu.SchoolZhuanYeCount(SchoolId, ProfessionalId) == 0)
                {
                    //需要新增
                    int DisciplinesId = 0;

                    int ProfessionalGrade = Basic.TypeConverter.StrToInt(dt.Rows[i]["ProfessionalGrade"].ToString(), 0);
                    int ParentId = Basic.TypeConverter.StrToInt(dt.Rows[i]["ParentId"].ToString(), 0);
                    if (ProfessionalGrade == 3)
                    {
                        Entity.Professional info = DAL.Professional.ProfessionalEntityGet(ParentId);
                        if (info != null)
                        {
                            DisciplinesId = info.ParentId;
                        }
                        else
                        {
                            str += SchoolId + "-" + ProfessionalId + ";";
                        }
                    }
                    else if (ProfessionalGrade == 2)
                    {
                        DisciplinesId = ParentId;
                    }
                    else
                    {
                        str += SchoolId + "-" + ProfessionalId + ";";
                    }

                    if (DisciplinesId > 0)
                    {
                        int SchoolDisciplinesId = 0;
                        //开始插入数据
                        //1.操作 SchoolDisciplines 表
                        DataTable dt2 = DAL.SchoolDisciplines.SchoolDisciplinesList("SchoolId=" + SchoolId + " and DisciplinesId=" + DisciplinesId);
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            SchoolDisciplinesId = Basic.TypeConverter.StrToInt(dt2.Rows[0]["Id"].ToString(), 0);
                            int ProfessionalCount = Basic.TypeConverter.StrToInt(dt2.Rows[0]["ProfessionalCount"].ToString(), 0);
                            DAL.SchoolDisciplines.SchoolDisciplinesProfessionalCount((ProfessionalCount + 1), SchoolDisciplinesId);
                        }
                        else
                        {
                            Entity.SchoolDisciplines info = new Entity.SchoolDisciplines();
                            info.DisciplinesId = DisciplinesId;
                            info.IsPause = 0;
                            info.ProfessionalCount = 1;
                            info.SchoolId = SchoolId;
                            SchoolDisciplinesId = DAL.SchoolDisciplines.SchoolDisciplinesAdd(info);
                        }

                        if (SchoolDisciplinesId == 0)
                        {
                            Basic.MsgHelper.AlertBackMsg("wrong");
                        }
                        else
                        {
                            //2.操作 SchoolProfessional 表
                            Entity.SchoolProfessional model = new Entity.SchoolProfessional();
                            model.AddTime = DateTime.Now;
                            model.AddWid = 0;
                            model.ClickNum = 0;
                            model.IsErJiZhongDian = 0;
                            model.IsPause = 0;
                            model.IsTeSe = 0;
                            model.IsXueKePaiMing = 0;
                            model.IsYiJiZhongDian = 0;
                            model.ProfessionalId = ProfessionalId;
                            model.ProfessionalIntro = "";
                            model.ProfessionalName = dt.Rows[i]["ZhuanYeMingCheng"].ToString();
                            model.SchoolDisciplinesId = SchoolDisciplinesId;

                            int nu = DAL.SchoolProfessional.SchoolProfessionalAdd(model);
                            if (nu == 0)
                            {
                                Basic.MsgHelper.AlertBackMsg("aa");
                            }
                        }
                    }
                }
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = "";
            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQu_ZheJiang_AllList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int SchoolId = Basic.TypeConverter.StrToInt(dt.Rows[i]["SchoolId"].ToString(), 0);
                int ProfessionalId = Basic.TypeConverter.StrToInt(dt.Rows[i]["ZyId"].ToString(), 0);
                if (DAL.FenShengZhuanYeLuQu.SchoolZhuanYeCount(SchoolId, ProfessionalId) == 0)
                {
                    //需要新增
                    int DisciplinesId = 0;

                    int ProfessionalGrade = Basic.TypeConverter.StrToInt(dt.Rows[i]["ProfessionalGrade"].ToString(), 0);
                    int ParentId = Basic.TypeConverter.StrToInt(dt.Rows[i]["ParentId"].ToString(), 0);
                    if (ProfessionalGrade == 3)
                    {
                        Entity.Professional info = DAL.Professional.ProfessionalEntityGet(ParentId);
                        if (info != null)
                        {
                            DisciplinesId = info.ParentId;
                        }
                        else
                        {
                            str += SchoolId + "-" + ProfessionalId + ";";
                        }
                    }
                    else if (ProfessionalGrade == 2)
                    {
                        DisciplinesId = ParentId;
                    }
                    else
                    {
                        str += SchoolId + "-" + ProfessionalId + ";";
                    }

                    if (DisciplinesId > 0)
                    {
                        int SchoolDisciplinesId = 0;
                        //开始插入数据
                        //1.操作 SchoolDisciplines 表
                        DataTable dt2 = DAL.SchoolDisciplines.SchoolDisciplinesList("SchoolId=" + SchoolId + " and DisciplinesId=" + DisciplinesId);
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            SchoolDisciplinesId = Basic.TypeConverter.StrToInt(dt2.Rows[0]["Id"].ToString(), 0);
                            int ProfessionalCount = Basic.TypeConverter.StrToInt(dt2.Rows[0]["ProfessionalCount"].ToString(), 0);
                            DAL.SchoolDisciplines.SchoolDisciplinesProfessionalCount((ProfessionalCount + 1), SchoolDisciplinesId);
                        }
                        else
                        {
                            Entity.SchoolDisciplines info = new Entity.SchoolDisciplines();
                            info.DisciplinesId = DisciplinesId;
                            info.IsPause = 0;
                            info.ProfessionalCount = 1;
                            info.SchoolId = SchoolId;
                            SchoolDisciplinesId = DAL.SchoolDisciplines.SchoolDisciplinesAdd(info);
                        }

                        if (SchoolDisciplinesId == 0)
                        {
                            Basic.MsgHelper.AlertBackMsg("wrong");
                        }
                        else
                        {
                            //2.操作 SchoolProfessional 表
                            Entity.SchoolProfessional model = new Entity.SchoolProfessional();
                            model.AddTime = DateTime.Now;
                            model.AddWid = 0;
                            model.ClickNum = 0;
                            model.IsErJiZhongDian = 0;
                            model.IsPause = 0;
                            model.IsTeSe = 0;
                            model.IsXueKePaiMing = 0;
                            model.IsYiJiZhongDian = 0;
                            model.ProfessionalId = ProfessionalId;
                            model.ProfessionalIntro = "";
                            model.ProfessionalName = dt.Rows[i]["ZhuanYeMingCheng"].ToString();
                            model.SchoolDisciplinesId = SchoolDisciplinesId;

                            int nu = DAL.SchoolProfessional.SchoolProfessionalAdd(model);
                            if (nu == 0)
                            {
                                Basic.MsgHelper.AlertBackMsg("aa");
                            }
                        }
                    }
                }
            }
        }
    }
}