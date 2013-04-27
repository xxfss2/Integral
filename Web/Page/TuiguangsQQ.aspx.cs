using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;

public partial class TuiguangsQQ : UserBasePage
{
    public string myqq;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null)
        {
            myqq = Request.QueryString["idd"];
        }
        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {
                TuiguangQQAct userAct = new TuiguangQQAct();
                userAct.Del(Request.QueryString["id"]);
                MessageBox("删除成功！");
            }
        }


    }

    protected override void OnPreRender(EventArgs e)
    {
        TuiguangQQAct userAct = new TuiguangQQAct();
        Ruserlist.DataSource = userAct.GetByUserQQ(Request.QueryString["idd"]);
        Ruserlist.DataBind();
        base.OnPreRender(e);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null)
        {
            string qq = Request.QueryString["idd"];
            TuiguangQQAct act = new TuiguangQQAct();
            if (act.GetByUserQQ(qq).Count >= MyCache.GetCommon.KuiguangQQ)
            {
                MessageBox("您上传的推广QQ数量已经达到上限，无法继续上传!");
                return;
            }
            if (TextBox1.Text.Trim().Length <= 5)
            {
                MessageBox("请输入正确的QQ号");
                return;
            }
            string tuiguang = TextBox1.Text.Trim();
            if (act.GetByTuiguangQQ(tuiguang) != null)
            {
                MessageBox("该QQ号码已经存在数据库中！");
                return;
            }
            try
            {
                act.Add(qq, TextBox1.Text.Trim());
                MessageBox("上传成功！");
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message);
            }
        }
    }
}