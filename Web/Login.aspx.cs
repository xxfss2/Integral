using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class BackLogin : UserBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BTsubmit_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.Trim().Length == 0)
        {
            MessageBox("请输入用户名！");
            return;

        }

        if (txtPassword.Text.Length == 0)
        {
            MessageBox("请输入密码！");
        }
        string username=txtUsername .Text .Trim ();
        string password=txtPassword .Text;
        ManagerUserAct act = new ManagerUserAct();
        ManagerUser user=new ManagerUser ();
        if (act.Login(username, password,ref user))
        {
            HttpContext.Current.Session["mangerid"] = user.Id;
            if(user.RoleId ==(int)ManagerRole .超级管理员 )
               Response.Redirect("Page/Frameset/frame.htm");
            else
            {
                Response.Redirect("Page/Frameset/frame2.htm");
            }
        }
        else
        {
            MessageBox("用户名或密码错误！");
        }

    }
}