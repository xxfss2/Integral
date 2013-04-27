using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class ManagerUserAct
    {
        private Accessbase _DBbase = new Accessbase();

        public bool Login(string loginName, string loginPassWord,ref ManagerUser user)
        {
            user = this.Get(loginName, loginPassWord);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public void Add(string username, string password, int RoleId)
        {
            string sql = "insert into T_MangerUser ([UserName],[Password],[RoleId]) values ('" + username + "','" + password + "'," + RoleId + ")";
            _DBbase.ExecuteCommand(sql);
        }

        public ManagerUser GetByid(string qq)
        {
            string str = "select * from T_MangerUser where id=" + qq + "";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public ManagerUser GetByName(string name)
        {
            string str = "select * from T_MangerUser where UserName='" + name + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public void Edit(ManagerUser user)
        {
            string str = "update T_MangerUser set [UserName]='" + user.UserName + "',[Password]=" + user.Password + " where [Id]=" + user.Id + "";

            _DBbase.ExecuteCommand(str);
        }

        private ManagerUser Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_MangerUser where UserName='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<ManagerUser> GetAll()
        {
            string str = "select * from T_MangerUser ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<ManagerUser> users = new List<ManagerUser>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }
        private ManagerUser GetEntity(DataRow dr)
        {
            ManagerUser user = new ManagerUser();
         //   user.Id = Convert.ToInt32(dr["Id"]);
         //   user.QQ  = dr["QQ"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.Id = (int)dr["Id"];
            user.UserName = dr["UserName"].ToString();
            user.Password = dr["Password"].ToString();
            user.RoleId = (int)dr["RoleId"];
            return user;
        }
    }
}
