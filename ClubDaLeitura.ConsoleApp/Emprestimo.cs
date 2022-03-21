using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Emprestimo
    {
        public string[] arrayNomeRevistaEmprestada = new string[1000];
        public string[] arrayNomeCriaEmprestimo = new string[1000];
        public bool[] arrayEstaEmprestado = new bool[1000];

        public int emprestados = 0;
        public int criancaComEmprestimo = 0;
        public int contadorDataEmprestimo = 0;


        public DateTime[] datasEmprestimoRevista = new DateTime[1000];
        public DateTime[] datasDevolucaoRevista = new DateTime[1000];
        
        public int indiceDatas = 0;

        Notificador notificador = new Notificador(); 

        public  void VarrerParaEmprestar(ref int opcaoMenu, string[] arrayNomeRevista, ref int indiceEmprestimoMenu)
        {
            for (int iloopEmprestados = 0; iloopEmprestados < 1000; iloopEmprestados++)
            {                                              
                if (arrayNomeRevistaEmprestada[indiceEmprestimoMenu] == arrayNomeRevista[iloopEmprestados])
                {
                    DateTime dataEmprestimo = ObterDataEmprestimoRevista();
                    //mexer na 

                    arrayNomeRevistaEmprestada[iloopEmprestados] = arrayNomeRevista[iloopEmprestados];
                    arrayEstaEmprestado[iloopEmprestados] = true;
                    
                    criancaComEmprestimo++;

                    Console.WriteLine($"\nA revista {arrayNomeRevista[iloopEmprestados]} agora está emprestada, Data:{dataEmprestimo} ");
                    arrayEstaEmprestado[emprestados] = true;
                    emprestados++;
                    opcaoMenu = 0;
                }
            }
        }

        public DateTime ObterDataEmprestimoRevista()
        {                       
            datasEmprestimoRevista[contadorDataEmprestimo] = DateTime.Now;
            Console.Write($"A data de empréstimo dessa revista é: {datasEmprestimoRevista[contadorDataEmprestimo]} \n");

            return datasEmprestimoRevista[indiceDatas];
        }
        public bool DataDeEmprestimoExcedeDiaDeHoje(DateTime dataEmprestimo)
        {
            return dataEmprestimo > DateTime.Today;
        }

        public void MostrarEmprestados(string[] arrayNomeCriaEmprestimo, DateTime[] datasEmprestimoRevista)
        {
            for (int w = 0; w < 1000; w++)
            {
                if (arrayNomeRevistaEmprestada[w] != null)
                    Console.WriteLine("\nNome: {0}\nAmigo que está com a Revista:{1} \nData de Empréstimo: {2}\n\n", arrayNomeRevistaEmprestada[w], arrayNomeCriaEmprestimo[w], datasEmprestimoRevista[w]);
            }
        }

        public int FazerDevolução(Revista revistas, Notificador notificador, bool[] arrayEstaDevolvido, ref int opcaoMenu2, string nomeRevistaDevolucao)
        {
            int contadorDevol;
            for (contadorDevol = 0; contadorDevol < 1000; contadorDevol++)
            {

                if (nomeRevistaDevolucao == revistas.arrayNomeRevista[contadorDevol] && arrayEstaEmprestado[contadorDevol] == false)
                {
                    Console.WriteLine($"A revista {revistas.arrayColecao[contadorDevol]} não está emprestada para ninguém no momento...");
                    opcaoMenu2 = 0;
                    break;
                }

                if (nomeRevistaDevolucao == revistas.arrayNomeRevista[contadorDevol] && arrayEstaEmprestado[contadorDevol] == true)
                {
                    //marcar a data do emprestimo
                    DateTime dataDevolucao = ObterDataDevolucaoRevista();

                    arrayEstaEmprestado[contadorDevol] = false;

                    Console.WriteLine($"\nA revista {revistas.arrayNomeRevista[contadorDevol]} agora está devolvida. Data da devolução: {DateTime.Now}");
                    arrayNomeRevistaEmprestada[contadorDevol] = null;
                    arrayEstaDevolvido[emprestados] = true;
                    emprestados--;
                    opcaoMenu2 = 0;
                    notificador.ApresentarMensagem($"Devolução da revista: '{revistas.arrayNomeRevista[contadorDevol]}' realizada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

            }

            return contadorDevol;
        }
        public DateTime ObterDataDevolucaoRevista()
        {            
            Console.Write($"A data de empréstimo dessa revista é: {datasEmprestimoRevista[contadorDataEmprestimo]}");

            return datasDevolucaoRevista[indiceDatas];
        }
    }
}
