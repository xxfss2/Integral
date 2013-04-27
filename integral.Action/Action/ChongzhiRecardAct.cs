using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class ChongzhiRecardAct
    {
        private Accessbase _DBbase = new Accessbase();

        public void Add(string qq, string chongzhika)
        {
            string sql = "insert into T_ChongzhiRecard ([Chongzhika],[QQ],[CreatedAt]) values ('" + chongzhika + "','" + qq + "','" + DateTime .Now.ToString ()  + "')";
            _DBbase.ExecuteCommand(sql);
        }


        public ChongzhiRecard GetByid(string qq)
        {
            string str = "select * from T_ChongzhiRecard where QQ='" + qq + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public ChongzhiRecard GetByQQAndChongzhika(string qq,string chongzhika)
        {
            string str = "select * from T_ChongzhiRecard where QQ='" + qq + "' and Chongzhika='"+chongzhika+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        //public void Edit(ChongzhiRecard user)
        //{
        //    string str = "update T_User set [Password]='" + user.LoginPassWord + "',[Jifen]="+user.Jifen+" where [QQ]='"+user.QQ+"'";

        //    _DBbase.ExecuteCommand(str);
        //}

        private ChongzhiRecard Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_User where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<ChongzhiRecard> GetAll()
        {
            string str = "select * from T_ChongzhiRecard ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<ChongzhiRecard> users = new List<ChongzhiRecard>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }
        private ChongzhiRecard GetEntity(DataRow dr)
        {
            ChongzhiRecard user = new ChongzhiRecard();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.QQ  = dr["QQ"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.Chongzhika = dr["Chongzhika"].ToString();
            user.QQ = dr["QQ"].ToString();
        //    user.RoleId = Convert.ToInt32(dr["RoleId"]);
         //   user.BoolUse = Convert.ToBoolean(dr["BoolUse"]);
            user.Id  = (int)dr["Id"];
            user.CreatedAt =(DateTime )dr["CreatedAt"];
            return user;
        }
    }
}
