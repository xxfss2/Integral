using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class CashKaAct
    {
        private Accessbase _DBbase = new Accessbase();

        public void Add(string number, int cash)
        {
            string sql = "insert into T_CashKa ([Number],[Cash],[CreatedAt]) values ('" + number + "'," + cash + ",'" + DateTime.Now + "')";
            _DBbase.ExecuteCommand(sql);
        }

        public void Del(string idh)
        {
            string sql = "delete from T_CashKa where Id="+idh;
            _DBbase.ExecuteCommand(sql);
        }

        public void Chongzhi(string id,string qq)
        {
            string str = "update T_CashKa set [QQ]='" + qq + "' where [Number]='" + id + "'";

            _DBbase.ExecuteCommand(str);
        }

        public CashKa GetByNumber(string qq)
        {
            string str = "select * from T_CashKa where Number='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public CashKa GetByMac(string mac)
        {
            string str = "select * from T_CashKa where Mac='" + mac + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        //public void Edit(CashKa user)
        //{
        //    string str = "update T_CashKa set [Password]='" + user.LoginPassWord + "',[Jifen]=" + user.Jifen + ",[CanLogin]=" + user.CanLogin + ",[Shouyi]="+user.Shouyi+" where [QQ]='" + user.QQ + "'";

        //    _DBbase.ExecuteCommand(str);
        //}

        private CashKa Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_CashKa where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<CashKa> GetAll()
        {
            string str = "select * from T_CashKa ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<CashKa> users = new List<CashKa>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }

        public DataTable Select(string qq)
        {
            string str = "select QQ,Password,TuijianrenQQ,Jifen,CreatedAt,CanLogin,Name,Shouyi from T_CashKa inner join T_Limit on T_CashKa.Limit=T_Limit.Id";
            if (string.IsNullOrEmpty(qq) == false)
            {
                str += " where QQ='"+qq+"'";
            }
            DataTable dt = _DBbase.ExeSelect(str);
            return dt;
        }


        private CashKa GetEntity(DataRow dr)
        {
            CashKa user = new CashKa();
            user.Id = Convert.ToInt32(dr["Id"]);
            user.Number = (string)dr["Number"];
            user.QQ = dr["QQ"].ToString ();
            user.Cash = (int)dr["Cash"];
            user.CreatedAt =(DateTime )dr["CreatedAt"];

            return user;
        }
    }
}
