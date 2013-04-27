using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
	public BasePage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    protected override void OnLoad(EventArgs e)
    {
        if (HttpContext.Current.Session["mangerid"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        base.OnLoad(e);
    }

    public void MessageBox(string msg)
    {
        this.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('"+msg+"');", true);
    }

    public void RunScript(string sript)
    {
        this.ClientScript.RegisterStartupScript(GetType(), "stript", sript, true);
    }
}