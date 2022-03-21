using ClubDaLeitura2.ConsoleApp;
using System;

namespace ClubDaLeitura.ConsoleApp
{
    internal class Program
    {
        //um notificador estatico para o ObterDataDevolucaoRevista()
        public static Notificador notificador = new Notificador();
        static int indiceEmprestimoMenu = 0;
          
          
          

        static void Main(string[] args)
        {
            #region Descrição de Variáveis           

            Amigo amigos = new Amigo();
            Revista revistas = new Revista();
            Caixa caixas = new Caixa();
            Emprestimo emprestimos = new Emprestimo();
            Notificador notificador = new Notificador(); 
            Categoria categorias = new Categoria();
            Reserva reservas = new Reserva();
            Multa multas = new Multa();

            //Declaração Devolucao
            string[] arrayNomeRevistaDevolvida = new string[1000];
            bool[] arrayEstaDevolvido = new bool[1000];
            int contadorDevol;            
            DateTime[] datasDevolucaoRevista = new DateTime[1000];

            #endregion

            int opcaoMenuAmplo;
            int opcaoMenu1 = 0;
            int opcaoMenu2 = 0;
            int opcaoMenu3 = 0;




            //MENU
            do
            {
                notificador.ApresentarMensagem("MENU INICIAL DO CLUBE DO LIVRO!!!", ConsoleColor.Cyan);

                notificador.ApresentarMensagem("\n1) Controle de Cadastros\n2) Controle de Reservas/Emprestimos\n3) Visualizações\n", ConsoleColor.White);                
                notificador.ApresentarMensagem("4) Sair", ConsoleColor.Red);                 

                opcaoMenuAmplo = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                //CADASTROSSSSSSSSSSSSSSSSSSS
                while (opcaoMenuAmplo == 1) 
                {
                    notificador.ApresentarMensagem("CONTROLE DE CADASTROS", ConsoleColor.Cyan);
                    notificador.ApresentarMensagem("\n1) Cadastrar Caixa\n2) Cadastrar Categoria\n3) Cadastrar Revista\n4) Cadastrar Amigo\n5) Sair", ConsoleColor.White);
                    opcaoMenu1 = Convert.ToInt32(Console.ReadLine());

                    //CADASTRAR CAIXA
                    if (opcaoMenu1 == 1)
                    {
                        //ver se tiro esse igual
                        caixas.contadorCaixas = caixas.CadastrarCaixa();
                        notificador.ApresentarMensagem("Caixa cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    

                    //CADASTRAR CATEGORIA
                    if (opcaoMenu1 == 2)
                    {                      
                        categorias.contadorCategorias = categorias.CadastrarCategoria();
                        notificador.ApresentarMensagem("Categoria cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //CADASTRAR REVISTA
                    while (opcaoMenu1 == 3)
                    {
                        if (caixas.contadorCaixas == 0)
                        {
                            notificador.ApresentarMensagem("Não existem caixas para guardar essa revista, aperte qualquer tecla para prosseguir", ConsoleColor.Red);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        else if (categorias.contadorCategorias == 0)
                        {
                            notificador.ApresentarMensagem("Não existem categorias para essa revista, aperte qualquer tecla para prosseguir", ConsoleColor.Red);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        revistas.contadorRevistas = revistas.CadastrarRevista(caixas.contadorCaixas, emprestimos.arrayEstaEmprestado, opcaoMenu1);
                        notificador.ApresentarMensagem("Revista cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                        opcaoMenu1 = 0;
                    }

                    //CADASTRAR AMIGO
                    if (opcaoMenu1 == 4)
                    {
                        amigos.CadastrarAmigo();
                        notificador.ApresentarMensagem("Amigo cadastrado com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    if (opcaoMenu1 == 5)
                    {
                        Console.Clear();
                        break;
                    }
                } 

                //RESERVASSSSS E EMPRESTIMOSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
                while (opcaoMenuAmplo == 2) 
                {
                    notificador.ApresentarMensagem("CONTROLE DE RESERVAS E EMPRESTIMOS", ConsoleColor.Cyan);
                    notificador.ApresentarMensagem("\n1) Reserva\n2) Empréstimo\n3) Devolução\n4) Multas\n5) Quitar Multa\n6) Sair", ConsoleColor.White);
                    opcaoMenu2 = Convert.ToInt32(Console.ReadLine());

                    // RESERVAS
                    if (opcaoMenu2 == 1)
                    {
                        while (opcaoMenu2 == 1)
                        {
                            if (revistas.contadorRevistas == 0)
                            {
                                notificador.ApresentarMensagem("Não existem revistas para essa reserva, aperte qualquer tecla para prosseguir", ConsoleColor.Red);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            else if (amigos.contadorAmigos == 0)
                            {
                                notificador.ApresentarMensagem("Não existem amigos para essa reserva, aperte qualquer tecla para prosseguir", ConsoleColor.Red);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            reservas.contadorReservas = reservas.CadastrarReserva();
                            reservas.dataReserva = DateTime.Now.Date.AddDays(reservas.dataExpiracaoReserva);

                            notificador.ApresentarMensagem($"Reserva termina em {reservas.dataReserva}", ConsoleColor.Yellow); 
                            notificador.ApresentarMensagem($"Reserva cadastrada com sucesso, aperte uma tecla para continuar", ConsoleColor.Green);


                            Console.ReadKey();
                            Console.Clear();
                            opcaoMenu2 = 0;
                        }
                    }
                    // EMPRESTIMO
                    while (opcaoMenu2 == 2)
                    {
                        #region Verificação
                        if (revistas.arrayNomeRevista[0] == null)
                        {
                            notificador.ApresentarMensagem("\nSem revista cadastrada...", ConsoleColor.Red);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (amigos.arrayNomeCria[0] == null)
                        {
                            notificador.ApresentarMensagem("\nSem criança cadastrada...", ConsoleColor.Red);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        #endregion

                        if (revistas.arrayNomeRevista[0] != null && amigos.arrayNomeCria[0] != null)
                        {
                            notificador.ApresentarMensagem("\nDigite o nome da revista que você pretende emprestar", ConsoleColor.Yellow);
                            emprestimos.arrayNomeRevistaEmprestada[indiceEmprestimoMenu] = Console.ReadLine();

                            notificador.ApresentarMensagem("\nDigite o nome da criança para a qual você pretende emprestar", ConsoleColor.Yellow);
                            emprestimos.arrayNomeCriaEmprestimo[indiceEmprestimoMenu] = Console.ReadLine();

                            if (multas.arrayBoolCriaMultados[indiceEmprestimoMenu] == true)
                            {
                                Console.WriteLine("Este amigo está devendo no clube!!! Impossível emprestar...");
                                Console.ReadKey();
                                opcaoMenu2 = 5;
                                break;
                            }

                            emprestimos.VarrerParaEmprestar(ref opcaoMenu2, revistas.arrayNomeRevista, ref indiceEmprestimoMenu);
                            notificador.ApresentarMensagem("Emprestimo realizado com sucesso\nAperte uma tecla para continuar", ConsoleColor.Green);
                            indiceEmprestimoMenu++;
                            emprestimos.indiceDatas++;
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                    // DEVOLUÇÃO
                    if (opcaoMenu2 == 3)
                    {
                        Console.WriteLine("\nDigite o nome da revista que você pretende devolver");
                        string nomeRevistaDevolucao = Console.ReadLine();

                        //Varrer qual quer devolver
                        contadorDevol = emprestimos.FazerDevolução(revistas, notificador, arrayEstaDevolvido, ref opcaoMenu2, nomeRevistaDevolucao);

                    }

                    // MULTA
                    if (opcaoMenu2 == 4)
                    {
                        Console.WriteLine("\nDigite o nome do amigo que você pretende multar");
                        string nomeCriaMultar = Console.ReadLine();
                                                

                        for (int iLoopAmigosMultados = 0; iLoopAmigosMultados < 1000; iLoopAmigosMultados++)
                        {
                            if (nomeCriaMultar == amigos.arrayNomeCria[iLoopAmigosMultados])
                            {
                                multas.arrayBoolCriaMultados[iLoopAmigosMultados] = true;

                                multas.amigosMultados++;                                

                                Console.WriteLine($"\nPor quantos dias ele ultrapassou o prazo de entrega? (Multa de R$: 0,15/dia) ");
                                int diasDeMulta = Convert.ToInt32( Console.ReadLine());

                                multas.valorMultas[iLoopAmigosMultados] = diasDeMulta * 0.15;

                                notificador.ApresentarMensagem($"\nValor da multa: {multas.valorMultas[iLoopAmigosMultados]}", ConsoleColor.DarkRed);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }


                    }

                    //QUITAR MULTA
                    while (opcaoMenu2 == 5)
                    {
                        Console.WriteLine("\nDigite o nome do amigo que terá a multa quitada:");
                        string amigoQuitarMulta = Console.ReadLine();

                        if (multas.amigosMultados == 0)
                        {
                            notificador.ApresentarMensagem($"\nNão existe nenhuma multa atualmente", ConsoleColor.DarkRed);
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }

                        for (int u = 0; u < 1000; u++)
                        {
                            if (amigoQuitarMulta == amigos.arrayNomeCria[u] && multas.arrayBoolCriaMultados[u] == true)
                            {
                                multas.arrayBoolCriaMultados[u] = false;

                                multas.amigosMultados--;
                                                              
                                multas.valorMultas[u] = 0;

                                notificador.ApresentarMensagem($"\nO valor da multa foi quitado com sucesso!!", ConsoleColor.Green);
                                Console.ReadKey();
                                Console.Clear();
                                opcaoMenu2 = 6;
                                break;
                            }
                        }
                        break;
                    }

                    if (opcaoMenu2 == 6)
                    {
                        Console.Clear();
                        break;
                    }

                }

                //VISUALIZACOEEEEEEEEEEEEEEEESSSSSSSSSSSSSSSSSSSSSSSSSSSSS
                while (opcaoMenuAmplo == 3) 
                {
                    notificador.ApresentarMensagem("CONTROLE DE VISUALIZAÇÕES", ConsoleColor.Cyan);
                    notificador.ApresentarMensagem("\n1) Visualizar Caixas\n2) Visualizar todas as Revistas\n3) Visualizar Emprestados\n4) Visualizar Multados\n5) Sair", ConsoleColor.White);
                    opcaoMenu3 = Convert.ToInt32(Console.ReadLine());

                    //VISUALIZAR Caixas
                    if (opcaoMenu3 == 1)
                    {
                        Console.WriteLine($"\n\nNúmero de Caixas: {caixas.contadorCaixas}");
                    
                        caixas.MostrarCaixas();
                    
                        notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //VISUALIZAR Revistas
                    if (opcaoMenu3 == 2)
                    {
                        Console.WriteLine($"\n\nNúmero total de Revistas: {revistas.contadorRevistas}");

                        revistas.MostrarRevistas();

                        notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    //VISUALIZAR EMPRESTADOS
                    if (opcaoMenu3 == 3)
                    {
                        Console.WriteLine($"\n\nNúmero de Revistas Emprestadas: {emprestimos.emprestados}");                    

                        emprestimos.MostrarEmprestados(emprestimos.arrayNomeCriaEmprestimo, emprestimos.datasEmprestimoRevista);

                        notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();                    
                    }

                    //VISUALIZAR MULTADOS
                    if (opcaoMenu3 == 4)
                    {
                        Console.WriteLine($"\n\nNúmero de Amigos multados: {multas.amigosMultados}");

                        multas.MostrarMultados( amigos.arrayNomeCria);                        

                        notificador.ApresentarMensagem("Aperte uma tecla para continuar", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    if (opcaoMenu3 == 5)
                    {
                        Console.Clear();
                        break;
                    }
                }              
            } while (opcaoMenuAmplo != 4);
        }

        




        #region DEVOLUCAO


        #endregion

    }
}