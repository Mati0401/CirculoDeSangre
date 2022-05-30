using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class BancoDeSangre
    {
        //ATRIBUTOS

        private string nombre;
        private string ubicacion;
        private string bdsEmail;
        private string bdsContraseña;
        

        //CAMPOS ENCAPSULADOS 

        public string Nombre { get => nombre; set => nombre = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string BdsEmail { get => bdsEmail; set => bdsEmail = value; }
        public string BdsContraseña { get => bdsContraseña; set => bdsContraseña = value; }


        //LISTA DE BANCOS DE SANGRE

        private List<BancoDeSangre> listaDeBds = new List<BancoDeSangre>();

        public List<BancoDeSangre> ListaDeBds { get => listaDeBds; set => listaDeBds = value; }


        //DATOS DEL BANCO DE SANGRE
        public void DatosBds()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Ubicacion: " + Ubicacion);
            Console.WriteLine("Email: " + BdsEmail + "\tContraseña: " + bdsContraseña);
        }

        //BANCOS REGISTRADOS PREVIAMENTE
        public void BancoDeSangreYaRegistrados()
        {
            ListaDeBds.Add(new BancoDeSangre()
            {
                Nombre = "Instituto de Hematologia y Hemoterapia",
                Ubicacion = "Enf. Gordillo Gomez",
                BdsEmail = "ihh@bancodesangre.com.ar",
                BdsContraseña = "ihh12345"
            });
        }

        //MOSTRAR LISTA DE BANCOS DE SANGRE
        public void MostrarListaDeBancos()
        {
            foreach (var item in ListaDeBds)
            {
                item.DatosBds();
            }
        }

        //LOGUEAR UN BANCO CON EMAIL Y CONTRASEÑA
        string isEmail;
        public void IniciarSesionBds(Peticion peticion, SocioAsignado sa, Donacion donacion, 
            List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones, Menu menu, 
            List<SocioAsignado>SociosAsignados, ValidarPeticion vp, ValidarDonacion vd)
        {
            Console.Clear();
            bool emailExiste, usuarioLogueado, contraCorrecta;
            do
            {
                emailExiste = true;
                usuarioLogueado = false;
                Console.Write("Ingrese su email: ");
                isEmail = Console.ReadLine();
                foreach (BancoDeSangre item in ListaDeBds)
                {
                    if (isEmail == item.BdsEmail)
                    {
                        do
                        {
                            contraCorrecta = true;
                            Console.Write("Ingrese su contraseña: ");
                            string isContraseña = Console.ReadLine();
                            if (isContraseña == item.BdsContraseña)
                            {
                                Console.Clear();
                                Console.WriteLine("Banco logueado correctamente.\n");
                                usuarioLogueado = true;
                            }
                            else
                            {
                                Console.WriteLine("\nContraseña incorrecta.\n");
                                contraCorrecta = false;
                            }
                        } while (contraCorrecta == false);
                    }
                    else
                    {
                        emailExiste = false;
                    }
                }
                if (usuarioLogueado == true)
                {
                    contraCorrecta = true;
                    emailExiste = true;
                }
                else if (emailExiste == false)
                {
                    Console.Clear();
                    Console.WriteLine("Banco Inexistente\n");
                }
            } while (emailExiste == false);

            bool volver = false;
            do
            {
                //MENU QUE VE EL BANCO DE SANGRE

                Console.WriteLine("Ingrese: ");
                Console.WriteLine("1. Para Registrar una Peticion.");
                Console.WriteLine("2. Para Registrar una Donacion.");
                Console.WriteLine("3. Para Ver los Socios Asignados para Donar.");
                Console.WriteLine("0. Para Salir.");
                string p = Console.ReadLine();
                if (p == "0")
                {
                    volver = false;
                }
                else if (p == "1")
                {
                    Console.Clear();
                    peticion.RegistrarPeticion(sa, ListaDeSocios, ListaDePeticiones, peticion, vp);
                    menu.KeyToReturn();
                    volver = true;
                }
                else if (p == "2")
                {
                    Console.Clear();
                    donacion.RegistrarDonacion(SociosAsignados, ListaDePeticiones, ListaDeSocios, vd);
                    menu.KeyToReturn();
                    volver = true;
                }
                else if (p == "3")
                {
                    Console.Clear();
                    sa.MostrarSociosAsignados(peticion);
                    menu.KeyToReturn();
                    volver = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La opcion ingresa no es valida.\n");
                    volver = true;
                }
            } while (volver == true);
            Console.Clear();
        }
    }
}
