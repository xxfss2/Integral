<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuiguangQQ.aspx.cs" Inherits="Pages_Backend_UserManage_TuiguangQQ" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" />  
   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
         <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th> 推广QQ</th></tr> 
        </table>
        
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>会员QQ</th> <th>推广QQ</th><th>录入时间</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
        <tr>
<td><%#((TuiguangQQ)Container .DataItem).UserQQ   %> </td>
<td><%#((TuiguangQQ)Container.DataItem).Tuiguang %> </td>
<td><%#((TuiguangQQ)Container.DataItem).CreatedAt%> </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
                    <asp:Button ID="BTadd" runat="server" Text="导出"  onclick="BTadd_Click" /> 
            
<%--                    <asp:TextBox ID="txtDay1" runat="server" onClick="WdatePicker()" ></asp:TextBox>
            
                    -<asp:TextBox ID="txtDay2" runat="server" onClick="WdatePicker()" ></asp:TextBox>--%>
            
        </div>  
     </div>
    </div>
    </form>
   <script type ="text/javascript" >
       function addLimit() {
           window.open("LimitAdd.aspx", "等级设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
       function editLimit(id) {
           window.open("LimitAdd.aspx?id="+id, "等级设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
   </script> 
</body>
</html>
