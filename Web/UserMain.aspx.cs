using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class UserMain : UserBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null )
        {
            UserAct ac=new UserAct ();
            User user = ac.GetByid(Request.QueryString["idd"]);
            if (user == null)
                return;
            lQQ.Text = user.QQ;
            LimitAct limitAct=new LimitAct ();
            ICollection<Limit> limits = limitAct.GetAll();
            lLevel.Text = limits.Where(s => s.Id == user.Limit).First().Name;

            Limit next = limits.Where(s => s.Integral > user.Jifen).OrderBy(s => s.Integral).FirstOrDefault();
     

            lJifen.Text = user.Jifen.ToString ();

            JifenChangeAct changeAct=new JifenChangeAct ();

            List<JifenChange > changs=changeAct.Select(user.QQ);
            int xiaofei =0;
            if(changs .Count >0 )
                xiaofei = changs.Where(s => s.Type == JifenChangeType.消费).Sum(s => s.Amount);
            Literal5.Text = xiaofei.ToString ();
            Literal4.Text = next == null ? "0" : (next.Integral - (user.Jifen+xiaofei)).ToString();
            lJifenTotal.Text = (user.Jifen + xiaofei).ToString();
        }
    }
}