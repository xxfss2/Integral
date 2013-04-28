<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuiguangsQQ.aspx.cs" Inherits="TuiguangsQQ" %>
<%@ Import Namespace ="integral.Action" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
          html,body
        {
            background-color :#ECE9D8;
            font-size :14px;overflow:hidden;
        }
        .style1
        {
            width: 100%;
        }
        .td1
        {
            width :100px ; border-right :1px solid #000000;
        }
        .td2
        {
            width :110px; border-right :1px solid #000000;
        }
        .li1
        {
            float :left; border :1px solid #000000 ; width :280px;list-style-type:none; margin-left :5px;
        }
          .style1 td
        {
            border :1px solid #000000;
        }
    </style>
</head>
<body>
   <iframe src ="http://soft.11343777.com/soft/free.html" width ="100%" height ="200px" ></iframe>
    <form id="form1" runat="server">
    <div>
    <div style="margin :0 auto; width :600px; ">
       <table class="style1"  cellpadding ="0" cellspacing ="0" >
            <tr>
                <td>
                    添加新推广QQ：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="11"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" />
                </td>
            </tr>
        </table>
    </div>
    </div>
           <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False" >
        <HeaderTemplate >
       <ul>
       <li class="li1" >
       <table ><tr><th class="td1" >推广QQ号码</th><th class="td2" >添加时间</th><th>删除</th></tr></table>
       </li> 
          <li class="li1" >
          <table ><tr><th class="td1" >推广QQ号码</th><th class="td2">添加时间</th><th>删除</th></tr></table>
       </li> 
        <li class="li1" >
          <table ><tr><th class="td1" >推广QQ号码</th><th class="td2">添加时间</th><th>删除</th></tr></table>
       </li> 
        </HeaderTemplate>
        <ItemTemplate >
       <li class="li1" >
       <table ><tr>
<td class="td1" ><%#((TuiguangQQ)Container.DataItem).Tuiguang %> </td>
<td class="td2" ><%#((TuiguangQQ)Container.DataItem).CreatedAt%> </td>
<td style ="width :50px" ><a href ="#" onclick ="editLimit(<%#((TuiguangQQ)Container .DataItem).Id   %>)" >删除</a> </td>
</tr></table>
</li>
        </ItemTemplate>
        <FooterTemplate >
       </ul>
        </FooterTemplate>
        </asp:Repeater> 
    </form>
       <script type ="text/javascript" >
           function editLimit(id) {
               if (confirm('确认删除？') == true) {
                   window.location.href = "TuiguangsQQ.aspx?idd=<%=myqq %>&id=" + id;
               }
           }
   </script> 
</body>
</html>
