using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace integral.Action
{
   public class Accessbase
    {
       string ConStr
       {
           get
           {
               //return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + @"\Fangliang.mdb";
               return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|integral.mdb";
           }
       }
       private OleDbConnection GetCon()
       {
           OleDbConnection con = new OleDbConnection(this.ConStr);
           return con;
       }

       public DataTable ExeSelect(string str)
       {
           OleDbConnection con =this.GetCon();
           OleDbDataAdapter sda = new OleDbDataAdapter(str, con);
           DataSet ds = new DataSet();
           con.Open();
           sda.Fill(ds);
           con.Close();
           con.Dispose();
           ds.Dispose();
           return ds.Tables[0];
       }
       //返回DataReader数据集，下面的SQL语句
       public OleDbDataReader CreateReader(String ss)
       {
           string strsql = ss;
           OleDbConnection Conn = this.GetCon();
           OleDbCommand Comm = new OleDbCommand(strsql, Conn);
           Conn.Open();
           OleDbDataReader MyReader = Comm.ExecuteReader();
           Conn.Close();
           return MyReader;
       }
       //返回DataReader数据集，下面的SQL是存储过程
       public OleDbDataReader Db_CommandReader(string SQL)
       {
           OleDbConnection conn = this.GetCon();
           OleDbCommand cmd = new OleDbCommand(SQL, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           OleDbDataReader Rs = cmd.ExecuteReader();
           conn.Close();
           return Rs;
       }
       //返回DataTable数据表
       public DataTable getdt(string SQL)
       {
           string strsql = SQL;
           //MessageBox.Show(strsql);
           OleDbConnection conn = this.GetCon();
           OleDbCommand cmd = new OleDbCommand(strsql, conn);
           OleDbDataAdapter Adpt = new OleDbDataAdapter(cmd);
           DataTable dt = new DataTable();

           Adpt.Fill(dt);
           conn.Close();
           return dt;


       }
       //返回数据DataSet数据集
       public DataSet Db_CreateDataSet(string SQL)
       {

           string strsql = SQL;
           OleDbConnection conn = this.GetCon();
           OleDbCommand cmd = new OleDbCommand(SQL, conn);
           OleDbDataAdapter Adpt = new OleDbDataAdapter(strsql, conn);
           DataSet Ds = new DataSet();
           Adpt.Fill(Ds, "NewTable");
           conn.Close();
           return Ds;

       }
       public DataSet CreateDataSet(string ss)
       {
           string StrSql = ss;
           OleDbConnection Conn = this.GetCon();
           Conn.Open();
           OleDbDataAdapter Adpt = new OleDbDataAdapter(StrSql, Conn);
           DataSet Ds = new DataSet();
           Adpt.Fill(Ds);
           Conn.Close();
           return Ds;
       }
       /// <summary>
       /// 执行插入 更新。。。
       /// </summary>
       /// <param name="sql"></param>
       public void ExecuteCommand(string sql)
       {
           OleDbConnection Conn = this.GetCon();
           try
           {
               Conn.Open();
               OleDbCommand com = new OleDbCommand(sql, Conn);
               com.ExecuteNonQuery();
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
           finally
           {
               Conn.Close();
           }
       }
    }
}
