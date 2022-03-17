using System;

namespace teste
{
    internal class Program
    {
        
        static void Main(string[] args)
        {


            #region Descrição de Variáveis
            Console.WriteLine("Bem vindo ao app Gestor de Equipamentos, o MENU abrirá assim que você inserir os primeiros dispositivos\nDigite o número de equipamentos (Máximo: 1000):");

            var numeroEquips = Console.ReadLine();
            int nEquipsInicial = Convert.ToInt32(numeroEquips);

            //arrays das características
            string[] arrayNomes = new string[1000];
            int[] preços = new int[1000];
            int[] series = new int[1000];
            string[] datafabs = new string[1000];
            string[] fabs = new string[1000];

            int opcao;
            //Declaração de variaveis
            string cnome;
            int cpreço;
            int cserie;
            string cdatafab;
            string cstrfab;

            //CHAMADOS
            int chamados = 0;
            int[] arrayChamados = new int[1000];
            DateTime dataAgora = DateTime.Now;
            int w = 0;
            string call, desc, equipCall;

            string[] arrayCall = new string[1000];
            string[] arrayDesc = new string[1000];
            string[] arrayEquipCall = new string[1000];
            #endregion

            //constituindo cada array
            for (int i = 0; i < nEquipsInicial; i++)
            {
                Console.WriteLine("\n\nInforme o nome do equipamento (deve ter no mínimo 6 caracteres) " + (i + 1) + ":");
                cnome = Console.ReadLine();
                if (cnome.Length < 6)
                {
                    Console.WriteLine("O nome deve ter mais que 6 caracteres");
                    i--;
                    continue;
                }

                Console.WriteLine("Informe o preço de aquisição do equipamento " + (i + 1) + ":");
                cpreço = Convert.ToInt32(Console.ReadLine());
                //cpreço = 11;

                Console.WriteLine("Informe o número de série do equipamento " + (i + 1) + ":");
                cserie = Convert.ToInt32(Console.ReadLine());
                //cserie = 22;

                Console.WriteLine("Informe a data de fabricaçãodo equipamento " + (i + 1) + ":");
                cdatafab = Console.ReadLine();
                //cdatafab = 33;

                Console.WriteLine("Informe a fabricante do equipamento " + (i + 1) + ":");
                cstrfab = Console.ReadLine();
                //cstrfab = "mgtek";

                arrayNomes[i] = cnome;
                preços[i] = cpreço;
                series[i] = cserie;
                datafabs[i] = cdatafab;
                fabs[i] = cstrfab;
            }

            //MENU
            do
            {
                Console.WriteLine("\n\nO que você deseja fazer?\n1) Visualizar equipamentos\n2) Inserir novo equipamento\n3) Editar algum equipamento\n4) Excluir algum equipamento\n"
                    + "5) Inserir um Chamado\n6) Visualizar Chamados \n7) Editar Chamados \n8) Exluir Chamado\n9) Sair");

                opcao = Convert.ToInt32(Console.ReadLine());

                //VISUALIZAR EQUIP
                if (opcao == 1)
                {
                    Console.WriteLine("\n\nEquipamentos:");
                    for (int i = 0; i < 1000; i++)
                    {
                        if (arrayNomes[i] != null)
                            Console.WriteLine("\nNome: {0}\nPreço: {1}\nSérie: {2}\nData de Fabricação: {3}\nFabricante: {4}", arrayNomes[i], preços[i], series[i], datafabs[i], fabs[i]);
                    }
                }

                //INSERIR EQUIP
                if (opcao == 2)
                {
                    for (int i = nEquipsInicial; i < 1001; i++)
                    {
                        Console.WriteLine("\n\nInforme o nome do equipamento (deve ter no mínimo 6 caracteres) " + (i + 1) + ":");
                        cnome = Console.ReadLine();
                        if (cnome.Length < 6)
                        {
                            Console.WriteLine("O nome deve ter mais que 6 caracteres");
                            i--;
                            continue;
                        }

                        Console.WriteLine("Informe o preço de aquisição do equipamento " + (i + 1) + ":");
                        cpreço = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe o número de série do equipamento " + (i + 1) + ":");
                        cserie = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe a data de fabricaçãodo equipamento " + (i + 1) + ":");
                        cdatafab = Console.ReadLine();

                        Console.WriteLine("Informe a fabricante do equipamento " + (i + 1) + ":");
                        cstrfab = Console.ReadLine();

                        arrayNomes[i] = cnome;
                        preços[i] = cpreço;
                        series[i] = cserie;
                        datafabs[i] = cdatafab;
                        fabs[i] = cstrfab;
                        nEquipsInicial++;
                        break;
                    }
                }

                // EDITAR EQUIP
                if (opcao == 3)
                {
                    Console.WriteLine("\nDigite o nome do equipamento que você pretende alterar");
                    var nomeEdit = Console.ReadLine();

                    //Varrer qual quer editar
                    for (int i = 0; i < 1000; i++)
                    {
                        if (nomeEdit == arrayNomes[i])
                        {
                            Console.WriteLine("\nDigite as características desse produto que você quer editar novamente, começando pelo nome:");

                            Console.WriteLine("Informe o nome do equipamento " + (i + 1) + ":");
                            arrayNomes[i] = Console.ReadLine();

                            Console.WriteLine("Informe o preço de aquisição do equipamento " + (i + 1) + ":");
                            preços[i] = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Informe o número de série do equipamento " + (i + 1) + ":");
                            series[i] = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Informe a data de fabricaçãodo equipamento " + (i + 1) + ":");
                            datafabs[i] = Console.ReadLine();

                            Console.WriteLine("Informe a fabricante do equipamento " + (i + 1) + ":");
                            fabs[i] = Console.ReadLine();

                            opcao = 0;
                        }
                    }
                }

                // EXCLUIR EQUIP
                while (opcao == 4)
                {
                    Console.WriteLine("\nDigite o nome do equipamento que você pretende excluir");
                    var nomeWipeOut = Console.ReadLine();

                    //Varrer SE o equip tem chamado
                    for (int q = 0; q < 1000; q++)
                    {
                        //Se não tiver chamado, entra nesse if abaixo
                        if (nomeWipeOut == arrayEquipCall[q])
                        {
                            Console.WriteLine("Não podemos excluir esse pois tem um chamado");
                            opcao = 0;
                            break;
                        }
                    }

                    if (opcao != 0)
                    {
                        //Varrer qual vai ser excluído
                        for (int i = 0; i < 1000; i++)
                        {
                            if (nomeWipeOut == arrayNomes[i])
                            {
                                arrayNomes[i] = null;
                                preços[i] = 0;
                                series[i] = 0;
                                datafabs[i] = null;
                                fabs[i] = null;
                                opcao = 0;
                                break;
                            }
                        }
                    }
                }

                //INSERIR CHAMADOS
                while (opcao == 5)
                {
                    Console.WriteLine("\n\nDigite o título do chamado que deseja inserir (Máximo: 1000):");
                    call = Console.ReadLine();

                    Console.WriteLine("Digite a descrição do chamado que deseja inserir (Máximo: 1000):");
                    desc = Console.ReadLine();

                    Console.WriteLine("Digite o nome do equipamento correspondente a este chamado");
                    equipCall = Console.ReadLine();

                    Console.WriteLine($"Data deste chamado: {dataAgora}");

                    arrayCall[w] = call;
                    arrayDesc[w] = desc;
                    arrayEquipCall[w] = equipCall;
                    arrayChamados[w]++;
                    chamados++;
                    w++;

                    Console.WriteLine("Deseja inserir mais um chamado?\n1) Sim\n2) Não");
                    int opcaoCall = Convert.ToInt32(Console.ReadLine());

                    if (opcaoCall == 1)
                        continue;

                    if (opcaoCall == 2)
                        break;
                }

                //VISUALIZAR CHAMADOS
                if (opcao == 6)
                {
                    Console.WriteLine($"\n\nChamados: {chamados}");
                    for (w = 0; w < 1000; w++)
                    {
                        if (arrayCall[w] != null)
                            Console.WriteLine("\nTítulo: {0}\nDescrição: {1}\nEquipamento: {2}\nData: {3}\n", arrayCall[w], arrayDesc[w], arrayEquipCall[w], dataAgora);
                    }
                }

                //EDITAR CHAMADOS
                if (opcao == 7)
                {
                    Console.WriteLine("\nDigite o título do chamado (igual) que você pretende alterar");
                    var nomeEditCall = Console.ReadLine();

                    //Varrer qual quer editar
                    for (int i = 0; i < 1000; i++)
                    {
                        if (nomeEditCall == arrayCall[i])
                        {
                            Console.WriteLine("\nDigite as novas características do chamado, começando pelo nome:");

                            Console.WriteLine("\n\nDigite o novo título do chamado que deseja inserir ");
                            arrayCall[i] = Console.ReadLine();

                            Console.WriteLine("Digite a descrição do chamado que deseja inserir:");
                            arrayDesc[i] = Console.ReadLine();

                            Console.WriteLine("Digite o nome do equipamento correspondente a este chamado");
                            arrayEquipCall[i] = Console.ReadLine();

                            opcao = 0;
                        }
                    }
                }
                //EXCLUIR CHAMADOS
                if (opcao == 8)
                {
                    Console.WriteLine("\nDigite o título do chamado que você pretende excluir");
                    var callWipeOut = Console.ReadLine();

                    //Varrer qual quer excluir
                    for (int i = 0; i < 1000; i++)
                    {
                        if (callWipeOut == arrayCall[i])
                        {
                            arrayCall[i] = null;
                            arrayDesc[i] = null;
                            arrayEquipCall[i] = null;
                            chamados--;
                        }
                    }
                }
            } while (opcao != 9);
        }
    }
}