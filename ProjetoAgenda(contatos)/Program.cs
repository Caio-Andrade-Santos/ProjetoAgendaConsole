
using System;
using System.Collections.Generic;

namespace ProjetoAgenda_contatos_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int opcao;

            do
            {
                Console.WriteLine("\n===== AGENDA DE CONTATOS =====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite uma opção válida.");
                    opcao = -1;
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando a agenda...");
                        break;

                    case 1:
                        AdicionarContato(agenda);
                        break;

                    case 2:
                        PesquisarContato(agenda);
                        break;

                    case 3:
                        AlterarContato(agenda);
                        break;

                    case 4:
                        RemoverContato(agenda);
                        break;

                    case 5:
                        ListarContatos(agenda);
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }

        static void AdicionarContato(Contatos agenda)
        {
            Console.WriteLine("\n--- ADICIONAR CONTATO ---");

            Contato contato = new Contato();

            if (agenda.adicionar(contato))
                Console.WriteLine("Contato adicionado com sucesso!");
            else
                Console.WriteLine("Já existe um contato com esse e-mail.");
        }

        static void PesquisarContato(Contatos agenda)
        {
            Console.WriteLine("\n--- PESQUISAR CONTATO ---");

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            Contato busca = new Contato(email);

            Contato encontrado = agenda.pesquisar(busca);

            if (encontrado != null)
                Console.WriteLine(encontrado);
            else
                Console.WriteLine("Contato não encontrado.");
        }

        static void AlterarContato(Contatos agenda)
        {
            Console.WriteLine("\n--- ALTERAR CONTATO ---");

            Console.Write("Digite o e-mail do contato que deseja alterar: ");
            string email = Console.ReadLine();

            Contato busca = new Contato(
                email, "", new Data(1, 1, 2000));

            Contato encontrado = agenda.pesquisar(busca);

            if (encontrado == null)
            {
                Console.WriteLine("Contato não encontrado.");
                return;
            }

            Console.WriteLine("Contato atual:");
            Console.WriteLine(encontrado);

            Console.WriteLine("\nDigite os novos dados:");
            Contato novo = new Contato();

            // Mantém o e-mail antigo como identificador.
            novo.Email = encontrado.Email;

            if (agenda.alterar(novo))
                Console.WriteLine("Contato alterado com sucesso!");
            else
                Console.WriteLine("Não foi possível alterar o contato.");
        }

        static void RemoverContato(Contatos agenda)
        {
            Console.WriteLine("\n--- REMOVER CONTATO ---");

            Console.Write("Digite o e-mail do contato: ");
            string email = Console.ReadLine();

            Contato busca = new Contato(
                email, "", new Data(1, 1, 2000));

            if (agenda.remover(busca))
                Console.WriteLine("Contato removido com sucesso!");
            else
                Console.WriteLine("Contato não encontrado.");
        }

        static void ListarContatos(Contatos agenda)
        {
            Console.WriteLine("\n--- LISTA DE CONTATOS ---");

            List<Contato> lista = agenda.listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("A agenda está vazia.");
                return;
            }

            foreach (Contato contato in lista)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(contato);
            }
        }
    }
}
