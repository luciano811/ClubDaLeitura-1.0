using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.ConsoleApp
{
    public class Reserva
    {
        
        public int contadorReservas = 0;
        public int dataExpiracaoReserva = 2;
        public DateTime dataReserva = DateTime.MinValue;

        public string nomeAmigoReserva;
        public string nomeRevistaReserva;
                       
        public string[] arrayNomeAmigoReserva = new string[1000];
        public string[] arrayNomeRevistaReserva = new string[1000];


        public int CadastrarReserva()
        {
            Console.WriteLine("\nInforme o nome do Amigo para essa reserva" + (contadorReservas + 1) + ":");
            nomeAmigoReserva = Console.ReadLine();

            Console.WriteLine("Informe o nome da Revista para essa reserva " + (contadorReservas + 1) + ":");
            nomeRevistaReserva = Console.ReadLine();

            
            Console.WriteLine("Essa reserva expira em 2 dias!");

            arrayNomeAmigoReserva[contadorReservas] = nomeAmigoReserva;
            arrayNomeRevistaReserva[contadorReservas] = nomeRevistaReserva;
            contadorReservas++;
            return contadorReservas;
        }

        public void MostrarReservas()
        {
            for (int w = 0; w < 1000; w++)
            {
                if (arrayNomeAmigoReserva[w] != null)
                    Console.WriteLine("\n\nNome do amigo da Reserva: {0}\nNome da Revista da Reserva {1}\n\n", arrayNomeAmigoReserva[w], arrayNomeRevistaReserva[w]);
            }
        }
        
    }
}
