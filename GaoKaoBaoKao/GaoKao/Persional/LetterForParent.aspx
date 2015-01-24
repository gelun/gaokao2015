<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LetterForParent.aspx.cs"
    Inherits="GaoKao.Persional.LetterForParent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>致考生及父母的一封信_格伦高考网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function goNext() {
            if ($("input[type='checkbox']").attr("checked") == "checked") {
                location.href = "GeRenXinXi.aspx";
            } else {
                alert("请选中\" 我已阅读【必须阅读才能进行下一步哦】\"");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="致考生及父母的一封信" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 致考生及父母的一封信" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="mailTit">致考生及父母的一封信</div>
            <div class="mailword">
                <p>
                    “虽然我们的人生道路很漫长，但紧要处常常只有几步，特别是当我们还年轻的时候。”没有一个人的生活道路是笔直的、没有岔道的。有些岔道口，譬如政治上的岔道口，事业上的岔道口，个人生活上的岔道口，你走错了一步，可能会影响人生的一个时期，也可能影响一生！在现在这种规范化、程式化的社会，人生紧要的只有几步：高考、就业、婚姻！“高考”作为人生三大拐点基础就尤其重要。</p>
                <p>
                    高考不是孩子一个人的战斗，而是家庭集体合作的综合工程，孩子高考的成功与家长的付出密不可分。家长不仅仅要做好“后勤部长”，更要成为孩子的“战略参谋”！填报志愿是一次事关人生投资的重大决策，如果说衡量巴菲特投资成功的标准是赢取多少资金，那么衡量人生投资成功的标准则是赢取的人生幸福感有多少。理性的人生投资强调关注人生进阶的平台，填报志愿时的“夺宝大战”争夺的就是最利于个人发展的平台。人可以通过登上一个又一个的平台来展示自己的才华，充实人生，服务社会。一般的人随波逐流，社会把他放到什么样的平台上，他就在这个平台上生存；聪明的人会去发现立足的平台与更高一级平台的关系，努力登上新平台，拓宽发展的空间；高明的人会在出发之前设计好平台间的最佳路径，他们注重整体效应，善于充分发挥自己的优势，善于借用每一个平台中的资源，稳步登高。高明的人对社会的贡献更大，社会给予他们的回报也更多。所以说，科学填报志愿，合理规划人生是非常有道理的，也是非常有必要的，应当值得我们家长和考生们高度重视！</p>
                <p>
                    格伦高考报考智能推荐系统基于对近年来考生报考情况和数据综合分析，是结合教育学、统计学、信息技术、心理学等跨学科的多年综合性研究成果，开发的系统化、智能化升学规划服务体系，率先打造了集职业性格分析、心理辅导、专业百科、志愿填报、专家咨询、网络互动等功能为一体的高考志愿规划系统。</p>
                <p>
                    需要特别说明的是，本系统是填报志愿的辅助查询工具，能够为您节省查阅海量院校、专业、分数的时间，并给出与分数相关的详细分析结果，提高您的查询效率、给出合理的高考报考建议。系统虽然可以给出较为科学的建议，但是最终的决策权在于用户。</p>
                <p>
                    路漫漫其修远兮，格伦与您上下求索！再次您选择格伦高考报考智能推荐系统，希望我们共同努力，开创更加美好的未来！</p>
            </div>
            <div class="mailnext">
                <div class="wyyd">
                    <input type="checkbox" name="" class="next" /><span>我已阅读<strong>【必须阅读才能进行下一步哦】</strong></span></div>
                <div class="nextbtn">
                    <a href="javascript:goNext();">下一步</a></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
