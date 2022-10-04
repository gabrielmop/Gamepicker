using System;
using System.Threading;

namespace Geradoraleatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nummaximo;
            int numeros;
            Random num1 = new Random();
            int resposta;



            do
            {

                Console.WriteLine("Bem Vindo ao gerador de numero aleatorio");
                Console.WriteLine("Digite o número Maximo que você deseja:");
                int.TryParse(Console.ReadLine(), out nummaximo);
                Console.WriteLine("Digite Quantos números você quer que sejam gerados:");
                int.TryParse(Console.ReadLine(), out numeros);

                Console.Clear();
                do
                {
                    for (int i = 0; i < numeros; i++)
                    {
                        int resultado = num1.Next(1, nummaximo);

                        
                        Console.WriteLine($"O Número gerado foi: {resultado}");

                    }
                   
                    Console.WriteLine("\r\n \r\nDigite 1 para Gerar outro número ou 2 pra redefinir parametros");
                   resposta = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (resposta == 1);
            }while(resposta == 2);
        }
    }
}
