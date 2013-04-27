using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Page_Backend_ChongzhiKa : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChongzhiKaAct chongAct = new ChongzhiKaAct();
            ChongzhiKa ka = chongAct.GetNew();
            if (ka != null)
            {
                TextBox1.Text = ka.Number;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChongzhiKaAct chongAct = new ChongzhiKaAct();
        ChongzhiKa ka = chongAct.GetNew();
        if (TextBox1.Text.Trim().Length == 0)
        {
            MessageBox("请输入充值卡号");
            return;
        }
        if (ka != null && ka.Number == TextBox1.Text.Trim())
        {
            MessageBox("充值卡号没有变化！");
            return;
        }

        try
        {
            chongAct.Add(TextBox1.Text.Trim());
            MessageBox("修改成功！");
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }


    }
}