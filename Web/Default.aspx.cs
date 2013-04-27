using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using integral.Action;
public partial class Login :UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BTsubmit_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.Trim().Length == 0)
        {
            MessageBox("请输入用户名！");
            return;

        }

        if (txtPassword.Text.Length == 0)
        {
            MessageBox("请输入密码！");
        }
        string username=txtUsername .Text .Trim ();
        string password=txtPassword .Text;
        LoginAction act = new LoginAction();
        User user = new User();
        if (act.UserLogin(username, password))
        {            
            UserAct userAct = new UserAct();
            user = userAct.GetByid(username);
            if (user.CanLogin == false)
            {
               // MessageBox("！");
                Response.Write("0该用户已经被禁用!");
                Response.End();
                return;
            }
            //等级调整
            if (string.IsNullOrEmpty(user.TuijianrenQQ) == false)
            {
                LimitAct limitAct = new LimitAct();
                ICollection<Limit> limits = limitAct.GetAll().OrderBy(s => s.Integral).ToList();
                Limit userLimit = limits.Where(s => s.Id == user.Limit).FirstOrDefault();
                int oldLimit = user.Limit;
                int jiangli=0;
                foreach (var item in limits)
                {
                    if (user.Jifen > item.Integral && item .Integral >userLimit .Integral )
                    {
                        user.Limit = item.Id;
                        jiangli =item .ShengjiJiangli ;
                    }
                }
                if (oldLimit != user.Limit)
                {
                    JifenChangeAct changeAct = new JifenChangeAct();
                    User tuijianren=userAct.GetByid(user.TuijianrenQQ);
                    int hasJiangli = changeAct.Select(tuijianren.QQ).Where (s=>s.Type ==JifenChangeType .被推荐人升级奖励 && s.FromQQ ==user.QQ ).Sum (s=>s.Amount ) ;
                    tuijianren.Jifen += (jiangli-hasJiangli );
                    try
                    {
                        userAct.Edit(tuijianren);
                        userAct.Edit(user);

                        changeAct.Add(tuijianren.QQ, jiangli, JifenChangeType.被推荐人升级奖励, true,user .QQ);
                    }
                    catch (Exception ex)
                    {
                        MessageBox(ex.Message);
                    }
 
                }
            }
            Response.Cookies["jifenqq"].Value = "164981897";
            Response.Write("1登录成功!");
            Response.End();
         //   Response.Redirect("Page/TuiguangQQ.aspx");
        }
        else
        {
            //MessageBox("!");
            Response.Write("0用户名或密码错误!");
            Response.End();
        }

    }
}