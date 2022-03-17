using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Amigo
    {
        public int contadorAmigos = 0; 
        
        public string nomeCria;
        public string responCria;
        public int telefone;
        public string endereco;
         
        public string[] arrayNomeCria = new string[1000];
        public string[] arrayResponCria = new string[1000];
        public int[] arrayTelefone = new int[1000];
        public string[] arrayEndereco = new string[1000];                    

        
        public void CadastrarAmigo()
        {            
            Console.WriteLine("\n\nInforme a nome da criança " + (contadorAmigos + 1) + ":");
            nomeCria = Console.ReadLine();

            Console.WriteLine("Informe o nome do responsável da criança " + (contadorAmigos + 1) + ":");
            responCria = Console.ReadLine();

            Console.WriteLine("Informe o telefone da criança " + (contadorAmigos + 1) + ":");
            telefone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o endereço da criança " + (contadorAmigos + 1) + ":");
            endereco = Console.ReadLine();

            arrayNomeCria[contadorAmigos] = nomeCria;
            arrayResponCria[contadorAmigos] = responCria;
            arrayTelefone[contadorAmigos] = telefone;
            arrayEndereco[contadorAmigos] = endereco;
            contadorAmigos++;
        }
    }
}
