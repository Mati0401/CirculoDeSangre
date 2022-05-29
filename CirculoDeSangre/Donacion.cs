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
        public void RegistrarDonacion(List<SocioAsignado> SociosAsignados, List<Peticion> ListaDePeticiones, 
            List<Socio> ListaDeSocios, ValidarDonacion vd)
        {
            Console.Write("Ingrese el número de petición al que corresponde la donación: ");
            string stringnumPeticion = Console.ReadLine();
            numPeticion = vd.ValidarNumeroDePeticion(stringnumPeticion, ListaDePeticiones);

            Console.Write("Ingrese la fecha en que se realizó la donacion con el formato **/**/****: ");
            string stringfechaDeDonacion = Console.ReadLine();
            fechaDeDonacion = vd.ValidarFechaDeDonacion(stringfechaDeDonacion, ListaDePeticiones, numPeticion);

            Console.Write("Ingrese el dni del donante: ");
            string stringddni = Console.ReadLine();
            ddni = vd.ValidarDDni(stringddni, SociosAsignados);

            foreach (var item in SociosAsignados)
            {
                if(item.AsDni == ddni)
                {
                    nombreApellido = item.AsNombre + " " + item.AsApellido;
                }
            }

            Console.WriteLine("\nLa donación se registró exitosamente.");
            CargarDonacion();

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
