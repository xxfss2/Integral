using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class TuiguangQQAct
    {
        private Accessbase _DBbase = new Accessbase();

        public void Add(string qq, string tuiguangqq)
        {
            string sql = "insert into T_TuiguangQQ ([UserQQ],[TuiguangQQ],[CreatedAt]) values ('" + qq + "','" + tuiguangqq + "','" + DateTime.Now + "')";
            _DBbase.ExecuteCommand(sql);
        }

        public void ChangeJifen(string qq, int amount, bool isAdd)
        {
            TuiguangQQ user = this.GetByid(qq);

        }
        public void Del(string idh)
        {
            string sql = "delete from T_TuiguangQQ where Id=" + idh;
            _DBbase.ExecuteCommand(sql);
        }
        public TuiguangQQ GetByid(string qq)
        {
            string str = "select * from T_user where QQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }


        public TuiguangQQ GetByTuiguangQQ(string qq)
        {
            string str = "select * from T_TuiguangQQ where TuiguangQQ='" + qq + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public void Edit(TuiguangQQ user)
        {
         //   string str = "update T_User set [Password]='" + user.LoginPassWord + "',[Jifen]="+user.Jifen+" where [QQ]='"+user.QQ+"'";

           // _DBbase.ExecuteCommand(str);
        }

        private TuiguangQQ Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_User where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<TuiguangQQ> GetAll()
        {
            string str = "select * from T_TuiguangQQ ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<TuiguangQQ> users = new List<TuiguangQQ>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }

        public List<TuiguangQQ> Select()
        {
         //   string str = "select * from T_TuiguangQQ where CreatedAt between #"+day1+"# and #"+day2+"#";
            string str = "select * from T_TuiguangQQ ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<TuiguangQQ> users = new List<TuiguangQQ>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }

        public List<TuiguangQQ> GetByUserQQ(string qq)
        {
            string str = "select * from T_TuiguangQQ where UserQQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            List<TuiguangQQ> users = new List<TuiguangQQ>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }


        private TuiguangQQ GetEntity(DataRow dr)
        {
            TuiguangQQ user = new TuiguangQQ();
            user.Id = (int)dr["Id"];
            user.UserQQ  = dr["UserQQ"].ToString();
            user.Tuiguang = dr["TuiguangQQ"].ToString();
            user.CreatedAt =(DateTime ) dr["CreatedAt"];
            return user;
        }
    }
}
