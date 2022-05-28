using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Donacion
    {
        //ATRIBUTOS 

        private DateTime fechaDeDonacion;
        private int ddni;
        private string nombreApellido;
        private int numPeticion;


        //CAMPOS ENCAPSULADOS

        public DateTime FechaDeDonacion { get => fechaDeDonacion; set => fechaDeDonacion = value; }
        public int Ddni { get => ddni; set => ddni = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public int NumPeticion { get => numPeticion; set => numPeticion = value; }


        //LISTA DE DONACIONES

        private List<Donacion> listaDeDonaciones = new List<Donacion>();
        public List<Donacion> ListaDeDonaciones { get => listaDeDonaciones; set => listaDeDonaciones = value; }
        

        //DATOS DE LA DONACION
        public void DatosDeDonacion()
        {
            Console.WriteLine("Fecha de Donacion: " + FechaDeDonacion);
            Console.WriteLine("DNI del donante: " + Ddni);
            Console.WriteLine("Nombre del donante: " + NombreApellido);
            Console.WriteLine("Número de Petición: " + NumPeticion);
        }

        //REGISTRAR DONACION
        public void RegistrarDonacion(List<SocioAsignado> SociosAsignados, List<Peticion> ListaDePeticiones, List<Socio> ListaDeSocios)
        {
            VrdFecha();
            void VrdFecha()
            {
                try
                {
                    Console.Write("Ingrese la fecha en que se realizó la donacion con el formato **/**/****: ");
                    fechaDeDonacion = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    VrdFecha();
                }
            }
            VrdDni();
            void VrdDni()
            {
                bool coincide = false;
                try
                {
                    Console.Write("Ingrese el dni del donante: ");
                    ddni = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in SociosAsignados)
                    {
                        if(ddni == item.AsDni)
                        {
                            nombreApellido = item.AsNombre + " " +  item.AsApellido;
                            coincide = true;
                        }
                    }
                    if (coincide == false)
                    {
                        Console.WriteLine("El DNI ingresado no corresponde al de ningún socio en condición de donar.\n");
                        VrdDni();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    VrdDni();
                }
            }
            VrdNumPeticion();
            void VrdNumPeticion()
            {
                try
                {
                    Console.Write("Ingrese el número de petición al que corresponde la donación: ");
                    numPeticion = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in ListaDePeticiones)
                    {
                        if (numPeticion == item.Numero)
                        {
                            CargarDonacion();
                        }
                        else
                        {
                            Console.WriteLine("El numero de petición ingresado no corresponde a ninguna petición.\n");
                            VrdNumPeticion();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    VrdNumPeticion();
                }
            }

            //ACTUALIZAR DATOS DEL SOCIO
            foreach (var item in ListaDeSocios)
            {
                if (ddni == item.Dni)
                {
                    item.CantDeDonaciones = item.CantDeDonaciones + 1;
                    item.FechaDeUltimaDonacion = fechaDeDonacion;
                }
            }
        }

        //CARGAR LISTA DE DONACIONES
        public void CargarDonacion()
        {
            ListaDeDonaciones.Add(new Donacion()
            {
                FechaDeDonacion = fechaDeDonacion,
                Ddni = ddni,
                NombreApellido = nombreApellido,
                NumPeticion = numPeticion
            });
        }

        //MOSTRAR LISTADO DE DONACIONES
        public void MostrarListaDeDonaciones()
        {
            foreach (var item in ListaDeDonaciones)
            {
                item.DatosDeDonacion();
                Console.WriteLine();
            }
        }
    }
}
