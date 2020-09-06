using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Usuario
    {
        /****************************************
        * ATRIBUTOS
        ****************************************/

        /// <summary>
        /// ID do usuario/func.
        /// </summary>
        private int id;

        /// <summary>
        /// Nome do usuario/func.
        /// </summary>
        private string nome;

        /****************************************
         * GETTER'S E SETTER'S
         ****************************************/

        /// <summary>
        /// ID do funcionário.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}