using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Register : UserBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BTsubmit_Click(object sender, EventArgs e)
    {
        if (txtQQNO.Text.Trim().Length == 0)
        {
            MessageBox("请输入QQ号码！");
            return;

        }
        try
        {
            Convert.ToInt32(txtQQNO.Text.Trim());
        }
        catch (Exception)
        {
            MessageBox("请输入QQ号码！");
            return;
        }

        if (txtPassword.Text.Length == 0)
        {
            MessageBox("请输入密码！");
            return;
        }
        if (txtPassword2.Text != txtPassword.Text )
        {
            MessageBox("密码重复不匹配！");
            return;
        }

        string qq=txtQQNO .Text .Trim ();
        string password=txtPassword .Text;
        string tuijianrenQQ=txtTuijian .Text .Trim ();
        string mac = txtMac.Text.Trim();
        if (mac.Length == 0)
        {
            Response.Write("0注册失败!");
            Response.End();
        }
        UserAct act = new UserAct();
        if (act.GetByid(qq) != null)
        {
            Response.Write("0该QQ号码已经被注册!");
            Response.End();
         //   return;
        }
        if (act.GetByMac(mac) != null)
        {
            //MessageBox("您已经注册，请勿重复注册！");
            Response.Write("0您已经注册，请勿重复注册！");
            Response.End();
         //   return;
        }
        if (!string.IsNullOrEmpty(tuijianrenQQ))
        {
            if (act.GetByid(tuijianrenQQ) == null)
            {
                Response.Write("0推荐人QQ号码不存在，请重新输入！");
                Response.End();
               // MessageBox("推荐人QQ号码不存在，请重新输入！");
               // return;
            }
        }
        try
        {
            act.Add(qq, password, tuijianrenQQ,mac);
            if (!string.IsNullOrEmpty(tuijianrenQQ))
            {
                JifenChangeAct changeAct = new JifenChangeAct();
                changeAct.Add(tuijianrenQQ, MyCache .GetCommon .TuijianIntegral, JifenChangeType.推荐 , true);
                User user = act.GetByid(tuijianrenQQ);
                //if (user == null)
                //{
                //    throw new NullReferenceException("qq号不存在");
                //}
                user.Jifen += MyCache.GetCommon.TuijianIntegral;
                act.Edit(user);
            }
            Response.Write("1恭喜你！账号注册成功，可立即登录观看！");

        }
        catch (Exception ex)
        {
            Response.Write("0" + ex.Message);
        }
        Response.End();


    }
}