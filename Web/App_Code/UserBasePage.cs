using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class UserBasePage : System.Web.UI.Page
{
    public UserBasePage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        this.ClientScript.RegisterStartupScript(GetType(), "sdfsfd", "document.oncontextmenu=new Function('event.returnValue=false;');document.onselectstart=new Function('event.returnValue=false;');", true);
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