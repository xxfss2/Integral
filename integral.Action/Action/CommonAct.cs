using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class CommonAct
    {
        private Accessbase _DBbase = new Accessbase();

        //public void Add(string qq, string password, string tuijianrenQQ)
        //{
        //    int amount = 1;
        //    if (tuijianrenQQ.Length > 0)
        //    {
        //        amount = 2;
        //    }
        //    string sql = "insert into T_Common ([QQ],[Password],[TuijianrenQQ],[Jifen]) values ('" + qq + "','" + password + "','" + tuijianrenQQ + "'," + amount + ")";
        //    _DBbase.ExecuteCommand(sql);
        //}

        public void ChangeJifen(string qq, int amount, bool isAdd)
        {
            Common Common = this.GetByid(qq);

        }

        public Common GetByid(string qq)
        {
            string str = "select * from T_Common where QQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public void Edit(Common user)
        {
            string str = "update T_Common set [BeiTuijianInteral]=" + user.BeiTuijianInteral + ",[NewUserIntegral]=" + user.NewUserIntegral + ",[TuijianIntegral]=" + user.TuijianIntegral + ",[KuiguangQQ]="+user.KuiguangQQ+" ";

            _DBbase.ExecuteCommand(str);
        }

        private Common Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_Common where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public Common GetAll()
        {
            string str = "select * from T_Common";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            } return null;
        }
        private Common GetEntity(DataRow dr)
        {
            Common user = new Common();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.BeiTuijianInteral = (int)dr["BeiTuijianInteral"];
            user.NewUserIntegral = (int)dr["NewUserIntegral"];
            user.TuijianIntegral = (int)dr["TuijianIntegral"];
            user.KuiguangQQ = (int)dr["KuiguangQQ"];
            return user;
        }
    }
}
