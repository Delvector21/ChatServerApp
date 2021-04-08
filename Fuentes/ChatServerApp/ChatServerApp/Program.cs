using ChatServerApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    //obtener Clientes
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando clientes");
                    if (servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Conexion Establecida");
                        Console.WriteLine("S: Hola mundo CLiente");
                        servidor.Escribir("Hola mundo cliente");
                        string mensaje = servidor.Leer();
                        Console.WriteLine("c:{0}", mensaje);
                        servidor.CerrarConexion();
                    }

                }
                
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No es posible iniciar el servidor");
                Console.ReadKey();
            }
        }
    }
}
