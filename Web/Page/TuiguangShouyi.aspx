<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuiguangShouyi.aspx.cs" Inherits="TuiguangShouyi" %>
<%@ Import Namespace ="integral.Action" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         html,body
        {
            font-size :14px;overflow:hidden;
        }
        .style1
        {
            width: 100%;
            text-align :center ;
        }
        .td1
        {
            width :100px ; border-right :1px solid #000000;
        }
        .td2
        {
            width :100px; border-right :1px solid #000000;
        }
        .li1
        {
            float :left; border :1px solid #000000 ; width :280px;list-style-type:none; margin-left :5px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="margin :0 auto; width :900px; ">
       <table class="style1" border ="1" >
            <tr>
                <td>
                    推荐新人注册获取积分：</td>
                <td>
                    <asp:Literal ID="lTuijian" runat="server"></asp:Literal>
                </td>
                <td>
                    推荐下线升级获得的积分:</td>
                <td>
                    <asp:Literal ID="lLevel" runat="server"></asp:Literal>
                </td>
                <td>
                    销售积分获得的收益金额:</td>
                <td>
                    <asp:Literal ID="lJifen" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    <div style =" height :200px;" >
     <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False" 
            onitemdatabound="Ruserlist_ItemDataBound">
        <HeaderTemplate >
               <ul>
       <li class="li1" >
       <table ><tr><th class="td1" >下线号码</th><th class="td2" >下线等级</th><th>获取积分</th></tr></table>
       </li> 
          <li class="li1" >
          <table ><tr><th class="td1" >下线号码</th><th class="td2">下线等级</th><th>获取积分</th></tr></table>
       </li> 
        <li class="li1" >
          <table ><tr><th class="td1" >下线号码</th><th class="td2">下线等级</th><th>获取积分</th></tr></table>
       </li> 
        </HeaderTemplate>
        <ItemTemplate >
        <li class="li1" >
        <table >
        <tr>
<td><%# DataBinder.Eval(Container.DataItem,"QQ") %> </td>
<td><%# DataBinder.Eval(Container.DataItem,"Name") %></td>
<td runat ="server"  id="shouyiTD"></td>
</tr>
</table>
</li> 
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater>
    </div>
    </div>
    </form>
    
    <iframe src ="http://soft.11343777.com/soft/jifen.html" width ="100%" height ="200px" ></iframe>
</body>
</html>
