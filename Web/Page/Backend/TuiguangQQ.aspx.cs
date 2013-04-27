using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using integral.Action;
using System.IO;


public partial class Pages_Backend_UserManage_TuiguangQQ : BasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TuiguangQQAct userAct = new TuiguangQQAct();
            Ruserlist.DataSource = userAct.GetAll ();
            Ruserlist.DataBind();

          //  txtDay1.Text = DateTime.Now.ToShortDateString();
           // txtDay2.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void BTadd_Click(object sender, EventArgs e)
    {
        TuiguangQQAct act = new TuiguangQQAct();
        //DateTime day1=DateTime .Now  ;
        //DateTime day2=DateTime .Now ;
        //try
        //{
        //    day1 = Convert.ToDateTime(txtDay1.Text.Trim());
        //    day2 = Convert.ToDateTime(txtDay2.Text.Trim());
        //}
        //catch (Exception ex)
        //{
        //    MessageBox("请输入正确的时间!");
        //}
        ICollection<TuiguangQQ> qqs = act.Select();
        Response.Clear();
        Response.Buffer = false;
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment;filename=qq.txt;");

        // 读取数据库，循环
        foreach (var item in qqs)
        {
            Response.Write(item.UserQQ + "----"+item .Tuiguang +"\r\n");
        }


        Response.Flush();
        Response.End();


    }
}
