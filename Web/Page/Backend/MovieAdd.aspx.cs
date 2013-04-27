using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Page_Backend_MovieAdd : BasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //string[] ids = Request.QueryString["id"].Split(';');
            //ListBox1.DataSource = ids;
            //ListBox1.DataBind();
            txtDay.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DateTime firstDay;
        try
        {
            firstDay = Convert.ToDateTime(txtDay.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的日期");
            return;
        }

        try
        {
            string qqs = TextBox2.Text.Trim();
            string[] ids = qqs.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ids.Length; i++)
            {
                MovieAct userAct = new MovieAct();
                string[] xx = ids[i].Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                if (xx.Length != 2)
                {
                    MessageBox("视频导入格式不正确！");
                    return;
                }
                string name = xx[0];
                string url = xx[1];
                userAct.Add(name, url, firstDay.AddDays(i).ToString());

            }
            //MessageBox("！");
            RunScript("alert('视频导入成功!');window.opener.history.go(0);");
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
            throw;
        }
    }
}