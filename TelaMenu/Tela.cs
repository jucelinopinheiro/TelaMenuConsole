using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaMenu
{
    public class Tela
    {
        private int _numeroDeLinhas = Console.WindowHeight;
        private int _numeroDeColunas = Console.WindowWidth;
        private int _linhaDoRodape = Console.WindowHeight - 1;
        private readonly string _titulo;


        public int CentralizarTexto(int tamanhoTexto)
        {
            int posicao = Convert.ToInt16(decimal.Round((_numeroDeColunas - tamanhoTexto) / 2) + 1);
            return posicao;
        }

        public Tela(string titulo)
        {
            _titulo = titulo;
            DesenhaTela();
        }

        private void DesenhaTela()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            DesenhaTitulo();
            DesenhaRodape();

        }

        private void DesenhaTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', _numeroDeColunas));

            
            int textoNoCentro = CentralizarTexto(_titulo.Length);
            Console.SetCursorPosition(textoNoCentro, 0);
            Console.Write(_titulo);
            Console.ResetColor();
        }

        private void DesenhaRodape()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, _linhaDoRodape);
            Console.Write(new string(' ', _numeroDeColunas));

            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }

        public void MensagemRodape(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, _linhaDoRodape);
            Console.Write(mensagem);

            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }


    }

    
}
