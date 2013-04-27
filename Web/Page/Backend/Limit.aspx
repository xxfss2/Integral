<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Limit.aspx.cs" Inherits="Pages_Backend_UserManage_Limit" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" />   <script type ="text/javascript" src ="../../../Scripts/jquery-1.3.2.min.js "></script>

   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th> 用户管理</th></tr> 
        </table>
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>等级名称</th> <th>达到该等级需要的积分</th><th>加密网页</th><th>是否可重复观看</th><th>是否需要积分</th><th>推荐人升级奖励</th><th>修改</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
<td><%#((Limit)Container .DataItem).Name   %> </td>
<td><%#((Limit)Container .DataItem).Integral   %> </td>
<td><%#((Limit)Container.DataItem).URL%> </td>
<td><%#((Limit)Container.DataItem).CanRepeater ?"是":"否" %> </td>
<td><%#((Limit)Container.DataItem).NeedIntegral ? "是" : "否"%> </td>
<td><%#((Limit)Container.DataItem).ShengjiJiangli  %> </td>
<td><a href ="#" onclick ="editLimit(<%#((Limit)Container .DataItem).Id   %>)" >修改</a> </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
                    <asp:Button ID="BTadd" runat="server" Text="添加" OnClientClick ="addLimit();return false;" /> 
            
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
