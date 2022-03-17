using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Revista
    {
        public string colecao;
        public string nomeRevista;
        public int ano;
        public string caixaDaRevista;
         
        public string[] arrayNomeRevista = new string[1000];
        public string[] arrayColecao = new string[1000];
        public int[] arrayAno = new int[1000];
        public string[] arrayCaixaDaRevista = new string[1000];
         
        public int contadorRevistas = 0;

        public  int CadastrarRevista(int contadorCaixas, bool[] arrayEstaEmprestado, int opcaoMenu)
        {
            Notificador notificador = new Notificador();
                        
            notificador.ApresentarMensagem("Informe o nome da Revista " + (contadorRevistas + 1) + ":", ConsoleColor.Yellow);
            nomeRevista = Console.ReadLine();

            notificador.ApresentarMensagem("Informe o tipo de coleção da Revista " + (contadorRevistas + 1) + ":", ConsoleColor.Yellow);
            colecao = Console.ReadLine();

            notificador.ApresentarMensagem("Informe o ano da Revista " + (contadorRevistas + 1) + ":", ConsoleColor.Yellow);
            ano = Convert.ToInt32(Console.ReadLine());

            notificador.ApresentarMensagem("Informe a caixa onde está guardada a Revista " + (contadorRevistas + 1) + ":", ConsoleColor.Yellow);
            caixaDaRevista = Console.ReadLine();

            //aqui viria um METODO CADASTRAR CAIXA

            arrayNomeRevista[contadorRevistas] = nomeRevista;
            arrayColecao[contadorRevistas] = colecao;
            arrayAno[contadorRevistas] = ano;
            arrayCaixaDaRevista[contadorRevistas] = caixaDaRevista;
            arrayEstaEmprestado[contadorRevistas] = false;
            contadorRevistas++;
            return contadorRevistas;            
        }

        public void MostrarRevistas()
        {
            for (int w = 0; w < 1000; w++)
            {
                //nao esta mostrando as revistas
                if (arrayNomeRevista[w] != null)
                    Console.WriteLine("\n\nNome {0}\nColeção: {1}\nAno: {2}\n\n", arrayNomeRevista[w], arrayColecao[w], arrayAno[w]);
            }
        }
    }
}