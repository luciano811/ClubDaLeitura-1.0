using System;

namespace ClubDaLeitura.ConsoleApp
{
    internal class Program
    {
        //um notificador estatico para o ObterDataDevolucaoRevista()
        public static Notificador notificador = new Notificador();
        public static int indiceEmprestimoMenu = 0;

        static void Main(string[] args)
        {
            #region Descrição de Variáveis           

            Amigo amigos = new Amigo();
            Revista revistas = new Revista();
            Caixa caixas = new Caixa();
            Emprestimo emprestimos = new Emprestimo();
            Notificador notificador = new Notificador();            
                                            

            //Declaração Devolucao
            string[] arrayNomeRevistaDevolvida = new string[1000];
            bool[] arrayEstaDevolvido = new bool[1000];
            int contadorDevol;            
            DateTime[] datasDevolucaoRevista = new DateTime[1000];

            #endregion

            notificador.ApresentarMensagem("Bem Vindo ao Clube do Livro!!!", ConsoleColor.DarkGreen);
            int opcaoMenu;            

            //MENU
            do
            {
                notificador.ApresentarMensagem("\n1) Cadastrar Caixa\n2) Cadastrar Revista\n3) Cadastrar Amigo\n", ConsoleColor.White);
                notificador.ApresentarMensagem("4) Empréstimo\n5) Devolução", ConsoleColor.Yellow);
                notificador.ApresentarMensagem("\n6) Visualizar Caixas\n7) Visualizar todas as Revistas\n8) Visualizar Emprestados\n", ConsoleColor.DarkYellow);
                notificador.ApresentarMensagem("9) Sair", ConsoleColor.Red);                

                opcaoMenu = Convert.ToInt32(Console.ReadLine());

                //CADASTRAR CAIXA
                if (opcaoMenu == 1)
                {
                    //ver se tiro esse igual
                    caixas.contadorCaixas = caixas.CadastrarCaixa();
                    notificador.ApresentarMensagem("Caixa cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                }

                //CADASTRAR REVISTA
                while (opcaoMenu == 2)
                {
                    if (caixas.contadorCaixas == 0)
                    {
                        notificador.ApresentarMensagem("Não existem caixas para guardar essa revista, aperte qualquer tecla para prosseguir", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    //ver se tiro esse igual
                    revistas.contadorRevistas = revistas.CadastrarRevista(caixas.contadorCaixas, emprestimos.arrayEstaEmprestado, opcaoMenu);
                    notificador.ApresentarMensagem("Revista cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                    opcaoMenu = 0;
                }                

                //CADASTRAR AMIGO
                if (opcaoMenu == 3)
                {
                    amigos.CadastrarAmigo();
                    notificador.ApresentarMensagem("Amigo cadastrado com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                }

                // EMPRESTIMO
                if (opcaoMenu == 4)
                {
                    #region Verificação
                    if (revistas.arrayNomeRevista[0] == null)
                    {
                        notificador.ApresentarMensagem("\nSem revista cadastrada...", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (amigos.arrayNomeCria[0] == null)
                    {
                        notificador.ApresentarMensagem("\nSem criança cadastrada...", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    #endregion                    

                    if (revistas.arrayNomeRevista[0] != null && amigos.arrayNomeCria[0] != null)
                    {
                        
                        
                        notificador.ApresentarMensagem("\nDigite o nome da revista que você pretende emprestar", ConsoleColor.Yellow);
                        emprestimos.arrayNomeRevistaEmprestada[indiceEmprestimoMenu] = Console.ReadLine();
                                               
                        notificador.ApresentarMensagem("\nDigite o nome da criança para a qual você pretende emprestar", ConsoleColor.Yellow);
                        emprestimos.arrayNomeCriaEmprestimo[indiceEmprestimoMenu] = Console.ReadLine();

                        emprestimos.VarrerParaEmprestar(ref opcaoMenu, revistas.arrayNomeRevista, ref indiceEmprestimoMenu);
                        notificador.ApresentarMensagem("Emprestimo realizado com sucesso\nAperte uma tecla para continuar", ConsoleColor.Green);
                        indiceEmprestimoMenu++;
                        emprestimos.indiceDatas++;
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                    

                    
                

                // DEVOLUÇÃO
                if (opcaoMenu == 5)
                {
                    Console.WriteLine("\nDigite o nome da revista que você pretende devolver");
                    string nomeRevistaDevolucao = Console.ReadLine();

                    //Varrer qual quer devolver
                    for (contadorDevol = 0; contadorDevol < 1000; contadorDevol++)
                    {
                        
                        if (nomeRevistaDevolucao == revistas.arrayNomeRevista[contadorDevol] && emprestimos.arrayEstaEmprestado[contadorDevol] == false)
                        {
                            Console.WriteLine($"A revista {revistas.arrayColecao[contadorDevol]} não está emprestada para ninguém no momento...");
                            opcaoMenu = 0;
                            break;
                        }

                        if (nomeRevistaDevolucao == revistas.arrayNomeRevista[contadorDevol] && emprestimos.arrayEstaEmprestado[contadorDevol] == true)
                        {
                            //marcar a data do emprestimo
                            DateTime dataDevolucao = ObterDataDevolucaoRevista();

                            emprestimos.arrayEstaEmprestado[contadorDevol] = false;

                            Console.WriteLine($"A revista {revistas.arrayNomeRevista[contadorDevol]} agora está devolvida. Data: aaaaaaaa");
                            emprestimos.arrayNomeRevistaEmprestada[contadorDevol] = null;
                            arrayEstaDevolvido[emprestimos.emprestados] = true;
                            emprestimos.emprestados--;
                            opcaoMenu = 0;
                            notificador.ApresentarMensagem($"Devolução da revista: '{revistas.arrayNomeRevista[contadorDevol]}' realizada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        
                    }
                    
                }

                //VISUALIZAR Caixas
                if (opcaoMenu == 6)
                {
                    Console.WriteLine($"\n\nNúmero de Caixas: {caixas.contadorCaixas}");
                    
                    caixas.MostrarCaixas();
                    
                    notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                }

                //VISUALIZAR Revistas
                if (opcaoMenu == 7)
                {
                    Console.WriteLine($"\n\nNúmero total de Revistas: {revistas.contadorRevistas}");

                    revistas.MostrarRevistas();

                    notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                }

                //VISUALIZAR EMPRESTADOS
                if (opcaoMenu == 8)
                {
                    Console.WriteLine($"\n\nNúmero de Revistas Emprestadas: {emprestimos.emprestados}");                    

                    emprestimos.MostrarEmprestados(emprestimos.arrayNomeCriaEmprestimo, emprestimos.datasEmprestimoRevista);

                    notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                    
                }

            } while (opcaoMenu != 9);
        }
        

#region DEVOLUCAO
        public static DateTime ObterDataDevolucaoRevista()
        {
            DateTime dataDevolucao;
            bool dataValida;
            do
            {
                Console.Write("Digite a data de Devolucao da Revista: ");
                dataValida = DateTime.TryParse(Console.ReadLine(), out dataDevolucao);

                if (DataDeDevolucaoExcedeDiaDeHoje(dataDevolucao))
                {
                    dataValida = false;
                    notificador.ApresentarMensagem("Data de empréstimo não pode ser maior que hoje.", ConsoleColor.Red);
                }

                if (!dataValida)
                    notificador.ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

            } while (!dataValida);

            return dataDevolucao;
        }
        private static bool DataDeDevolucaoExcedeDiaDeHoje(DateTime dataDevolucao)
        {
            return dataDevolucao > DateTime.Today;
        }
        #endregion               

    }
}