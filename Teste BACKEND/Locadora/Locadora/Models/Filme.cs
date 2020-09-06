using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Filme
    {

        /****************************************
        * ATRIBUTOS
        ****************************************/

        /// <summary>
        /// ID do filme.
        /// </summary>
        private int id;

        /// <summary>
        /// Nome do filme.
        /// </summary>
        private string nome;

        /// <summary>
        /// Autor do filme.
        /// </summary>
        private string autor;

        /// <summary>
        /// Ano de publicação do filme.
        /// </summary>
        private int ano;

        /// <summary>
        /// Status do filme.
        /// </summary>
        private bool status;

        /****************************************
         * GETTER'S E SETTER'S
         ****************************************/

        /// <summary>
        /// ID do filme.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nome do filme.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Autor do filme.
        /// </summary>
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        /// <summary>
        /// Ano do filme.
        /// </summary>
        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        /// <summary>
        /// Status do filme.
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}