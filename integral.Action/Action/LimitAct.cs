using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class LimitAct
    {
        private Accessbase _DBbase = new Accessbase();


        public void Add(string Name, string URL, bool  canRepeter,bool needIntegral,int inter,int shengjijiangli)
        {
            string sql = "insert into T_Limit ([Name],[URL],[CanRepeater],[NeedIntegral],[Integral],[ShengjiJiangli]) values ('" + Name + "','" + URL + "'," + canRepeter + "," + needIntegral + "," + inter + ","+shengjijiangli+")";
            _DBbase.ExecuteCommand(sql);
        }

        public void ChangeJifen(string qq, int amount, bool isAdd)
        {
            Limit user = this.GetByid(qq);

        }

        public Limit GetByid(string qq)
        {
            string str = "select * from T_Limit where Id=" + qq ;
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }

        public void Edit(Limit user)
        {
            string str = "update T_Limit set [Name]='" + user.Name + "',[Integral]=" + user.Integral + ",[URL]='" + user.URL + "',[CanRepeater]=" + user.CanRepeater + ",[NeedIntegral]=" + user.NeedIntegral + ",[ShengjiJiangli]="+user .ShengjiJiangli+" where [Id]=" + user.Id + "";

            _DBbase.ExecuteCommand(str);
        }

        private Limit Get(string loginName, string loginPassWord)
        {
            string str = "select * from T_User where QQ='" + loginName + "' and Password='" + loginPassWord + "'";
            DataTable dt = _DBbase.ExeSelect(str);
            if (dt.Rows.Count == 1)
            {
                return this.GetEntity(dt.Rows[0]);
            }
            return null;
        }
        public List<Limit> GetAll()
        {
            string str = "select * from T_Limit ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<Limit> users = new List<Limit>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }
        private Limit GetEntity(DataRow dr)
        {
            Limit user = new Limit();
         //   user.Id = Convert.ToInt32(dr["Id"]);
            user.Name = dr["Name"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.URL = dr["URL"].ToString();
            user.CanRepeater = (bool )dr["CanRepeater"];
        //    user.RoleId = Convert.ToInt32(dr["RoleId"]);
         //   user.BoolUse = Convert.ToBoolean(dr["BoolUse"]);
            user.NeedIntegral = (bool)dr["NeedIntegral"];
            user.Integral = (int)dr["Integral"];
            user.Id =(int)dr["Id"];
            user.ShengjiJiangli = (int)dr["ShengjiJiangli"];
            return user;
        }
    }
}
