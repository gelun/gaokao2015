<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GaoKao.CePing.Holland.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>职业兴趣测评</title>
    <link href="../css/Test.css" type="text/css" rel="Stylesheet" rev="Stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript">
             //页面初始化
             function  page_Loading(){
                var  loadNumber=$(".boxlist input:radio:checked").length;
                 var  anNumber=0;
                anNumber= (<%=page %>-1)*<%=pagesize %>+loadNumber;

                //页面数量
                $("#answer").text(anNumber);

                var  radioNumber=$(".bc_c input:radio").length;
                    //计算进度条长度
                var  plan=answer_Number*$(".jdt").width()/(radioNumber/3);

                $("#plan").css("width",plan);

                $(".a").each(function (n) {
                    $(this).find("input:radio").each(function(c){
                      
                       if(c==0){
                         
                        $(this).next().text("A："+$(this).next().text()) ;
                        }
                         if(c==1){
                         $(this).next().text("B："+$(this).next().text()) ;
                        }
                        if(c==2){
                         $(this).next().text("C："+$(this).next().text()) ;
                        }

                        
                    });
                 });
            }

             $(function(){
                $(".bc_c input:radio").click(function () {
                    //回答的题的数目
                    var answer_Number = $(".bc_c input:radio:checked").length;

                  var  radioNumber=$(".bc_c input:radio").length;
                    //计算进度条长度
                    var  plan=answer_Number*$(".jdt").width()/(radioNumber/2);


                    $("#plan").css("width",plan);
                    $("#answer").text(answer_Number+(<%=page %>-1)*<%=pagesize %>);
                    $(this).parent().parent().parent().css("background","");
                    $(this).parent().parent().parent().addClass("redbg");

                });
             });


                      //确定是否新窗口打开页面
            function BlankWindow() {
                //判断是否最后一页，如果是最后一页则打开新窗口查看结果，如果不是则退出
                var  page=<%=page %>;
                if(page!=<%=countPage %>){

                    var a = window.top;
                    if (a == undefined) {
                        //新窗口打开本页

                        var w = 1000;
                        var h = 760;
                        var win = null;
                        var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                        var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                        var settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=no,resizable=no,location=no';
                   
                        var a = $("<a href='Fruit.aspx' target='_blank'>Apple</a>").get(0);
                        var e = document.createEvent('MouseEvents');
                        e.initEvent( 'click', true, true );
                        a.dispatchEvent(e);
                        //刷新父页面
                
                        //a.location.href=a.location.href;
                    }
               }
               else{
                  return;
               }
          }

    </script>
</head>
<body onload=" page_Loading();">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdPage" runat="server" Value="1" />
    <div class="box fb">
        <img src="../images/box_top.png"></div>
    <div class="box box_c">
        <div class="bc bc_t">
            <div class="bc_t_l">
                <img src="../images/logo.png" /><span>职业兴趣测评</span></div>
            <div class="bc_t_r">
                <div class="bc_t_r_l">
                    答题进度：</div>
                <div class="jdt">
                    <img id="plan" src="../images/jdt.png" style="height: 22px" /></div>
                <div class="bc_t_r_b">
                    <span id="answer">0</span>/<%=count%></div>
            </div>
        </div>
        <div class="bc bc_c">
            <div class="bccl">
                <ul>
                    <li class="q qt qtt">
                        <div class="ct">
                            <div class="cti">
                                &nbsp;</div>
                            <div class="ctqt" style="width: 520px;">
                                问题</div>
                            <ul class="cta" id="Ul2">
                                <li>是</li>
                                <li>否</li>
                            </ul>
                            <div class="bclear">
                            </div>
                        </div>
                    </li>
                    <asp:Repeater ID="rpt_List1" runat="server">
                        <ItemTemplate>
                            <li class="q qt qq">
                                <div class="ct">
                                    <div class="cti">
                                        <%#(page-1)*pagesize+Container.ItemIndex+1 %></div>
                                    <div class="ctqt" style="width: 520px;">
                                        </b><%# Eval("TestTitle")%></div>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TestId") %>' />
                                    <ul class="cta">
                                        <li>
                                            <input value="1" type="radio" id="question" runat="server" /></li>
                                        <li>
                                            <input id="Radio4" value="0" type="radio" runat="server" /></li>
                                    </ul>
                                    <div class="bclear">
                                    </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="bc bcb">
            <span class="alert_info"></span>
            <asp:ImageButton ID="ImageButton1" ImageUrl="../images/btn_next.png" runat="server"
                OnClick="next_Click" OnClientClick="return nextclick();" />
        </div>
    </div>
    <div class="box">
        <img src="../images/box_bottom.png" />
    </div>
    <script type="text/javascript">
        function nextclick() {
            BlankWindow();
            var errorList = 0;
            $(".qq").each(function (n) {
                var rads = $(".qq").eq(n).find("input:radio:checked").length;

                if (rads == 0) {
                    $(this).css("background", "#6e6e6e");
                    errorList++;
                }
            });
            if (errorList > 0) {
                $(".alert_info").text("共有" + errorList + "题没有回答");
                return false;
            } else {

                return true;
            }
            return false;
        }
    
    </script>
    </form>
</body>
</html>
