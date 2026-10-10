using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda_contatos_
{
    internal class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public bool Principal
        {
            get { return principal; }
            set { principal = value; }
        }
        public Telefone(string tipo, string numero, bool principal)
        {
            Tipo = tipo;
            Numero = numero;
            Principal = principal;
        }

    }
}
