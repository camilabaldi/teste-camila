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
        public JsonResult CadastrarCli(string nome, string email, string cpf, int idade, string tel, string cep, int num)
        {
            //instancia a conexão
            Conn conexao = new Conn();

            // inserindo no BD
            conexao.retornaQuery("insert into Cliente values('" + nome + "', '" + idade + "', '" + cpf + "', '" + tel + "', '" + email + "', '" + cep + "', '" + num + "')");

            return Json(MessageBox.Noty("Cliente cadastrado com sucesso!", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CadastrarFil(string nome, string autor, int ano)
        {
            //instancia a conexão
            Conn conexao = new Conn();

            // inserindo no BD
            conexao.retornaQuery("insert into Filme values('" + nome + "', '" + autor + "', '" + ano + "', 0)");

            return Json(MessageBox.Noty("Filme cadastrado com sucesso!", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CadastrarLoc(int idcLI, int idFil, string data, string dataDev)
        {
            //instancia a conexão
            Conn conexao = new Conn();

            // inserindo no BD
            conexao.retornaQuery("insert into Locacao values('" + idcLI + "', '" + idFil + "', '" + data + "', '" + dataDev + "',  0 )");

            //colocando inativo no filme
            conexao.retornaQuery("update filme set status = 1 where idFilm =" + idFil);

            return Json(MessageBox.Noty("Locação feita com sucesso!", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Devolver(int idLoc, int idFilm)
        {
            //instancia a conexão
            Conn conexao = new Conn();

            // devolvendo e fechando a locação
            conexao.retornaQuery("update Locacao set status = 1 where idloc = " + idLoc);

            //ativando o filme
            conexao.retornaQuery("update filme set status = 0 where idFilm =" + idFilm);

            return Json(MessageBox.Noty("Devolução realizada com sucesso!", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
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

                if (cli.Nome == NOME && cli.Cpf == CPF)
                {
                    return Json(MessageBox.Noty("Cliente ja cadastrado", MessageBox.ERROR, false, "2000"), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(MessageBox.Noty("Novo cliente", MessageBox.SUCESS, false, "2000"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarClientes()
        {
            Conn conexao = new Conn();

            // procurando no banco de dados
            SqlDataReader dados = conexao.retornaQuery("SELECT * FROM Cliente order by nome asc");

            List<object> cliente = new List<object>();
            // verificando retorno do banco de dados
            while (dados.Read())
            {
                cliente.Add(new
                {
                    ID = (dados["idCli"] == DBNull.Value ? 0 : Convert.ToInt32(dados["idCli"])),
                    Nome = (dados["nome"] == DBNull.Value ? "" : dados["nome"].ToString()).Trim()
                });
            }
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarFilmes()
        {
            Conn conexao = new Conn();

            // procurando no banco de dados
            SqlDataReader dados = conexao.retornaQuery("SELECT * FROM Filme where status=0 order by nome asc");

            List<object> filme = new List<object>();
            // verificando retorno do banco de dados
            while (dados.Read())
            {
                filme.Add(new
                {
                    ID = (dados["idFilm"] == DBNull.Value ? 0 : Convert.ToInt32(dados["idFilm"])),
                    Nome = (dados["nome"] == DBNull.Value ? "" : dados["nome"].ToString()).Trim()
                });
            }
            return Json(filme, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaLoc()
        {
            Conn conexao = new Conn();
            List<Locacao> itens = new List<Locacao>();

            // procurando no banco de dados locacaoes em aberto (status 0)
            SqlDataReader dados = conexao.retornaQuery("SELECT l.idFilm as idFilme, l.idLoc as id, c.nome as cliNome, f.nome as filNome, l.dtLocado as data, l.dtDevolucao as dataDev from filme f inner join locacao l on f.idFilm = l.idFilm inner join cliente c on c.idCli = l.idClie where l.status = 0");

            // verificando retorno do banco de dados 
            while (dados.Read())
            {
                Locacao item = new Locacao();

                item.ID = (dados["id"] == DBNull.Value ? 0 : Convert.ToInt32(dados["id"]));
                item.IDFIL = (dados["idFilme"] == DBNull.Value ? 0 : Convert.ToInt32(dados["idFilme"]));
                item.NAMECLI = (dados["cliNome"] == DBNull.Value ? "" : dados["cliNome"].ToString()).Trim();
                item.NAMEFIL = (dados["filNome"] == DBNull.Value ? "" : dados["filNome"].ToString()).Trim();
                item.DATA = (dados["data"] == DBNull.Value ? "" : dados["data"].ToString()).Trim();
                item.DATADEV = (dados["dataDev"] == DBNull.Value ? "" : dados["dataDev"].ToString()).Trim();

                itens.Add(item);
            }

            return Json(itens, JsonRequestBehavior.AllowGet);
        }
    }
}