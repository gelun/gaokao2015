<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.WenLi.Fruit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文理分科初级测评报告</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
        <script type="text/javascript">
            window.moveTo(-4, -4);
            window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
</head>
<body>
    <div class="mbtitu hightu1">
        文理分科</div>
    <div class="hightu2">
        初级测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            文理分科初级测评报告</div>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            简介</div>
        <p>
            文理分科是高中生活中的一次重大选择，是今后人生道路的分水岭。文理分科将影响到大学的专业选择，专业选择又与未来的职业有着紧密的联系。因此，在选择文理分科时，每一位学生和家长都要保持理性，一定要仔细深入地想一想，自己将来到底想做什么，对什么感兴趣，结合自己的学科优势，理智的做出选择。</p>
        <h2>
            首先要正确认识文理科特点：</h2>
        <p>
            文科侧重以论理和表达为能力的形象思维，在学习上注重以记忆、归纳、整理、比较等特点。文科对应的高等院校相对较少，从就业角度看，文科主要培养以社会为对象的事务型人才，主要从事外交、法律、媒体传播、金融财会、社会服务等行业。</p>
        <p>
            理科侧重以推理和研究为能力的逻辑思维，在学习上注重以记忆、理解、推理、计算为特点。理科对应的高等院校较多，社会需求也相对较多，从就业角度看，理科培养以技术为对象的科技研究、生产型人才，可从事的职业类型相对宽泛。</p>
        <h2>
            其次，要正确认识自身的特点：</h2>
        <p>
            一方面你要考虑自己真正喜欢什么科目？是物理、化学、生物？还是历史、地理、政治？如果文理水平差不多，你的潜力在哪？</p>
        <p>
            另一方面，选择文理分科除了要考虑自身成绩和对科目的兴趣外，还有一个非常重要的因素——你将来想从事、适合从事什么样的职业？</p>
        <p>
            您可通过 《文理分科高级测评报告》 来通过对您职业兴趣及倾向的具体分析，来获得更加细致具体的分析和建议。
        </p>
        <p>
            “格伦高中文理分科高级测评系统”以霍兰德职业兴趣理论为基础，结合能力倾向测验进行综合测评，帮助你了解自己的专业兴趣和能力倾向，根据你的不同特点，在365个职业和545个专业中匹配出适合的职业和专业，以此为依据，给你提供文理分科参考，从而帮助你做出正确的第一步职业生涯决策，为以后的顺利就业奠定良好的基础。
        </p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            阅读建议</div>
        <p>
            ·测验结果只是为您提供参考，文理分科时，您还需要考虑其他方面的因素，如各科成绩、家庭经济状况、升学和就业的现状和趋势等；</p>
        <p>
            ·花点时间与您身边的人，如家人、老师和职业指导或咨询专家讨论一下你个门功课的优势，未来的职业发展打断等，确定你的思维特点和发展方向；</p>
        <p>
            ·请认真阅读每一个环节测验结果的具体解释，并结合自己的实际情况，深入思考，测评结果对于今后就业方向也有很强的指导意义。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            格伦建议：文科/理科</div>
        <p>
            您在测试中表现出了对<span class="fontred wl">文科/理科</span>的一定倾向，如图：</p>
        <div class="depart">
            <div class="departone">
                文科:<span><img src="../images/departone.gif" class="wenke" style="border: 1px solid #000;" /></span></div>
            <div class="departtwo">
                理科:<span><img src="../images/departtwo.gif" class="like" style="border: 1px solid #000;" /></span></div>
        </div>
        <p>
            因此我们为推荐您选择<span class="fontred wl"> </span>，但要更加准确具体分析和选择分科，还要结合更多更具体的自身情况进行综合考虑。</p>
        <script type="text/javascript">
            //分析
            function analyse() {
                var wenk = <%=WenKe %>;
                var lik =<%=LiKe %>;
                //绘制视图
                 $(".wenke").css({"width":wenk+"px","height":"22px"});
                   $(".like").css({"width":lik+"px","height":"22px"});

                if (wenk > lik) {
                    //选择文科
                    $(".wl").text("文科");
                }
                else {
                    //选择理科
                     $(".wl").text("理科");
                }
            }
            analyse();
        </script>
    </div>
    <div class="contants">
        <h3>
            结束语</h3>
        <p>
            一个人的文理倾向，没有好坏之分。每个人的兴趣，一般都有最适合他的职业。我们要想在学习和工作中获得成功，很重要的一点，就是在选择工作的时候，尽量从事最适合我们的工作。</p>
        <p>
            因此，<a href="../Holland/about.aspx"><strong>职业兴趣及倾向 </strong></a>是决定文理分科非常重要的因素。</p>
        <p>
            您可通过 <strong>《文理分科高级测评报告》</strong> 来通过对您职业兴趣及倾向的具体分析，来获得更加细致具体的分析和建议。</p>
        <p>
            获得方式：1、您需要完成<strong><a href="../Holland/about.aspx">《格伦职业兴趣测评》</a></strong>获得<strong><a
                href="../Holland/Fruit.aspx">《职业兴趣初级测评报告》</a></strong>；
        </p>
        <p>
            2、之后，您可返回用户界面，进入“我的测评报告”页面，并选择生成<strong>《格伦文理分科高级测评报告》</strong>；
        </p>
        <p>
            最后，希望大家通过本测试，能够更好的了解自己的职业倾向，从而在文理分科的选择、未来的专业选择和择业过程中能够做出更加理性的判断，期望你能在未来的职业生涯中获得最大的成功！
        </p>
    </div>
</body>
</html>
