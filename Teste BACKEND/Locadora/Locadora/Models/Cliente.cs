using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Cliente
    {

        /****************************************
       * ATRIBUTOS
       ****************************************/

        /// <summary>
        /// ID do cliente.
        /// </summary>
        private int id;

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        private string nome;

        /// <summary>
        /// Email do cliente.
        /// </summary>
        private string email;

        /// <summary>
        /// Número de documento(cpf) do cliente.
        /// </summary>
        private string cpf;

        /// <summary>
        /// Idade do cliente.
        /// </summary>
        private int idade;

        /// <summary>
        /// Tel. do cliente.
        /// </summary>
        private string telefone;

        /// <summary>
        /// Cep do cliente.
        /// </summary>
        private string cep;

        /// <summary>
        /// Endereço n° do cliente.
        /// </summary>
        private int numero;

        /****************************************
         * GETTER'S E SETTER'S
         ****************************************/

        /// <summary>
        /// ID do cliente.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Número de cpf do cliente.
        /// </summary>
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        /// <summary>
        /// Idade do cliente.
        /// </summary>
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        /// <summary>
        /// Tel. do cliente.
        /// </summary>
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        /// <summary>
        /// Cep do cliente.
        /// </summary>
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        /// <summary>
        /// Endereço n° do cliente.
        /// </summary>
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
    }
}