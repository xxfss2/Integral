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


public partial class Pages_Backend_UserManage_Limit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MovieAct userAct = new MovieAct();
            Ruserlist.DataSource = userAct.GetAll ();
            Ruserlist.DataBind();
        }
    }
    protected void BTadd0_Click(object sender, EventArgs e)
    {
        string ids= HiddenField1.Value;
        try
        {
            MovieAct act = new MovieAct();
            act.Del(ids);
            MessageBox("删除成功！");
            Ruserlist.DataSource = act.GetAll();
            Ruserlist.DataBind();
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }

    }
}
