using System;
using System.Collections.Generic;
using System.Text;
using System .Web .Caching;
using System.Web;
namespace integral.Action
{
    public class MyCache
    {
        public static Common GetCommon
        {
            get
            {
                if (HttpContext.Current.Cache["commondate"] == null)
                {
                    CommonAct act = new CommonAct();
                    Common com = act.GetAll();
                    HttpContext.Current.Cache["commondate"] = com;
                    return com;
                }
                else
                {
                    return (Common)HttpContext.Current.Cache["commondate"];
                }
            }
        }

        public static IList<string> WatchedUser
        {
            get
            {
                if (HttpContext.Current.Cache["moviesUser"] == null)
                {
                    IList<string> users = new List<string>();
                    DateTime now =DateTime .Now ;
                    HttpContext.Current.Cache.Insert("moviesUser", users, null, new DateTime(now.Year, now.Month, now.Day, 23, 58, 0), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
                    return users;
                }
                else
                {
                    return (IList<string>)HttpContext.Current.Cache["moviesUser"];
                }
            }
            set
            {
                HttpContext.Current.Cache["moviesUser"] = value;
            }
        }
    }
}
