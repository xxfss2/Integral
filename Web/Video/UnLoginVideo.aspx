<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnLoginVideo.aspx.cs" Inherits="Video_UnLoginVideo" %>
<%@ Import Namespace ="integral.Action" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��Ƶ����</title>
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
               <strong >���տ��㣺</strong><asp:Literal ID="Literal1" runat="server"></asp:Literal>
          <span class="style2">�����ڲ��ţ�</span>
    <p style =" height :334px" >
        &nbsp;</p>
        <p class="STYLE1" ><strong >����Ԥ�棺</strong><asp:Literal ID="Literal2" runat="server"></asp:Literal><span class="style2">�����췢����</span></p>
        </td>
                  <td valign ="top">
                  <div style ="height :425px; overflow-y:auto;" >
                      <table  style =" border :1px solid #000000;"  >
                          <tr>
                              <td>
                                  ���¼�¼������˺��޹ۿ�������Ƶ��</td>
                          </tr>
                          <tr>
                              <td>
                                  ����Ԥ�棺<asp:Literal ID="Literal3" runat="server"></asp:Literal><span class="style2">�����ڲ��ţ�</span></td>
                          </tr>
                          <tr>
                              <td>
                                  ���տ��㣺<asp:Literal ID="Literal4" runat="server"></asp:Literal><span class="style2">�����췢����</span></td>
                          </tr>
                          <asp:Repeater runat ="server" ID ="rep1" >
                          <ItemTemplate >
                          <tr>
                          <td><strong > <%#((Movie)Container .DataItem).PlayDay.ToString ("yyyy��MM��dd��")   %></strong>(�ѷ���) </td>
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
