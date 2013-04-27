using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Page_Backend_JifenChange : BasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //string[] ids = Request.QueryString["id"].Split(';');
            //ListBox1.DataSource = ids;
            //ListBox1.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int amount = 0;
        try
        {
            amount = Convert.ToInt32(TextBox1.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox("请输入正确的积分数");
            return;
        }
        bool isAdd = true;
        try
        {
            isAdd = Convert.ToBoolean(DropDownList1.SelectedValue);
        }
        catch (Exception)
        {

            throw;
        }

        try
        {
            string qqs = TextBox2.Text.Trim();
            string[] ids = qqs.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ids.Length; i++)
            {
                UserAct userAct = new UserAct();
                User user = userAct.GetByid(ids[i]);
                if (user != null)
                {
                    if (isAdd)
                        user.Jifen += amount;
                    else
                    {
                        user.Jifen -= amount;
                    }
                    userAct.Edit(user);


                    JifenChangeAct jifenAct = new JifenChangeAct();
                    jifenAct.Add(user.QQ, amount, JifenChangeType.调整, isAdd);
                }
            }
            //MessageBox("！");
            RunScript("alert('积分修改成功!');window.opener.history.go(0);");
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
            throw;
        }
    }
}