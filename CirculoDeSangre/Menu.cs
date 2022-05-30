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
        public void IniciarPrograma(Socio socio, List<Socio>ListaDeSocios, BancoDeSangre bds, 
            Peticion peticion, Donacion donacion, List<Peticion> ListaDePeticiones, 
            SocioAsignado sa, Menu menu, ValidarSocio vs, List<SocioAsignado>SociosAsignados,
            ValidarPeticion vp, ValidarDonacion vd)
        {
            do
            {
                switch (k)
                {
                    case 9:
                        Console.WriteLine("CIRCULO DE DONADORES DE SANGRE");
                        Console.WriteLine();
                        Console.WriteLine("Ingrese: ");
                        Console.WriteLine("1. Si desesa Iniciar Sesion como socio.");
                        Console.WriteLine("2. Si necesita Registrarse como socio.");
                        Console.WriteLine("3. Si desea Iniciar Sesion como Banco de Sangre.");
                        Console.WriteLine("4. Si desea Ingresar como Administrador.");
                        Console.WriteLine("\n0. Para Cerrar.\n");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        switch (n)
                        {
                            case 0:
                                Environment.Exit(0);
                                break;

                            case 1:
                                socio.IniciarSesion(menu);
                                break;

                            case 2:
                                Console.Clear();
                                socio.RegistrarDatosDeLaPersona(vs);
                                Console.Clear();
                                Console.WriteLine("Socio registrado correctamente.");
                                Console.WriteLine("\n\n\nIngrese: \n9. Para volver al inicio.\n0. Para cerrar la aplicación.");
                                k = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                break;

                            case 3:
                                bds.IniciarSesionBds(peticion, sa, donacion, ListaDeSocios, ListaDePeticiones, menu, 
                                    SociosAsignados, vp, vd);
                                break;

                            case 4:
                                Console.Clear();
                                Vopc();
                                void Vopc()
                                {
                                    Console.WriteLine("Ingrese: ");
                                    Console.WriteLine("1. Para Mostrar Listado de Socios.");
                                    Console.WriteLine("2. Para Mostrar Listado de Peticiones.");
                                    Console.WriteLine("3. Para Mostrar Listado de Donaciones.");
                                    Console.WriteLine("4. Para Mostrar Listado de Bancos de Sangre.");
                                    Console.WriteLine("\n9. Para Volver al Menú");
                                    int m = Convert.ToInt32(Console.ReadLine());
                                    if (m == 1)
                                    {
                                        Console.Clear();
                                        socio.MostrarListado();
                                        KeyToReturn();
                                        Vopc();
                                    }
                                    else if (m == 2)
                                    {
                                        Console.Clear();
                                        peticion.MostrarPeticiones();
                                        KeyToReturn();
                                        Vopc();

                                    }
                                    else if (m == 3)
                                    {
                                        Console.Clear();
                                        donacion.MostrarListaDeDonaciones();
                                        KeyToReturn();
                                        Vopc();
                                    }
                                    else if (m == 4)
                                    {
                                        Console.Clear();
                                        bds.MostrarListaDeBancos();
                                        KeyToReturn();
                                        Vopc();
                                    }
                                    else if (m == 9)
                                    {
                                        Console.Clear();
                                        k = 9;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Opcion inválida.\n");
                                        KeyToReturn();
                                        Vopc();
                                    }
                                }
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
        public void KeyToReturn()
        {
            Console.WriteLine("\n\n\nPresione Enter para volver.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
