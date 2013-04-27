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


public partial class Pages_Backend_UserManageChongzhiRecard : UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChongzhiRecardAct userAct = new ChongzhiRecardAct();
            Ruserlist.DataSource = userAct.GetAll();
            Ruserlist.DataBind();
        }
    }
}
