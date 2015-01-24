<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayQuery.aspx.cs" Inherits="GaoKao.Art.GouMai.YinLian.PayQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>交易信息查询页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请输入要查询的订单号：<input type="text" name="txtOrderID" size="20" /><br />
        请输入要查询的订单时间：<input type="text" name="txtOrderTime" size="20" /><br />
        <input type="submit" value=" 确定" />
    </div>
    </form>
    <div>
        <%=strResult %>
    </div>
</body>
</html>
