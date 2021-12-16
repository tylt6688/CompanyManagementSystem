using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
namespace tylt6688
{
    class SQLtools
    {
        public MySqlConnection getConn()
        {
            string connetStr = "server=127.0.0.1;port=3306;user=root;password=1234;database=tylt_demo;Charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            return conn;
        }
        public string getExecu(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, getConn());
            cmd.ExecuteNonQuery();
            getConn().Close();
            return "操作成功！";
        }
        public string getClose()
        {
            getConn().Close();
            return "连接关闭";
        }
        public string getSelect(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, getConn ());
            MySqlDataReader mdr = cmd.ExecuteReader();
            string str = mdr.Read().ToString();
            getConn().Close();
            return str;
        }
       



    }


}