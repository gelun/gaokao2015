<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GaoKao.CePing.QiZhi.About" %>

<%@ Register Src="~/UserControl/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Foot.ascx" TagName="Foot" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <link href="../js/artDialog-5.0.3/skins/simple.css" rel="stylesheet" />
    <script  type="text/javascript" src="../js/artDialog-5.0.3/artDialog.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#showDialog").click(function () {

                art.dialog({
                    content: $("#show").html(),
                    width: "830px",
                    height: "530px",
                    lock: true

                });
            });
        })


        function CloseDialog() {

            var list = art.dialog.list;
            for (var i in list) {
                list[i].close();
            };
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
      　　评分与解释
　　1 如果某类气质得分明显高出其他三种，均高出4分以上，则可定为该类气质。如果该类气质得分超过20分，则为典型；如果该类得分在10～20分，则为一般型。
　　2 两种气质类型得分接近，其差异低于3分，而且又明显高于其他两种，高出4分以上，则可定为这两种气质的混合型。
　　3 三种气质得分均高于第四种，而且接近，则为三种气质的混合型。
　　4 如果4栏分数皆不高且相近（＜3分），则为4种气质的混合型。
　　此外，凡是在1、3、5……奇数题上答“2”或者“1”，或者在2、4、6……偶数题上答“－1”或“－2”，每题各得1分，否则得半分。如果你是男性，总分在0～10之间则非常内向，11～25分之间比较内向，26～35之间介于内外向之间，36～50之间比较外向，51～60之间非常外向。如果你是女性，总分在0～10之间非常内向，11～21之间比较内向，22～31之间介于内外向之间，32～45比较外向，46～60之间非常外向。
　　A 如果某一项或两项的得分超过20，则为典型的该气质，例如胆液质项超过20，则为典型的胆汁质；粘液质和抑郁质项得分超过20，则为典型粘液－抑郁质混合型。
　　B 如果某一项或者两项以上得分在20以下、10分以上，其他各项得分较低，则为该项一般气质。
　　C 若各项得分都在10分以下，但是某项或者几项得分较为高（相差5分以上），则为略倾向于该项气质（或几项混合）。例如略偏粘液质型；多血质－胆汁质混合型。
　　D 其余类推。
一般说来，正分值越高，表明被测越具有该项气质的典型特征；反之，分值越低或者越负，表明越不具备该项特征。

    <div>
        <uc1:Head ID="_head" runat="server" />
        <a href="javascript:void(0)" id="showDialog">开始测试</a>
        <uc1:Foot ID="_foot" runat="server" />
    </div>

    <div id="show" style="display: none;">
        <iframe id="test" src="Default.aspx" width="830px" height="530px;" style="border: 0px solid #000;">
        </iframe>
    </div>
    </form>

    
      
</body>
</html>
