using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class ChongzhiKaAct
    {
        private Accessbase _DBbase = new Accessbase();

        public void Add(string number)
        {
            string sql = "insert into T_ChongzhiKa ([Number],[CreatedAt]) values ('" + number + "','" + DateTime .Now + "')";
            _DBbase.ExecuteCommand(sql);
        }

        public void ChangeJifen(string qq, int amount, bool isAdd)
        {
            ChongzhiKa user = this.GetByid(qq);

        }

        public ChongzhiKa GetNew()
        {
            string str = "select top 1 * from T_ChongzhiKa order by CreatedAt desc ";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public ChongzhiKa GetByid(string qq)
        {
            string str = "select * from T_ChongzhiKa where Number='" + qq + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        private ChongzhiKa Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_ChongzhiKa where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<ChongzhiKa> GetAll()
        {
            string str = "select * from T_ChongzhiKa ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<ChongzhiKa> users = new List<ChongzhiKa>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }
        private ChongzhiKa GetEntity(DataRow dr)
        {
            ChongzhiKa user = new ChongzhiKa();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.Number = dr["Number"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.CreatedAt =(DateTime) dr["CreatedAt"];
         //   user.TuijianrenQQ = dr["TuijianrenQQ"].ToString();
        //    user.RoleId = Convert.ToInt32(dr["RoleId"]);
         //   user.BoolUse = Convert.ToBoolean(dr["BoolUse"]);
          //  user.Jifen = (int)dr["Jifen"];
            return user;
        }
    }
}
