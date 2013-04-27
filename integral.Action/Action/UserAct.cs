using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class UserAct
    {
        private Accessbase _DBbase = new Accessbase();

        public bool Login(string loginName, string loginPassWord,User user)
        {
            user = this.Get(loginName, loginPassWord);
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public void Add(string qq, string password, string tuijianrenQQ,string mac)
        {
            int amount = MyCache .GetCommon .NewUserIntegral;
            if (tuijianrenQQ.Length > 0)
            {
                amount += MyCache.GetCommon.BeiTuijianInteral ;
            }
            string sql = "insert into T_User ([QQ],[Password],[TuijianrenQQ],[Jifen],[CreatedAt],[CanLogin],[Shouyi],[Mac]) values ('" + qq + "','" + password + "','" + tuijianrenQQ + "'," + amount + ",'" + DateTime.Now + "',true,0,'"+mac+"')";
            _DBbase.ExecuteCommand(sql);
        }

        public void ChangeJifen(string qq, int amount, bool isAdd)
        {
            User user = this.GetByid(qq);

        }

        public User GetByid(string qq)
        {
            string str = "select * from T_user where QQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public User GetByMac(string mac)
        {
            string str = "select * from T_user where Mac='" + mac + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public void Edit(User user)
        {
            string str = "update T_User set [Password]='" + user.LoginPassWord + "',[Jifen]=" + user.Jifen + ",[CanLogin]=" + user.CanLogin + ",[Shouyi]="+user.Shouyi+" where [QQ]='" + user.QQ + "'";

            _DBbase.ExecuteCommand(str);
        }

        private User Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_User where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<User> GetAll()
        {
            string str = "select * from T_User ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<User> users = new List<User>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }

        public DataTable Select(string qq)
        {
            string str = "select QQ,Password,TuijianrenQQ,Jifen,CreatedAt,CanLogin,Name,Shouyi from T_User inner join T_Limit on T_User.Limit=T_Limit.Id";
            if (string.IsNullOrEmpty(qq) == false)
            {
                str += " where QQ='"+qq+"'";
            }
            DataTable dt = _DBbase.ExeSelect(str);
            return dt;
        }
        public DataTable TuijianrenSelect(string qq)
        {
            string str = "select QQ,Password,TuijianrenQQ,Jifen,CreatedAt,CanLogin,Name,Shouyi from T_User inner join T_Limit on T_User.Limit=T_Limit.Id";
            if (string.IsNullOrEmpty(qq) == false)
            {
                str += " where TuijianrenQQ='" + qq + "'";
            }
            DataTable dt = _DBbase.ExeSelect(str);
            return dt;
        }

        private User GetEntity(DataRow dr)
        {
            User user = new User();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.QQ  = dr["QQ"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.LoginPassWord = dr["Password"].ToString();
            user.TuijianrenQQ = dr["TuijianrenQQ"].ToString();
        //    user.RoleId = Convert.ToInt32(dr["RoleId"]);
         //   user.BoolUse = Convert.ToBoolean(dr["BoolUse"]);
            user.Jifen = (int)dr["Jifen"];
            user.CreatedAt =(DateTime )dr["CreatedAt"];
            user.Limit =(int)dr["Limit"];
            user.CanLogin = (bool)dr["CanLogin"];
            user.Shouyi = (int)dr["Shouyi"];
            user.Mac =dr["Mac"].ToString ();
            return user;
        }
    }
}
