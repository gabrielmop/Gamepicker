using System;
using System.Collections.Generic;
using System.Threading;

namespace Geradoraleatorio
{
    class GFG : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

          
            return x.CompareTo(y);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int nummaximo;
            int numeros;
            Random num1 = new Random();
            int resposta;
            GFG Comparador = new GFG();
            

            do
            {

                Console.WriteLine("Bem Vindo ao gerador de numero aleatorio");
                Console.WriteLine("Digite o número Maximo que você deseja:");
                int.TryParse(Console.ReadLine(), out nummaximo);
                Console.WriteLine("Digite Quantos números você quer que sejam gerados:");
                int.TryParse(Console.ReadLine(), out numeros);

                List<int> lista = new List<int>(numeros);
                
                Console.Clear();
                do
                {
                    lista.Clear();
                    for (int i = 0; i < numeros; i++)
                    {
                        int resultado = num1.Next(1, nummaximo);

                      
                        lista.Add(resultado);
                    }
                    lista.Sort(Comparador);
                    for (int i = 0; i < numeros; i++)
                    {

                        Console.WriteLine($"O numero gerado foi {lista[i]}");



                    }

                    Console.WriteLine("\r\n \r\nDigite 1 para Gerar outro número ou 2 pra redefinir parametros");
                   resposta = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (resposta == 1);
            }while(resposta == 2);
        }
    }
}
