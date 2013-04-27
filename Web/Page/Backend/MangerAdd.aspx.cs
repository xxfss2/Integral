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


public partial class Pages_Backend_UserManage_MangerAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {

                ManagerUserAct act = new ManagerUserAct();
                ManagerUser user = act.GetByid(Request.QueryString["id"]);
                txtName.Text = user.UserName;
                txtPassword.Text = user.Password;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
 
        string password = txtPassword.Text.Trim();

        ManagerUserAct act = new ManagerUserAct();
        if (act.GetByName(name) != null)
        {
            MessageBox("该账户名称已经存在！");
            return;
        }
        try
        {
            if (Request.QueryString["id"] != null)
            {
                ManagerUser user = act.GetByid(Request.QueryString["id"]);
                user.UserName = name;
                user.Password = password;
                act.Edit(user);
                RunScript("alert('修改成功!');window.opener.history.go(0);");
            }
            else
            {
                act.Add(name, password,(int)ManagerRole.普通管理员  );
                RunScript("alert('添加成功!');window.opener.history.go(0);");
            }

        }
        catch (Exception ex)
        {

            MessageBox(ex.Message);
        }


    }
}
