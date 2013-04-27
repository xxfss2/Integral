using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Page_Chongzhi : UserBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BTsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null)
        {
            string qq = Request.QueryString["idd"];
            ChongzhiRecardAct act = new ChongzhiRecardAct();
            ChongzhiKaAct kaAct = new ChongzhiKaAct();
            string ka = txtChongzhika.Text.Trim();
            ChongzhiKa chongzhika = kaAct.GetNew();
            if (chongzhika.Number != ka)
            {
                MessageBox("充值卡有误！请重新输入");
                return;
            }
            ChongzhiRecard recard = act.GetByQQAndChongzhika(qq, ka);
            if (recard != null)
            {
                MessageBox("您的账户已经用该充值卡充过值了！无法重复充值！");
                return;
            }
            try
            {
                act.Add(qq, ka);
                UserAct userAct = new UserAct();
                User user = userAct.GetByid(qq);
                user.Jifen++;
                userAct.Edit(user);
                JifenChangeAct jifenAct = new JifenChangeAct();
                jifenAct.Add(qq, 1, JifenChangeType.优惠, true);
                MessageBox("充值成功！");
            }
            catch (Exception ex)
            {

                MessageBox(ex.Message);
            }
        }
  
    }
}