using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Locacao
    {
        /****************************************
        * ATRIBUTOS
        ****************************************/

        /// <summary>
        /// ID da locacao.
        /// </summary>
        private int id;

        /// <summary>
        /// ID do filme.
        /// </summary>
        private int idFil;

        /// <summary>
        /// ID do cliente.
        /// </summary>
        private string nameCli;

        /// <summary>
        /// ID do filme.
        /// </summary>
        private string nameFil;

        /// <summary>
        /// Data locado.
        /// </summary>
        private string data;

        /// <summary>
        /// Data devolucao.
        /// </summary>
        private string dataDev;

        /****************************************
         * GETTER'S E SETTER'S
         ****************************************/

        /// <summary>
        /// ID da locacao.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ID do filme.
        /// </summary>
        public int IDFIL
        {
            get { return idFil; }
            set { idFil = value; }
        }

        /// <summary>
        /// ID do cliente.
        /// </summary>
        public string NAMECLI
        {
            get { return nameCli; }
            set { nameCli = value; }
        }

        /// <summary>
        /// ID do filme.
        /// </summary>
        public string NAMEFIL
        {
            get { return nameFil; }
            set { nameFil = value; }
        }

        /// <summary>
        /// Data.
        /// </summary>
        public string DATA
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// Data delução.
        /// </summary>
        public string DATADEV
        {
            get { return dataDev; }
            set { dataDev = value; }
        }
    }
}