using Newtonsoft.Json;
using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

// /////////////////////////////////////////////////////Querys////////////////////////////////////////////////////////////////////

namespace Locadora.Controllers
{
    public class MessageBox
    {
        public static string ALERT = "alert";
        public static string INFORMATION = "information";
        public static string SUCESS = "success";
        public static string WARNING = "warning";
        public static string ERROR = "error";

        public static string Show(string mensagem, string tipo, string tempo = "2500")
        {
            return "<script>var n = noty({ text: '" + mensagem + "', timeout: " + tempo + ", type: '" + tipo + "' });</script>";
        }

        public static object Noty(string mensagem, string tipo, bool retorno = false, string tempo = "1000")
        {
            return new { text = mensagem, timeout = tempo, type = tipo, result = retorno };
        }
    }
    public class HelpersController : Controller
    {
        public string Agora()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            return String.Format("{0:yyyy-MM-ddTHH:mm:sszzz}", dt);
        }

        public JsonResult CadastrarCli(string nome, string email, string cpf, int idade, string tel, string cep, int num)
        {
            //instancia a conexão
            Conn conexao = new Conn();

            // inserindo no BD
            conexao.retornaQuery("insert into Cliente values('" + nome + "', '" + idade + "', '" + cpf + "', '" + tel + "', '" + email + "', '" + cep + "', '" + num + "')");

            return Json(MessageBox.Noty("Cliente cadastrado com sucesso!", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarCli(string nome, string cpf)
        {

            string CPF = cpf;
            string NOME = nome;

            //instancia a conexão
            Conn conexao = new Conn();

            Cliente cli = new Cliente();

            SqlCommand comm = new SqlCommand();

            SqlDataReader dados = conexao.retornaQuery("SELECT nome, cpf FROM Cliente ");

            if (dados.Read())
            {
                cli.Nome = (dados["nome"] == DBNull.Value ? "" : dados["nome"].ToString()).Trim();
                cli.Cpf = (dados["cpf"] == DBNull.Value ? "" : dados["cpf"].ToString()).Trim();

                if(cli.Nome == NOME && cli.Cpf == CPF) {
                    return Json(MessageBox.Noty("Cliente ja cadastrado", MessageBox.ERROR, false, "2000"), JsonRequestBehavior.AllowGet);
                }
            }

             return Json(MessageBox.Noty("Novo cliente", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }
    }
}