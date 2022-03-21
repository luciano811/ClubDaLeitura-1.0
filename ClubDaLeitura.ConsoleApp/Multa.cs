using ClubDaLeitura.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura2.ConsoleApp
{
    public class Multa
    {
        public int amigosMultados = 0;
        public int iLoopAmigosMultados = 0;


        public bool [] arrayBoolCriaMultados = new bool [1000];
        public double [] valorMultas = new double [1000];


        public void MostrarMultados(string[] arrayNomeCria)
        {
            for (int w = 0; w < 1000; w++)
            {
                if (amigosMultados == 0)
                {
                    Console.WriteLine("Não existem amigos multados...");
                    Console.ReadKey();
                    break;
                }
                
                if (arrayBoolCriaMultados[w] == true)
                    Console.WriteLine("\nNome do amigo multado: {0}\nValor da multa:{1} \n\n", arrayNomeCria[w], valorMultas[w]);
            }
        }

    }

    
}
