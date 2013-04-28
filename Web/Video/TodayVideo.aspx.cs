using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using integral.Action;
public partial class Video_TodayVideo : UserBasePage
{
    UserAct userAct = new UserAct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MovieAct movAct = new MovieAct();
            rep1.DataSource = movAct.GetOldMovies().OrderByDescending(s => s.PlayDay);
            rep1.DataBind();
            if (Request.QueryString["idd"] == null)
            {
                //MessageBox("请先登录后观看视频");
                return;
            }
            User user = userAct.GetByid(Request.QueryString["idd"]);
            if (user == null || user.LoginPassWord != Request.QueryString["pw"])
            {
                //MessageBox("请先登录后观看视频");
                return;
            }
          
            Movie todayMovie = movAct.GetTodayMovie();
            Movie nextMoive = movAct.GetNextdayMovie();
            if (nextMoive != null)
            {
                Literal2.Text = nextMoive.Name;
                Literal4.Text = nextMoive.Name;
            }
            if (todayMovie == null)
            {
                MessageBox("今天没有可看的最新视频，请联系我们！");
                return;
            }
            ImageButton1.Visible = true;
            Literal1.Text = todayMovie.Name;
            Literal3.Text = todayMovie.Name;



            LimitAct limitAct = new LimitAct();
            Limit limit = limitAct.GetByid(user.Limit.ToString());
            if (limit.NeedIntegral)
            {
                if (limit.CanRepeater == false)
                {
                    ImageButton1.Attributes.Add("onclick", "return confirm('确认观看教学视频？确认观看将扣除你一个积分！');");
                }
                else
                {
                    IList<string> Watcheduser = MyCache.WatchedUser;
                    if (Watcheduser.Contains(user.QQ) == false)
                    {
                        ImageButton1.Attributes.Add("onclick", "return confirm('确认观看教学视频？确认观看将扣除你一个积分！');");
                    }
                }
            }
        }


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
 
        User user = userAct.GetByid(Request.QueryString["idd"]);

        LimitAct limitAct = new LimitAct();
        Limit limit = limitAct.GetByid(user.Limit.ToString());

        MovieAct movAct = new MovieAct();
        Movie todayMovie = movAct.GetTodayMovie();

        //是否需要积分观看
        if (limit.NeedIntegral == false)
        {
            StartVideo(todayMovie.URL);
            return;
        }
        else
        {
            if (limit.CanRepeater == false)
            {
                if (user.Jifen < 1)
                {
                    MessageBox("您的积分不够了，请及时充值！");
                    return;
                }
                RedureJifen(user);
                StartVideo(todayMovie.URL);
                return;
            }
            else
            {
                IList<string> Watcheduser = MyCache.WatchedUser;
                if (Watcheduser.Contains(user.QQ))
                {
                    StartVideo(todayMovie.URL);
                    return;
                }
                else
                {
                    if (user.Jifen < 1)
                    {
                        MessageBox("您的积分不够了，请及时充值！");
                        return;
                    }
                    RedureJifen(user);
                    StartVideo(todayMovie.URL);
                    Watcheduser.Add(user.QQ);
                    MyCache.WatchedUser = Watcheduser;

                    return;
                }
            }
        }
    }

    private void StartVideo(string url)
    {
        divVideo.InnerHtml = RenderVedio(url);
        ImageButton1.Visible = false;
    }

    private void RedureJifen(User user)
    {
        JifenChangeAct changeAct = new JifenChangeAct();
        changeAct.Add(user.QQ, 1, JifenChangeType.消费, false);
        user.Jifen--;
        userAct.Edit(user);
    }

    private string RenderVedio(string todayURL)
    {
        string strVideo=null ;
        strVideo +="<object class=\"class\" id=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"320\" height=\"240\">";
        strVideo +="<param name=\"movie\" value=\"http://soft.11343777.com/soft/Flvplayer.swf\" />";
        strVideo +="<param name=\"quality\" value=\"high\" />";
        strVideo +="<param name=\"allowFullScreen\" value=\"true\" />";
        strVideo +="<param name=\"FlashVars\" value=\"vcastr_file="+todayURL+"&LogoText=QQ 11343777&BufferTime=3&IsAutoPlay=1\" />";
        strVideo +="<embed src=\"http://soft.11343777.com/soft/Flvplayer.swf\" allowfullscreen=\"true\" flashvars=\"vcastr_file="+todayURL+"&LogoText=QQ 11343777&IsAutoPlay=1\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"320\" height=\"240\"></embed></object>";

        return strVideo;
    
    }
}