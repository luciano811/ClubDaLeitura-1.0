using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Categoria
    {
        public int contadorCategorias = 0;

        public string nomeCategoria;
        public int quantidadeDiasEmprestimo;

        public string[] arrayNomeCategoria = new string[1000];
        public int[] arrayQuantidadeDiasEmprestimo = new int[1000];


        public int CadastrarCategoria()
        {
            Console.WriteLine("\nInforme o nome da Categoria" + (contadorCategorias + 1) + ":");
            nomeCategoria = Console.ReadLine();

            Console.WriteLine("Informe a quantidade de dias de emprétimo " + (contadorCategorias + 1) + ":");
            quantidadeDiasEmprestimo = Convert.ToInt32(Console.ReadLine());            

            arrayNomeCategoria[contadorCategorias] = nomeCategoria;
            arrayQuantidadeDiasEmprestimo[contadorCategorias] = quantidadeDiasEmprestimo;
            contadorCategorias++;
            return contadorCategorias;
        }

        public void MostrarCategorias()
        {
            for (int w = 0; w < 1000; w++)
            {
                if (arrayNomeCategoria[w] != null)
                    Console.WriteLine("\n\nNome da Categoria: {0}\nQuantidade de dias de emprétimo {1}\n\n", arrayNomeCategoria[w], arrayQuantidadeDiasEmprestimo[w]);
            }
        }
    }
}

    

