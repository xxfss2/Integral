using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Video_Main : UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] == null)
        {
            MessageBox("请先登录后观看视频");
            return;
        }
        

        UserAct userAct = new UserAct();
        User user = userAct.GetByid(Request.QueryString["idd"]);
        if (user == null || user.LoginPassWord != Request.QueryString["pw"])
        {
            MessageBox("请先登录后观看视频");

            return;
        }
        string qq = Request.QueryString["idd"].ToString();
        string password = Request.QueryString["pw"].ToString();
        LimitAct limitAct = new LimitAct();
        Limit limit = limitAct.GetByid(user.Limit.ToString());
        if (limit.URL == "vip.html")
            Response.Redirect("vp.aspx?idd="+qq+"&pw="+password);
        else
            Response.Redirect("TodayVideo.aspx?idd="+qq+"&pw="+password);

    }
}