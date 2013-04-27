using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using integral.Action;


public partial class Pages_Backend_UserManage_CashKa :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CashKaAct userAct = new CashKaAct();
            if (Request.QueryString["id"] != null)
            {
                userAct.Del(Request.QueryString["id"]);
                MessageBox("删除成功！");
            }
            Ruserlist.DataSource = userAct.GetAll ();
            Ruserlist.DataBind();
        }
    }
    protected void BTadd_Click(object sender, EventArgs e)
    {
        int cash = 0;
        try
        {
            cash = Convert.ToInt32(TextBox1.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请填写正确的面值"); 
            return;
        }
        int amount = 0;
        try
        {
            amount = Convert.ToInt32(TextBox2.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请填写正确的数量");
            return;
        }
        CashKaAct cashAct = new CashKaAct();
        string result=null ;
        try
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < amount; i++)
            {
                byte [] bytes=new byte [5];
                r.NextBytes (bytes );
                string no = bytes[0].ToString() + bytes[1].ToString() + bytes[2].ToString() + bytes[3].ToString() + bytes[4].ToString();
                cashAct.Add(no, cash);
                result += no + "\r\n";
            }

        }

        catch (Exception ex)
        {
            MessageBox(ex.Message);
            return;
        }
        Response.Clear();
        Response.Buffer = false;
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment;filename=Chonghzika.txt;");

        // 读取数据库，循环

            Response.Write(result);

        Response.Flush();
        Response.End();
    }
}
