using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Conn
    {

        /// <summary>
        /// Método que retorna a conexão com  a base de dados.
        /// </summary>
        /// <returns></returns>
        private SqlConnection connection()
        {
            try
            {
                //Instância o sqlconnection com a string de conexão.
                SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

                //Verifica se a conexão esta fechada.
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    //Abri a conexão.
                    sqlconnection.Open();
                }

                //Retorna o sqlconnection.
                return sqlconnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que retorna um datareader com o resultado da query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SqlDataReader retornaQuery(string query)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand(query, connection());

                //Executa a query sql.
                var retornaQuery = comando.ExecuteReader();

                //Fecha a conexão.
                connection().Close();

                //Retorna o dataReader com o resultado
                return retornaQuery;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que retorna o resultado da consulta sql em um dataset.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet retornaQueryDataSet(string query)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand(query, connection());

                //Instância o sqldataAdapter.
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                //Instância o dataSet de retorno.
                DataSet dataSet = new DataSet();

                //Atualiza o dataSet
                adapter.Fill(dataSet);

                //Retorna o dataSet com o resultado da query sql.
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que executa a query sql.
        /// </summary>
        /// <param name="query"></param>
        public void executaQuery(string query)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand(query, connection());

                //Executa a query sql.
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que executa a query sql e retorna o identity.
        /// </summary>
        /// <param name="query"></param>
        public int executaQueryIdentity(string query)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand(query, connection());
                comando.CommandType = CommandType.Text;

                //Executa a query sql.

                //comando.ExecuteNonQuery();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RetornaDataTable(SqlCommand comm)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString());

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                comm.Connection = conn;

                SqlDataAdapter adap = new SqlDataAdapter(comm);
                DataSet dset = new DataSet();

                adap.Fill(dset);

                return dset.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
