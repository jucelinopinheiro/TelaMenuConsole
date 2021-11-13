using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelaMenu
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Menu estilo Clipper";
            IniciarMenu();

        }

        static void IniciarMenu()
        {
            //Crie as oções do seu menu
            string[] opcoes = new string[]
            {
                "Cadastrar",
                "Remover",
                "Listar",
                "Bonus...",
                "Sair"
            };

            //chama o construtor da classe menu
            MenuComSombra menu1 = new MenuComSombra("Nosso Sistema", opcoes);
            //chama o metodo para fazer o eveito de rolagem do menu
            int opcao = menu1.RolarMenu();



            //cria chamadas conforme retorno de opção lembrando que o retorno da 1 opção é igual a 0;
            switch (opcao)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Cadastrar Itens...");
                    Console.ReadKey(true);
                    IniciarMenu();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Remover Itens...");
                    Console.ReadKey(true);
                    IniciarMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Listar Itens...");
                    Console.ReadKey(true);
                    IniciarMenu();
                    break;
                case 3:
                    Bonus();
                    Console.ReadKey(true);
                    IniciarMenu();
                    break;
                case 4:
                    Sair();
                    break;
                default:
                    Sair();
                    break;
            }

            
        }

        static void Bonus()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorSize = 100;
            Console.Clear();

            string mensagem = "\tHello, Neo... \n\tThe Matrix Has you... \n\tFollow The SENAI...";

            Thread.Sleep(500);
            for (int i = 0; i < mensagem.Length; i++)
            {
                Console.Write(mensagem[i]);
                Thread.Sleep(100);
            }


        }

        static void Sair()
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
