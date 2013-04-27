using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace integral.Action
{
    public class JifenChangeAct
    {
        private Accessbase _DBbase = new Accessbase();


      //  public void Add(string qq, string password, string tuijianrenQQ)
      //  {
      //      string sql = "insert into T_MangerUser set (QQ,Password,TuijianrenQQ,Jifen) values ('" + qq + "','" + password + "','" + tuijianrenQQ + "',1)";
      //      _DBbase.ExecuteCommand(sql);
      //  }

        public void Add(string qq,int amount, JifenChangeType type,bool isAdd)
        {
            string sql = "insert into T_JifenChange ([QQ],[Amount],[IsAdd],[Type],[Time]) values ('" + qq + "'," + amount + "," + isAdd + "," + (int)type + ",'"+DateTime .Now+"')";


            _DBbase.ExecuteCommand(sql);
        }

        public void Add(string qq, int amount, JifenChangeType type, bool isAdd,string fromqq)
        {
            string sql = "insert into T_JifenChange ([QQ],[Amount],[IsAdd],[Type],[Time],[FromQQ]) values ('" + qq + "'," + amount + "," + isAdd + "," + (int)type + ",'" + DateTime.Now + "','"+fromqq+"')";


            _DBbase.ExecuteCommand(sql);
        }

        public List<JifenChange> GetAll()
        {
            string str = "select * from T_JifenChange ";
            DataTable dt = _DBbase.ExeSelect(str);
            List<JifenChange> users = new List<JifenChange>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add (this.GetEntity (dr ));
            }
            return users;
        }

        public List<JifenChange> GetByQQ(string qq)
        {
            string str = "select * from T_JifenChange where QQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            List<JifenChange> users = new List<JifenChange>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }

        public List<JifenChange> GetByQQAndType(string qq,JifenChangeType type)
        {
            string str = "select * from T_JifenChange where QQ='" + qq + "' and Type="+(int)type ;
            DataTable dt = _DBbase.ExeSelect(str);
            List<JifenChange> users = new List<JifenChange>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }

        public List<JifenChange> Select(string qq )
        {
            string str = "select * from T_JifenChange where QQ='"+qq+"'";
            DataTable dt = _DBbase.ExeSelect(str);
            List<JifenChange> users = new List<JifenChange>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(this.GetEntity(dr));
            }
            return users;
        }

        private JifenChange GetEntity(DataRow dr)
        {
            JifenChange user = new JifenChange();
         //   user.Id = Convert.ToInt32(dr["Id"]);
         //   user.QQ  = dr["QQ"].ToString();
          //  user.LoginName = dr["LoginName"].ToString();
            user.Id = (int)dr["Id"];
            user.Amount = (int)dr["Amount"];
            user.IsAdd = (bool)dr["IsAdd"];
            user.QQ = (string)dr["QQ"];
            user.Type = (JifenChangeType)dr["Type"];
            user .Time =(DateTime )dr["Time"];
            user.FromQQ = dr["FromQQ"].ToString();
           // user.TuijianrenQQ = dr["TuijianrenQQ"].ToString();
        //    user.RoleId = Convert.ToInt32(dr["RoleId"]);
         //   user.BoolUse = Convert.ToBoolean(dr["BoolUse"]);
         //   user.Jifen = (int)dr["Jifen"];
            return user;
        }
    }
}
