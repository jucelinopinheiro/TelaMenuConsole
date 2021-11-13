using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaMenu
{
    public class MenuComSombra
    {
        private int _menuLargura;
        private int _menuAltura;
        private int _posicaoX;
        private int _posicaoY;

        private string[] _opcoes;
        private int _tamanhoOpcoes;

        private int _itemSelecionado;

        public MenuComSombra(string titulo,string[] opcoes)
        {
            //altera o padrão do console para unicode
            Console.OutputEncoding = Encoding.Unicode;

            Tela tela = new Tela(titulo);
            _opcoes = opcoes;
            EqualizarTamanho();

            _menuLargura = _tamanhoOpcoes +1;
            _menuAltura = _opcoes.Length +1;
            _posicaoX = 10;
            _posicaoY = 3;

            _itemSelecionado = 0;

            SombraMenu();
            DesenhaMenu();
            EscreveOpcoes();

            tela.MensagemRodape("< ↑ ↓ > - Navegar no Menu - <Enter> Seleciona - <Esc> Sair");
            Console.Beep();
        }

        public int RolarMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                EscreveOpcoes();

                ConsoleKeyInfo comando = Console.ReadKey(true);
                keyPressed = comando.Key;

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    _itemSelecionado++;
                    if (_itemSelecionado == _opcoes.Length)
                    {
                        _itemSelecionado = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    _itemSelecionado--;
                    if (_itemSelecionado == -1)
                    {
                        _itemSelecionado = _opcoes.Length - 1;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter && keyPressed != ConsoleKey.Escape);

            Console.CursorVisible = true;

            if (keyPressed == ConsoleKey.Escape)
            {
                return _opcoes.Length - 1;
            }

            return _itemSelecionado;
        }

        private void EscreveOpcoes()
        {
            //desenha menu na tela.
            Console.CursorVisible = false;
            Console.SetCursorPosition(_posicaoX, _posicaoY);
            
            for (int i = 0; i < _opcoes.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(_posicaoX+1, (_posicaoY+1)+i);
                string opcaoAtual = _opcoes[i];

                if (i == _itemSelecionado)
                {

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                }

                Console.Write($"{opcaoAtual}");

                
            }

            Console.ResetColor();

        }

        private void DesenhaMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;

            for (int i = 0; i < _menuAltura; i++)
            {
                Console.SetCursorPosition(_posicaoX, _posicaoY + i);
                Console.Write(new string(' ', _menuLargura));
            }

            Console.SetCursorPosition(_posicaoX, _posicaoY);
            Console.WriteLine("┌".PadRight(_menuLargura, '─') + "┐");

            for (int i = 1; i < _menuAltura; i++)
            {
                Console.SetCursorPosition(_posicaoX, _posicaoY + i);
                Console.Write("│");
                Console.SetCursorPosition((_posicaoX + _menuLargura), _posicaoY + i);
                Console.Write("│");
            }

            Console.SetCursorPosition(_posicaoX, _posicaoY+_menuAltura);
            Console.WriteLine("└".PadRight(_menuLargura, '─') + "┘");
        }

        private void SombraMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < _menuAltura + 1; i++)
            {
                Console.SetCursorPosition(_posicaoX -2, (_posicaoY -1) + i);
                Console.Write(new string(' ', _menuLargura));
            }

        }

        private void EqualizarTamanho()
        {

            //procura o maior texto entre as opções de menu
            for (int i = 0; i < _opcoes.Length; i++)
            {
                if (_tamanhoOpcoes < _opcoes[i].Length)
                {
                    _tamanhoOpcoes = _opcoes[i].Length;
                }
            }
            //soma espaço de 2 ao tamanho
            _tamanhoOpcoes += 2;

            //equaliza o tamanho do menu com espaçamentos
            for (int i = 0; i < _opcoes.Length; i++)
            {
                _opcoes[i] = " " + _opcoes[i];
                _opcoes[i] = _opcoes[i].PadRight(_tamanhoOpcoes, ' ');
            }
        }
    }
}
