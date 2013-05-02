<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnLoginVideo.aspx.cs" Inherits="Video_UnLoginVideo" %>
<%@ Import Namespace ="integral.Action" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>视频播放</title>
<style type="text/css">

    html,body
        {
            background-color :#ECE9D8;
            font-size :14px;overflow:hidden;
           margin-top: 0px;
	margin-bottom: 0px;
	margin-left: 0px;
	margin-right: 0px;
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
</style></head>

<body>
<form id ="form1" runat="server"  >
<div >
          <table class="style3">
              <tr>
                  <td style =" width:70%" align="center" >
               <strong >今日看点：</strong><asp:Literal ID="Literal1" runat="server"></asp:Literal>
          <span class="style2">（正在播放）</span>
    <p style =" height :334px" >
        &nbsp;</p>
        <p class="STYLE1" ><strong >明日预告：</strong><asp:Literal ID="Literal2" runat="server"></asp:Literal><span class="style2">（明天发布）</span></p>
        </td>
                  <td valign ="top">
                  <div style ="height :425px; overflow-y:auto;" >
                      <table  style =" border :1px solid #000000;"  >
                          <tr>
                              <td>
                                  更新记录（免费账号限观看当天视频）</td>
                          </tr>
                          <tr>
                              <td>
                                  明日预告：<asp:Literal ID="Literal3" runat="server"></asp:Literal><span class="style2">（正在播放）</span></td>
                          </tr>
                          <tr>
                              <td>
                                  今日看点：<asp:Literal ID="Literal4" runat="server"></asp:Literal><span class="style2">（明天发布）</span></td>
                          </tr>
                          <asp:Repeater runat ="server" ID ="rep1" >
                          <ItemTemplate >
                          <tr>
                          <td><strong > <%#((Movie)Container .DataItem).PlayDay.ToString ("yyyy年MM月dd日")   %></strong>(已发布) </td>
                          </tr>
                           <tr>
                          <td><%#((Movie)Container.DataItem).Name %> </td>
                          </tr>
                          </ItemTemplate>
                          </asp:Repeater>
                      </table>
                      </div>
                  </td>
              </tr>
          </table>

</div>
</form>
</body>
</html>
