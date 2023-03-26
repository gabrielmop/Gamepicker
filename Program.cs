using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
            int numminimo;
            int nummaximo;
            int numeros;
            Random num1 = new Random();
            int resposta;
            GFG Comparador = new GFG();
            List<string> lista = new List<string>();


            do
            {
                Console.WriteLine("Bem Vindo ao Gerador de sugestão de Jogos aleatorio");
                Console.WriteLine("Digite o numero minimo que você deseja:");
                int.TryParse(Console.ReadLine(), out numminimo);
                Console.WriteLine("Digite Quantos números você quer que sejam gerados:");
                int.TryParse(Console.ReadLine(), out numeros);
                Console.WriteLine("Agora escolha um arquivo para basear a lista");
                Thread t = new Thread((ThreadStart)(() =>
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Arquivos de texto (*.txt)|*.txt";
                    dialog.FileName = dialog.FileName;
                    dialog.Title = "Escolha um arquivo de texto";



                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader sr = new StreamReader(dialog.FileName))
                        {
                            string line;


                            while ((line = sr.ReadLine()) != null)
                            {
                                lista.Add(line);
                            }
                        }

                    }
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();

                nummaximo = lista.Count;
                Console.Clear();
                do
                {                   
                    for (int i = 0; i < numeros; i++)
                    {
                        int numero = num1.Next(1, nummaximo);
                        Console.WriteLine($"O Jogo escolhido foi {lista[numero]}");
                    }
                    

                 

                    Console.WriteLine("\r\n \r\nDigite 1 para Gerar outro número ou 2 pra redefinir parametros");
                    resposta = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (resposta == 1);
            } while (resposta == 2);
        }
    }
}
    

