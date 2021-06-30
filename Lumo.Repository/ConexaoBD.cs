using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections.Generic;

namespace Lumo.Repository
{
    public class ConexaoBD : IDisposable
    {
        private readonly OleDbConnection OleDbConexao;
        private readonly SqlConnection SqlConexao;
        private string bancoDados = "OleDb";

        public ConexaoBD()
        {
            if (bancoDados == "OleDb")
            {
                OleDbConexao = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = lumo.mdb");
                if (OleDbConexao.State == ConnectionState.Closed)
                    OleDbConexao.Open();
            }
            else
            {
                SqlConexao = new SqlConnection("server = GRUMIO\\MANDII;Initial Catalog = Delfos; User ID = sa; Password=12tres;");
                SqlConexao.Open();
            }
        }

        public async void commandExecuteNonQuery(string strQuery, List<string> par)
        {
            if (bancoDados == "OleDb")
            {
                var cmdComando = new OleDbCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = OleDbConexao
                };

                for (int i = 0; i < par.Count; i++)
                {
                    try
                    {
                        cmdComando.Parameters.Add(new OleDbParameter("@dados" +
                            i.ToString(), par[i]));
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        cmdComando.Parameters.Add(new OleDbParameter("@dados" +
                            i.ToString(), DateTime.Parse(par[i])));
                    }
                }

                cmdComando.ExecuteNonQuery();
            }
            else
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = SqlConexao
                };

                for (int i = 0; i < par.Count; i++)
                {
                    try
                    {
                        cmdComando.Parameters.Add(new SqlParameter("@dados" +
                            i.ToString(), par[i]));
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        cmdComando.Parameters.Add(new SqlParameter("@dados" +
                            i.ToString(), DateTime.Parse(par[i])));
                    }
                }
                cmdComando.ExecuteNonQuery();
            }
        }

        public DataTable dataTable(string strQuery, List<string> par)
        {
            var dt = new DataTable();

            if (bancoDados == "OleDb")
            {
                var da = new OleDbDataAdapter();

                var cmdComando = new OleDbCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = OleDbConexao
                };


                for (int i = 0; i < par.Count; i++)
                {
                    try
                    {
                        cmdComando.Parameters.Add(new OleDbParameter("@dados" +
                            i.ToString(), par[i]));
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        cmdComando.Parameters.Add(new OleDbParameter("@dados" +
                            i.ToString(), DateTime.Parse(par[i])));
                    }
                }

                da.SelectCommand = cmdComando;
                da.Fill(dt);
            }
            else
            {
                var da = new SqlDataAdapter();

                var cmdComando = new SqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = SqlConexao
                };


                for (int i = 0; i < par.Count; i++)
                {
                    try
                    {
                        cmdComando.Parameters.Add(new SqlParameter("@dados" +
                            i.ToString(), par[i]));
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        cmdComando.Parameters.Add(new SqlParameter("@dados" +
                            i.ToString(), DateTime.Parse(par[i])));
                    }
                }

                da.SelectCommand = cmdComando;
                da.Fill(dt);
            }
            return dt;

        }

        public void Dispose()
        {
            //if (bancoDados == "OleDB")
            //{
                if (OleDbConexao.State == ConnectionState.Open)
                {
                    OleDbConexao.Close();
                }
            //}
            //else
            //{
                //try
                //{
                //    if (SqlConexao.State == ConnectionState.Open)
                ////    {
                //        SqlConexao.Close();
                //    }
                //}
                //catch { }
            //}
        }
    }
}
