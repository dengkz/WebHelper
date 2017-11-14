using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Web;
using System.Collections;

namespace WebHelper.DataBase
{
    public class MSSQL
    {
        public  readonly string ConnStr1 = ConfigurationManager.AppSettings["ConnStr1"];
        public  readonly string ConnStr2 = ConfigurationManager.AppSettings["ConnStr2"];

            
        private  string ConnStr = "";
        private string _Message = ""; 


        // 连接数据源
        private SqlConnection con = null;
        private OleDbConnection conn = null;

        private DB dbType = DB.mssql;
        public int iCommandTimeout = 20;

        public MSSQL(DB db , string connStr)
        {
            ConnStr = connStr;

            if (db == DB.mssql)
                con = new SqlConnection(ConnStr);
            else if (db == DB.access)
                conn = new OleDbConnection(ConnStr);
        }

        public MSSQL(DB db)
        {
            ConnStr = ConnStr1;

            if (db == DB.mssql)
                con = new SqlConnection(ConnStr);
            else if (db == DB.access)
                conn = new OleDbConnection(ConnStr);
        }

        public MSSQL()
        {
            ConnStr = ConnStr1;
            dbType = DB.mssql;
            con = new SqlConnection(ConnStr1);
        }

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }




        /// <summary>
        /// 数据库连接类型
        /// </summary>
        public enum DB
        {
            /// <summary>
            /// SQL数据库
            /// </summary>
            mssql,
            /// <summary>
            /// access数据库
            /// </summary>
            access,
            /// <summary>
            /// oracle
            /// </summary>
            oracle

        }

        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        private void Open()
        {
            if (dbType == DB.mssql)
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                else if (con.State == System.Data.ConnectionState.Broken)
                {
                    con.Close();
                    con.Open();
                }
            }
            else if (dbType == DB.access)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == System.Data.ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (dbType == DB.mssql)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            else if (dbType == DB.access)
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (dbType == DB.mssql)
            {
                // 确认连接是否已经关闭
                if (con != null)
                {
                    con.Dispose();
                    con = null;
                }
            }
            else if (dbType == DB.access)
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }

        }


        public DataSet DataSet(string sql)
        {

            DataSet ds = new DataSet();
            try
            {
                if (dbType == DB.mssql)
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandTimeout = iCommandTimeout;
                    this.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "tempTable");

                }
                else if (dbType == DB.access)
                {
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.CommandTimeout = iCommandTimeout;
                    this.Open();
                    System.Data.OleDb.OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(ds, "tempTable");
                }
            }
            catch (Exception e)
            {
                Message = e.Message;
                //throw(e);
                ds = null;
            }
            finally
            {
                con.Close();
            }

            return ds;

        }


        /// <summary>
        /// 根据SQL查询返回DataSet对象，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="sRecord">开始记录数</param>
        /// <param name="mRecord">最大记录数</param>
        /// <returns>DataSet</returns>
        public DataSet DataSet(string sql, int sRecord, int mRecord)
        {

            DataSet ds = new DataSet();
            try
            {
                if (dbType == DB.mssql)
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandTimeout = 20;
                    this.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, sRecord, mRecord, "tempTable");

                }
                else if (dbType == DB.access)
                {
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.CommandTimeout = 20;
                    this.Open();
                    System.Data.OleDb.OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(ds, sRecord, mRecord, "tempTable");
                }
            }
            catch (Exception e)
            {
                Message = e.Message;
                //throw(e);
                ds = null;
            }
            finally
            {
                con.Close();
            }

            return ds;

        }



        /// <summary>
        ///  获得该SQL查询返回DataTable，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public DataTable DataTable(string sql)
        {
            DataTable tb = new DataTable();

            try
            {
                DataSet ds = this.DataSet(sql);
                if (ds != null)
                {
                    tb = ds.Tables["tempTable"];
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                //throw(ex);
            }
            return tb;
        }




        /// <summary>
        ///  获得该SQL查询返回DataTable，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public DataTable DataTable(string sql, int PageSize, int currentPage)
        {
            DataTable tb = new DataTable();

            DataSet ds = this.DataSet(sql, (currentPage - 1) * PageSize, PageSize);

            if (ds != null)
            {
                tb = ds.Tables["tempTable"];
            } 


            return tb;
        }






    }
}
