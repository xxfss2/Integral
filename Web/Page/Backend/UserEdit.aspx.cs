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


public partial class Pages_Backend_UserManage_UserEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LimitAct limitAc=new LimitAct ();

            dropLimit .DataSource =limitAc .GetAll ();
            dropLimit .DataTextField ="Name";
            dropLimit .DataValueField ="Id";
            dropLimit .DataBind ();
            if (Request.QueryString["id"] != null)
            {
                UserAct act = new UserAct();
                User user = act.GetByid(Request.QueryString["id"]);
                Literal1.Text = user.QQ ;
                Literal2.Text = user.LoginPassWord ;
                txtJifen.Text = user.Jifen.ToString() ;
                txtShouyi.Text = user.Shouyi.ToString();
                dropLimit.SelectedValue = user.Limit.ToString();
                dropCanuse.SelectedValue = user.CanLogin.ToString();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            UserAct act = new UserAct();
            User user = act.GetByid(Request.QueryString["id"]);
            int oldJifen = user.Jifen;

            user.Limit = Convert.ToInt32(dropLimit.SelectedValue);
            user.Jifen = Convert.ToInt32(txtJifen.Text.Trim());
            user.Shouyi = Convert.ToInt32(txtShouyi.Text.Trim());
            user.CanLogin = Convert.ToBoolean(dropCanuse.SelectedValue);
            try
            {
                act.Edit(user);
                JifenChangeAct changAct = new JifenChangeAct();
                int amount= Math.Abs(oldJifen -user.Jifen );
                changAct .Add (user.QQ ,amount ,JifenChangeType.调整 , user .Jifen >oldJifen );
                RunScript("alert('修改成功!');window.opener.history.go(0);");
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message);
            }
        }

    }
}
