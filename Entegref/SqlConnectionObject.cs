using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entegref
{
    class SqlConnectionObject
    {


        public DataTable Query(string spName, Dictionary<string, string> param)
        {
            DataTable returnType = new DataTable();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring2))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(returnType);
                    conn.Close();
                }
            }

            return returnType;
        }

        public DataTable Query1(string spName)
        {
            DataTable returnType = new DataTable();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring2))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(returnType);
                }
                //conn.Close();
            }

            return returnType;
        }

        public void Insert3(string spName, Dictionary<string, string> param)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring2))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public string Insert4(string spName, Dictionary<string, string> param)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring2))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            if (item.Key == "@ReturnDesc")
                            {
                                cmd.Parameters.Add("@ReturnDesc", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    return (string)cmd.Parameters["@ReturnDesc"].Value;
                }
            }

        }
        public DataTable Query2(string spName, Dictionary<string, string> param)
        {
            DataTable returnType = new DataTable();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(returnType);
                }
            }

            return returnType;
        }
        public DataTable Query3(string spName)
        {
            DataTable returnType = new DataTable();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(returnType);
                }
                conn.Close();
            }

            return returnType;

        }



        public void Insert(string spName, Dictionary<string, string> param)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public string Insert2(string spName, Dictionary<string, string> param)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandTimeout = 0;
                    if (param != null)
                    {
                        foreach (var item in param)
                        {
                            if (item.Key == "@ReturnDesc")
                            {
                                cmd.Parameters.Add("@ReturnDesc", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    return (string)cmd.Parameters["@ReturnDesc"].Value;
                }
            }

        }
    }
}
