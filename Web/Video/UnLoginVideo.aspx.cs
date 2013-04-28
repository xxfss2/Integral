using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Video_UnLoginVideo : UserBasePage
{
    UserAct userAct = new UserAct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MovieAct movAct = new MovieAct();
            rep1.DataSource = movAct.GetOldMovies().OrderByDescending(s => s.PlayDay);
            rep1.DataBind();


            Movie todayMovie = movAct.GetTodayMovie();
            Movie nextMoive = movAct.GetNextdayMovie();
            if (nextMoive != null)
            {
                Literal2.Text = nextMoive.Name;
                Literal4.Text = nextMoive.Name;
            }
            if (todayMovie != null)
            {
                Literal1.Text = todayMovie.Name;
                Literal3.Text = todayMovie.Name;
            }
        }


    }
}