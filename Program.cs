using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Gamepicker
{


    internal class Program
    {
        static void Main(string[] args)
        {
            int nummaximo;
            int numeros;
            Random num1 = new Random();
            int resposta;
            List<string> lista = new List<string>();
            


            do
            {
                int Removidos = 1;
                lista.Clear();
                Console.WriteLine("Bem Vindo ao GamePicker");
                Console.WriteLine("Esse app gera uma sugestão de jogo aleatoriamente baseado em uma lista que voce escolher");
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
                                if (line.StartsWith("--"))
                                {
                                    lista.Remove(line);
                                    break;
                                }
                                if (line.Contains("//"))
                                {
                                   
                                    lista.Remove(line);
                                    Removidos++;
                                }
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
                        int numero = num1.Next(0, nummaximo);
                        Console.WriteLine($"O jogo gerado foi {numero + Removidos} - {lista[numero]}");
                    }

                    Console.WriteLine("\r\n \r\nDigite 1 para Gerar outro número ou 2 pra redefinir parametros");
                    resposta = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (resposta == 1);
            } while (resposta == 2);
        }
    }
}
    

