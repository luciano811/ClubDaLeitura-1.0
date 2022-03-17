using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Caixa
    {
        public int contadorCaixas = 0;
        
        public string corCaixa;
        public  int numCaixa;
        public  string etiquetaCaixa;

        public  string[] arrayCorCaixa = new string[1000];
        public  int[] arrayNumCaixa = new int[1000];
        public  string[] arrayEtiquetaCaixa = new string[1000];


        public int CadastrarCaixa()
        {
            Console.WriteLine("\nInforme a cor da Caixa" + (contadorCaixas + 1) + ":");
            corCaixa = Console.ReadLine();

            Console.WriteLine("Informe a etiqueta da Caixa " + (contadorCaixas + 1) + ":");
            etiquetaCaixa = Console.ReadLine();

            Console.WriteLine("Informe o número da Caixa " + (contadorCaixas + 1) + ":");
            numCaixa = Convert.ToInt32(Console.ReadLine());

            arrayCorCaixa[contadorCaixas] = corCaixa;
            arrayEtiquetaCaixa[contadorCaixas] = etiquetaCaixa;
            arrayNumCaixa[contadorCaixas] = numCaixa;
            contadorCaixas++;
            return contadorCaixas;
        }

        public void MostrarCaixas()
        {
            for (int w = 0; w < 1000; w++)
            {
                if (arrayCorCaixa[w] != null)
                    Console.WriteLine("\n\nCaixa: {0}\nEtiqueta: {1}\nNúmero: {2}\n\n", arrayCorCaixa[w], arrayEtiquetaCaixa[w], arrayNumCaixa[w]);
            }
        }
    }
}
