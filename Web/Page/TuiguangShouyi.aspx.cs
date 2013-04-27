using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using integral.Action;
using System.Data;
public partial class TuiguangShouyi : UserBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idd"] != null)
        {
            string userQQ=Request.QueryString["idd"];
            UserAct ac=new UserAct ();
            User user = ac.GetByid(userQQ);
            if (user == null)
                return;
            System .Data .DataTable dt=ac.TuijianrenSelect(userQQ);
           Ruserlist.DataSource = dt;
           Ruserlist.DataBind();

            lTuijian .Text =dt.Rows .Count.ToString ();

            JifenChangeAct changAct=new JifenChangeAct ();
            lLevel .Text =changAct .GetByQQ (userQQ).Where (s=>s.Type ==JifenChangeType .被推荐人升级奖励 ).Sum (s=>s.Amount ).ToString ();
            lJifen .Text =user .Shouyi.ToString () ;

            changes = changAct.GetByQQAndType(userQQ, JifenChangeType.被推荐人升级奖励);
        }
    }
    ICollection<JifenChange> changes;
    protected void Ruserlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem == null)
            return;
        DataRow dr = e.Item.DataItem as DataRow;
        string qq = dr["QQ"].ToString();
        HtmlTableCell td = e.Item.FindControl("shouyiTD") as HtmlTableCell;
        td.InnerText = changes.Where(s => s.FromQQ == qq).Sum(s => s.Amount).ToString();
    }
}