using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Video_vp : UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["idd"] != null)
        {
            UserAct userAct = new UserAct();
            User user = userAct.GetByid(Request.QueryString["idd"]);
            if (user == null || user.LoginPassWord != Request.QueryString["pw"])
            {
                MessageBox("请先登录后观看视频");
              
               return;
            }
            LimitAct limitAct = new LimitAct();
            Limit limit = limitAct.GetByid(user.Limit.ToString ());
            if (limit.URL == "vip.html")
                video.Visible = true;
            else
                video.Visible = false;
        }

    }
}