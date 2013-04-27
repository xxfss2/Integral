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


public partial class Pages_Backend_UserManage_LimitAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CommonAct act = new CommonAct();
            Common lim = act.GetAll();
            txtuserintegral.Text = lim.NewUserIntegral.ToString();
            txtBeituijianren.Text = lim.BeiTuijianInteral.ToString();
            txtTuijianren.Text = lim.TuijianIntegral.ToString();
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int userintegral = 0;
        try
        {
            userintegral = Convert.ToInt32(txtuserintegral.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的数字！");
            return;
        }
        int tuijianren = 0;
        try
        {
            tuijianren = Convert.ToInt32(txtTuijianren.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的数字！");
            return;
        }

        int beituijiaren = 0;
        try
        {
            beituijiaren = Convert.ToInt32(txtBeituijianren.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的数字！");
            return;
        }

        CommonAct act = new CommonAct();
        try
        {
            Common com = new Common();
            com.BeiTuijianInteral = beituijiaren;
            com.NewUserIntegral = userintegral;
            com.TuijianIntegral = tuijianren;
            act.Edit(com);
                //RunScript("alert('添加成功!');window.opener.history.go(0);");

            MessageBox("修改成功!");
        }
        catch (Exception ex)
        {

            MessageBox(ex.Message);
        }


    }
}
