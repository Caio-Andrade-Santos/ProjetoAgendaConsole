using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda_contatos_
{
    internal class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Data DtNasc
        {
            get { return dtNasc; }
            set { dtNasc = value; }
        }



        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            telefones = new List<Telefone>();
        }

        public Contato(string email) 
        {
            Email = email;
        }

        public Contato()
        {
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            Console.Write("E-mail: ");
            Email = Console.ReadLine();

            Console.WriteLine("Data de nascimento:");

            Console.Write("Dia: ");
            int d = int.Parse(Console.ReadLine());

            Console.Write("Mês: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Ano: ");
            int a = int.Parse(Console.ReadLine());

            DtNasc = new Data(d, m, a);

            telefones = new List<Telefone>();

            Console.Write("Tipo de telefone (ex.: Celular): ");
            string tipo = Console.ReadLine();

            Console.Write("Número do telefone: ");
            string numero = Console.ReadLine();

            Console.Write("É o telefone principal? (s/n): ");
            bool principal = Console.ReadLine()
                .Trim().ToLower() == "s";

            Telefone telefone = new Telefone(tipo, numero, principal);

            telefones.Add(telefone);
        }


        public int getIdade()
        {
            DtNasc = new Data(DtNasc.Dia, DtNasc.Mes, DtNasc.Ano);
            DateTime hoje = DateTime.Today;

            if (DtNasc.Mes > hoje.Month || (DtNasc.Mes == hoje.Month && DtNasc.Dia > hoje.Day))
            {
                return hoje.Year - DtNasc.Ano - 1;
            }

            int idade = hoje.Year - DtNasc.Ano;
            return idade;
        }

        public void adicionarTelefone(Telefone telefone)
        {
            telefones.Add(telefone);
        }

        public String getTelefonePrincipal()
        {
            foreach (Telefone telefone in telefones)
            {
                if (telefone.Principal)
                {
                    return telefone.Numero;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string mensagem = "Contato: " + Nome + "\nEmail: " + Email + "\nData de Nascimento: " + DtNasc.ToString() + "\nIdade: " + getIdade() + "\nTelefones: " + getTelefonePrincipal();
            return mensagem;

        }

        public override bool Equals(object obj)
        {
            try
            {
                Contato outro = (Contato)obj;
                return Email == outro.Email;
            }
            catch (Exception)
            {
                Console.WriteLine("Erro: O objeto fornecido não é do tipo Contato.");
                return false;
            }
        }
    }
}
