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
            if (Request.QueryString["id"] != null)
            {
                LimitAct act = new LimitAct();
                Limit lim = act.GetByid(Request.QueryString["id"]);
                txtName.Text = lim.Name;
                txtIntegral.Text = lim.Integral.ToString();
                txtURL.Text = lim.URL;
                dropCanrepeter.SelectedIndex = lim.CanRepeater ? 0 : 1;
                dropNeedIntegral.SelectedIndex = lim.NeedIntegral ? 0 : 1;
                txtshengjijiangli.Text = lim.ShengjiJiangli.ToString();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        int integral = 0;
        try
        {
            integral = Convert.ToInt32(txtIntegral.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的数字！");
            return;
        }
        string url = txtURL.Text.Trim();
        bool canRepeter =Convert .ToBoolean ( dropCanrepeter .SelectedValue) ;
        bool needintegral = Convert.ToBoolean(dropNeedIntegral.SelectedValue);
        int shengjijiangli = 0;
        try
        {
            shengjijiangli = Convert.ToInt32(txtshengjijiangli .Text .Trim ());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的数字！");
            return;
        }
        LimitAct act = new LimitAct();
        try
        {
            if (Request.QueryString["id"] != null)
            {
                Limit lit = act.GetByid(Request.QueryString["id"]);
                lit.Name = name;
                lit.Integral = integral;
                lit.NeedIntegral = needintegral;
                lit.CanRepeater = canRepeter;
                lit.URL = url;
                act.Edit(lit);
                RunScript("alert('修改成功!');window.opener.history.go(0);");
            }
            else
            {
                act.Add(name, url, canRepeter, needintegral, integral,shengjijiangli);
                RunScript("alert('添加成功!');window.opener.history.go(0);");
            }

        }
        catch (Exception ex)
        {

            MessageBox(ex.Message);
        }


    }
}
