using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class MovieAct
    {
        private Accessbase _DBbase = new Accessbase();

        public void Add(string name, string url, string playDay)
        {
            string sql = "insert into T_Movie ([Name],[URL],[CreatedAt],[PlayDay]) values ('" + name + "','" + url + "','" + DateTime .Now + "','" +playDay+ "')";
            _DBbase.ExecuteCommand(sql);
        }

        //public void ChangeJifen(string qq, int amount, bool isAdd)
        //{
        //    User user = this.GetByid(qq);

        //}

        public Movie GetByid(string qq)
        {
            string str = "select * from T_Movie where Id=" + qq + "";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public Movie GetTodayMovie()
        {
          //  string today = DateTime.No
            string sql = "select * from T_Movie where datediff('d',PlayDay,#"+DateTime .Now+"#)=0";
            DataTable dt = _DBbase.ExeSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public Movie GetNextdayMovie()
        {
            DateTime next = DateTime.Now.AddDays(1);
            //  string today = DateTime.No
            string sql = "select * from T_Movie where datediff('d',PlayDay,#" + next + "#)=0";
            DataTable dt = _DBbase.ExeSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public List<Movie> GetOldMovies()
        {
            DateTime next = DateTime.Now;
            //  string today = DateTime.No
            string sql = "select * from T_Movie where PlayDay < #" + next + "#";
            DataTable dt = _DBbase.ExeSelect(sql);
            List<Movie> users = new List<Movie>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }


        public void Del(string ids)
        {
            string sql = "delete from T_Movie where id in("+ids+") ";
            _DBbase.ExecuteCommand(sql);
        }

        public void Edit(Movie user)
        {
         //  string str = "update T_User set [Password]='" + user.LoginPassWord + "',[Jifen]="+user.Jifen+" where [QQ]='"+user.QQ+"'";

          //  _DBbase.ExecuteCommand(str);
        }

        private Movie Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_User where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }


        public List<Movie> GetAll()
        {
            string str = "select * from T_Movie ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<Movie> users = new List<Movie>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }

        public DataTable Select()
        {
            string str = "select QQ,Password,TuijianrenQQ,Jifen,CreatedAt,Name from T_User inner join T_Limit on T_User.Limit=T_Limit.Id";
            DataTable dt = _DBbase.ExeSelect(str);
            return dt;
        }


        private Movie GetEntity(DataRow dr)
        {
            Movie user = new Movie();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.Id   =(int) dr["Id"];
            user.Name = dr["Name"].ToString();
            user.URL = dr["URL"].ToString();
            user.PlayDay = (DateTime)dr["PlayDay"];
            user.CreatedAt =(DateTime )dr["CreatedAt"];

            return user;
        }
    }
}
