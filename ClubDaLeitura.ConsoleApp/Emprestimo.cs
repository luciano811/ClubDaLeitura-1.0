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

        public DateTime[] datasEmprestimoRevista = new DateTime[1000];
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

                    Console.WriteLine($"A revista {arrayNomeRevista[iloopEmprestados]} agora está emprestada, Data:{dataEmprestimo} ");
                    arrayEstaEmprestado[emprestados] = true;
                    emprestados++;
                    opcaoMenu = 0;
                }
            }
        }

        public DateTime ObterDataEmprestimoRevista()
        {
            bool dataValida;
            do
            {
                Console.Write("Digite a data de emprestimo da Revista: ");
                dataValida = DateTime.TryParse(Console.ReadLine(), out datasEmprestimoRevista[indiceDatas]);
                

                if (DataDeEmprestimoExcedeDiaDeHoje(datasEmprestimoRevista[indiceDatas]))
                {
                    dataValida = false;
                    notificador.ApresentarMensagem("Data de empréstimo não pode ser maior que hoje.", ConsoleColor.Red);
                }

                if (!dataValida)
                    notificador.ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

            } while (!dataValida);

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
    }
}
