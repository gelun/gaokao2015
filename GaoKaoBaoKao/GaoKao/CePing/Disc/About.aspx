<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GaoKao.CePing.Disc.About" %>
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
