using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda_contatos_
{
    internal class Contatos
    {
        private readonly List<Contato> agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }


        public List<Contato> listar()
        {
            return new List<Contato>(agenda);
        }


        public bool adicionar(Contato c)
        {
            foreach (Contato contato in agenda)
            {
                if (contato.Equals(c))
                {
                    return false;
                }
            }

            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            return agenda.Find(contato => contato.Equals(c));
        }

        public bool alterar(Contato c)
        {
            int indice = agenda.FindIndex(contato => contato.Equals(c));

            if (indice == -1)
            {
                return false;
            }

            agenda[indice] = c;
            return true;
        }

        public bool remover(Contato c)
        {
            Contato encontrado = agenda.Find(contato => contato.Equals(c));

            if (encontrado == null)
            {
                return false;
            }

            agenda.Remove(encontrado);
            return true;
        }

    }
}
