<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Movie.aspx.cs" Inherits="Pages_Backend_UserManage_Limit" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" /> 

   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th> 视频管理</th></tr> 
        </table>
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr><th></th>
        <th>视频名称</th> <th>URL</th><th>播放日期</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
        <td class="checkbox" ><input type ="checkbox" id="CB<%#Container.ItemIndex  %>" onclick="checkedItem(<%#((Movie)Container .DataItem).Id  %>,this)" /></td>
<td><%#((Movie)Container .DataItem).Name %> </td>
<td><%#((Movie)Container.DataItem).URL%> </td>
<td><%#((Movie)Container.DataItem).PlayDay.ToShortDateString ()%> </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
                    <asp:Button ID="BTadd" runat="server" Text="添加" OnClientClick ="addLimit();return false;" /> 
            
                    <asp:Button ID="BTadd0" runat="server" Text="删除" 
                        OnClientClick ="return deletes();" onclick="BTadd0_Click" /> 
            
        </div>  
     </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    </form>
   <script type ="text/javascript" >
       function deletes() {
           if (selList.length <= 0) {
               alert("请勾选要删除的视频");
               return false;
           }
           $("#HiddenField1").val(selList.join(','));
           return true;
       }
       function addLimit() {
           window.open("MovieAdd.aspx", "等级设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
       function editLimit(id) {
           window.open("LimitAdd.aspx?id="+id, "等级设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
   </script> 
</body>
</html>
