using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Page_ChshKa : UserBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BTsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null)
        {
            string qq = Request.QueryString["idd"];
            CashKaAct kaAct = new CashKaAct();
            string ka = txtChongzhika.Text.Trim();
            CashKa chongzhika = kaAct.GetByNumber(ka);
            if (string .IsNullOrEmpty( chongzhika.QQ)==false )
            {
                MessageBox("充值卡已经被使用");
                return;
            }
            try
            {
                kaAct.Chongzhi(ka, qq);
                UserAct userAct = new UserAct();
                User user = userAct.GetByid(qq);
                user.Jifen+=chongzhika .Cash;
                userAct.Edit(user);
                JifenChangeAct jifenAct = new JifenChangeAct();
                jifenAct.Add(qq, chongzhika.Cash, JifenChangeType.充值, true);
                MessageBox("充值成功！");
            }
            catch (Exception ex)
            {

                MessageBox(ex.Message);
            }
        }
  
    }
}