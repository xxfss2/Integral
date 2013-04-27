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


public partial class Pages_Backend_UserManage_User : UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserAct userAct = new UserAct();
            Ruserlist.DataSource = userAct.Select(null );
            Ruserlist.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserAct userAct = new UserAct();
        Ruserlist.DataSource = userAct.Select(TextBox1 .Text .Trim ());
        Ruserlist.DataBind();
    }
}
