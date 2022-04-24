using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Menu
    {
        int k = 9;
        public void IniciarPrograma(Socio socio)
        {
            do
            {
                switch (k)
                {
                    case 9:
                        Console.WriteLine("CIRCULO DE DONADORES DE SANGRE");
                        Console.WriteLine();
                        Console.WriteLine("Ingrese: ");
                        Console.WriteLine("1. Si desesa Iniciar Sesion.");
                        Console.WriteLine("2. Si necesita Registrarse.");
                        Console.WriteLine("\n0. Para Cerrar.\n");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        switch (n)
                        {
                            case 0:
                                Environment.Exit(0);
                                break;

                            case 1:
                                socio.IniciarSesion();
                                break;

                            case 2:
                                Console.Clear();
                                socio.RegistrarDatosDeLaPersona();
                                Console.Clear();
                                Console.WriteLine("Socio registrado correctamente.");
                                Console.WriteLine("\n\n\nIngrese: \n9. Para volver al inicio.\n0. Para cerrar la aplicación.");
                                k = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                break;

                            //DE PRUEBA
                            case 8: 
                                socio.MostrarListado();
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ERROR: el numero o caracter ingresado no corresponde a uno valido.\nVuelva a elegir otra opcion.\n");
                                break;
                        }
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            } while (k != 0);
        }
    }
}
