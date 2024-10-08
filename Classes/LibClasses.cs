﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Jogo da forca desenvolvido para o curso de C#

namespace JogoForca.Classes
{
    using Palavras;
    using System.Runtime.CompilerServices;

    public class LibClasses
    {
        public static void JogoMenu()
        {
            Console.WriteLine("\nSelecione uma das opções abaixo para continuar:");
            Console.WriteLine("1- Jogar");
            Console.WriteLine("2- Sair");

            bool opcaoIsParsed = int.TryParse(Console.ReadLine(), out int opcao);

            while (opcaoIsParsed == false || (opcao < 1 || opcao > 2))
            {
                Console.WriteLine("Opção inválida. Escolha opção 1 ou 2.");
                opcaoIsParsed = int.TryParse(Console.ReadLine(), out opcao);
            }

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    GeraJogo();
                    break;
                case 2:
                    Sair();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        public static void Sair()
        {
            System.Environment.Exit(1);
        }
        public static KeyValuePair<string, string> EscolhePalavraAleatoria()
        {
            Dictionary<string, string> listaDePalavras = ClasseDePalavras.ArrayDePalavras();
            var randomNum = new Random();
            int num = randomNum.Next(listaDePalavras.Count - 1);
            
            var palavra = listaDePalavras.ElementAt(num);

            return palavra;
        }

        public static void GeraJogo()
        {
            var valorPalavra = EscolhePalavraAleatoria();
            string palavra = valorPalavra.Key;
            string dica = valorPalavra.Value;
            string linhas = GeraLinhas(palavra);
            int erros = 0;

            List<string> listaLetras = new List<string>();

            Console.WriteLine($"A palavra tem {linhas.Length} letras.");
            Console.WriteLine($"\nA dica é: {dica.ToUpper()}");
            string forca = GeraForca();
            Console.WriteLine(forca);
            Console.WriteLine(linhas);

            while (erros < 7)
            {
                Console.WriteLine("\nDigite uma letra:");
                string letra = Console.ReadLine();
                if(VerificaLetraDigitada(letra, listaLetras))
                {
                    Console.WriteLine("Você já digitou esta letra. Digite uma nova letra.\n");
                    continue;
                }

                listaLetras.Add(letra);

                bool verificaLetra = VerificaLetra(palavra, letra);
                if (verificaLetra == false)
                {
                    erros++;
                    forca = AdicionaBonecoForca(forca, erros);
                    Console.WriteLine($"\"{letra}\" não existe na palavra-chave. Você já errou {erros} vezes, no total.");
                    Console.WriteLine($" Você ainda tem mais {7 - erros} tentativas.");
                }
                    
                else
                    linhas = AdicionaLetra(letra, palavra, linhas);

                Console.WriteLine("Letras digitadas:");
                foreach (string str in listaLetras)
                {
                    Console.Write($"{str} ");
                }
                Console.WriteLine($"\n\n{linhas}");

                bool vencedor = VerificaVencedor(palavra, linhas);

                if (vencedor)
                {
                    Console.WriteLine($"Parabéns! Você acertou a palavra!");
                    JogoMenu();
                }

                if(erros == 7)
                {
                    Console.WriteLine($"Que pena, você perdeu :(");
                    Console.WriteLine($"A palavra era: {palavra}");
                    JogoMenu();
                }
            }

            
        }

        public static string GeraLinhas(string palavra)
        {
            string[] numLinhas = new string[palavra.Length];

            for(int i = 0; i < numLinhas.Length; i++)
                numLinhas[i] = "_";
       
            string linhas = string.Join("", numLinhas);
            return linhas;
        }

        public static bool VerificaLetra(string palavra, string letra)
        {
            int indexLetra = palavra.ToLower().IndexOf(letra.ToLower());

            if (indexLetra == -1)
                return false;

            return true;
        }

        public static string AdicionaLetra(string letra, string palavra, string linhas)
        {
            for(int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i].ToString().ToLower() == letra.ToLower())
                    linhas = linhas.Remove(i, 1).Insert(i, letra);
            }
            return linhas;
        }

        public static string GeraForca()
        {
            //string forca = "______\r\n|    |\r\n|    o\r\n|   /|\\\r\n|    |\r\n|   / \\\r\n|\r\n|";
            string forca = "______\r\n|    |\r\n|    \r\n|   \r\n|    \r\n|   \r\n|\r\n|";

            return forca;
        }

        public static string AdicionaBonecoForca(string forca, int erro)
        {
            switch(erro)
            {
                case 1:
                    forca = forca.Insert(21, "o");
                    break;
                case 2:
                    forca = forca.Insert(28, " ");
                    forca = forca.Insert(29, "|");
                    break;
                case 3:
                    forca = forca.Insert(37, "|");
                    break;
                case 4:
                    forca = forca.Remove(28, 1);
                    forca = forca.Insert(28, "/");
                    break;
                case 5:
                    forca = forca.Insert(30, "\\");
                    break;
                case 6:
                    forca = forca.Insert(45, "/");
                    break;
                case 7:
                    forca = forca.Insert(46, " ");
                    forca = forca.Insert(47, "\\");
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{forca}\n");
            return forca;
        }

        public static bool VerificaLetraDigitada(string letra, List<string> listaDePalavras)
        {
            return listaDePalavras.Contains(letra);
        }
        public static bool VerificaVencedor(string palavra, string linhas)
        {
            if(palavra.ToLower() == linhas.ToLower())
                return true;
            
            return false;
        }
    }
}
