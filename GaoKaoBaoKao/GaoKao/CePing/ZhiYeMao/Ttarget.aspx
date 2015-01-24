<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ttarget.aspx.cs" Inherits="GaoKao.CePing.ZhiYeMao.Ttarget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>学习力测评</title>
    <link href="../css/Test.css" type="text/css" rel="Stylesheet" rev="Stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    
</head>
<body onload=" page_Loading();">
    <form runat="server" id="form1">
    
    <div class="box fb">
        <img src="../images/box_top.png"></div>
    <div class="box box_c">
        <div class="bc bc_c">
            <div class="bccl">
                <asp:Literal ID="ltr_Over" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="box">
        <img src="../images/box_bottom.png" />
    </div>
    </form>
</body>
</html>
