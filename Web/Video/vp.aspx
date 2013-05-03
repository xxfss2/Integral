<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vp.aspx.cs" Inherits="Video_vp" %>
<%@ Register src="UserInfo.ascx" tagname="UserInfo" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>终生会员</title>
    <style type="text/css">

    html,body
        {
            background-color :#ECE9D8;
            font-size :14px;overflow:hidden;
        }
body,td,th {
	font-size: 13px;
}
a:link {
	color: #333333;
	text-decoration: none;
}
a:visited {
	text-decoration: none;
	color: #333333;
}
a:hover {
	text-decoration: none;
	color: #009900;
}
a:active {
	text-decoration: none;
	color: #009900;
}
.STYLE1 {
	font-size: 14px;
	font-weight: bold;
}
    .style2
    {
        color: #FF0000;
    }
    .style3
    {
        width: 100%;
    }
                .head
        {
            width: 100%;
        }
        
        .head td
        {
            border :1px solid #000000;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:UserInfo ID="UserInfo1" runat="server" />
    <div style ="margin-top :5px" >
    <div align="center" runat ="server" id ="video" ><iframe frameborder="0" scrolling="no" src="http://cmp.81110210.com/132/cmp.asp?id=39" width="600" height="400"></iframe></div>
    </div>
    </form>
</body>
</html>
