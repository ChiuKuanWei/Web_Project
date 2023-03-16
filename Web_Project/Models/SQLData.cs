using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web_Project.Models
{
    public class SQLData
    {
        private string _sqlConn = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyWeb_DB;User ID=sa;Password=54013657";

        /// <summary>
        /// 依照條件取得資料
        /// </summary>
        /// <param name="sUser_Name">客戶用戶名</param>
        /// <returns></returns>
        public MyWeb GetData(string sUser_CreateTime)
        {
            MyWeb _myWeb = new MyWeb();
            using (SqlConnection _sqlconn = new SqlConnection(_sqlConn))
            {
                _sqlconn.Open();
                SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM [MyWeb_DB].[dbo].[FormLogin] where [User_CreateTime]=@User_CreateTime", _sqlconn);
                sqlCommand.Parameters.AddWithValue("@User_CreateTime", sUser_CreateTime);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _myWeb.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        _myWeb.User_Name = reader.GetString(reader.GetOrdinal("User_Name"));
                        _myWeb.User_Birth = reader.GetString(reader.GetOrdinal("User_Birth"));
                        _myWeb.User_Mail = reader.GetString(reader.GetOrdinal("User_Mail"));
                        _myWeb.User_Card = reader.GetString(reader.GetOrdinal("User_Card"));
                        _myWeb.User_Account = reader.GetString(reader.GetOrdinal("User_Account"));
                        _myWeb.User_Password = reader.GetString(reader.GetOrdinal("User_Password"));
                        _myWeb.User_CreateTime = reader.GetString(reader.GetOrdinal("User_CreateTime"));
                    }
                }
                _sqlconn.Close();
            }
            return _myWeb;
        }

        /// <summary>
        /// 抓取資料總攬
        /// </summary>
        /// <returns></returns>
        public List<MyWeb> GetDatas()
        {
            List<MyWeb> datas = new List<MyWeb>();
            using (SqlConnection _sqlconn = new SqlConnection(_sqlConn))
            {
                _sqlconn.Open();
                SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM [MyWeb_DB].[dbo].[FormLogin]", _sqlconn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyWeb _MyWeb = new MyWeb()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            User_Name = reader.GetString(reader.GetOrdinal("User_Name")),
                            User_Birth = reader.GetString(reader.GetOrdinal("User_Birth")),
                            User_Mail = reader.GetString(reader.GetOrdinal("User_Mail")),
                            User_Card = reader.GetString(reader.GetOrdinal("User_Card")),
                            User_Account = reader.GetString(reader.GetOrdinal("User_Account")),
                            User_Password = reader.GetString(reader.GetOrdinal("User_Password")),
                            User_CreateTime = reader.GetString(reader.GetOrdinal("User_CreateTime"))
                        };
                        datas.Add(_MyWeb);
                    }
                }
                
                _sqlconn.Close();               
            }
            return datas;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public void AddData(MyWeb _MyWeb)
        {
            string sCMD = @"INSERT INTO [MyWeb_DB].[dbo].[FormLogin]([User_Name],[User_Birth],[User_Mail],[User_Card],[User_Account],[User_Password],[User_CreateTime])
                            VALUES(@User_Name,@User_Birth,@User_Mail,@User_Card,@User_Account,@User_Password,@User_CreateTime)";

            using (SqlConnection _sqlconn = new SqlConnection(_sqlConn))
            {
                _sqlconn.Open();
                using (SqlCommand cmd = new SqlCommand(sCMD, _sqlconn))
                {
                    cmd.Parameters.AddWithValue("@User_Name", _MyWeb.User_Name);
                    cmd.Parameters.AddWithValue("@User_Birth", _MyWeb.User_Birth);
                    cmd.Parameters.AddWithValue("@User_Mail", _MyWeb.User_Mail);
                    cmd.Parameters.AddWithValue("@User_Card", _MyWeb.User_Card);
                    cmd.Parameters.AddWithValue("@User_Account", _MyWeb.User_Account);
                    cmd.Parameters.AddWithValue("@User_Password", _MyWeb.User_Password);
                    cmd.Parameters.AddWithValue("@User_CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }
                _sqlconn.Close();
            }
        }

        public void UpdateData(MyWeb _MyWeb)
        {
            string sCMD = @"Update [MyWeb_DB].[dbo].[FormLogin] set [User_Name]=@User_Name, [User_Birth]=@User_Birth, [User_Mail]=@User_Mail, [User_Card]=@User_Card,
                            [User_Account]=@User_Account, [User_Password]=@User_Password where [User_CreateTime] = @User_CreateTime";

            using (SqlConnection _sqlconn = new SqlConnection(_sqlConn))
            {
                _sqlconn.Open();
                using (SqlCommand cmd = new SqlCommand(sCMD, _sqlconn))
                {
                    cmd.Parameters.AddWithValue("@User_Name", _MyWeb.User_Name);
                    cmd.Parameters.AddWithValue("@User_Birth", _MyWeb.User_Birth);
                    cmd.Parameters.AddWithValue("@User_Mail", _MyWeb.User_Mail);
                    cmd.Parameters.AddWithValue("@User_Card", _MyWeb.User_Card);
                    cmd.Parameters.AddWithValue("@User_Account", _MyWeb.User_Account);
                    cmd.Parameters.AddWithValue("@User_Password", _MyWeb.User_Password);
                    cmd.Parameters.AddWithValue("@User_CreateTime", _MyWeb.User_CreateTime);
                    cmd.ExecuteNonQuery();
                }
                _sqlconn.Close();
            }
        }
    }
}