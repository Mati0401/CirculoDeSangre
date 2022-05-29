using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Peticion
    {
        //ATRIBUTOS

        private int numero = 0;
        private DateTime fechaDePeticion;
        private DateTime fechaLimite;
        private int cantDonantes;
        private string grupo;
        private string factor;


        //CAMPOS ENCAPSULADOS

        public int Numero { get => numero; set => numero = value; }
        public DateTime FechaDePeticion { get => fechaDePeticion; set => fechaDePeticion = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
        public int CantDonantes { get => cantDonantes; set => cantDonantes = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public string Factor { get => factor; set => factor = value; }
        

        //LISTA DE PETICIONES

        private List<Peticion> listaDePeticiones = new List<Peticion>();

        public List<Peticion> ListaDePeticiones { get => listaDePeticiones; set => listaDePeticiones = value; }
        

        //DATOS DE LA PETICION
        public void DatosDePeticion()
        {
            Console.WriteLine("Numero: " + Numero);
            Console.WriteLine("Fecha: " + FechaDePeticion + "\t" + "Fecha limite: " + FechaLimite);
            Console.WriteLine("Grupo: " + Grupo + "\t" + "Factor: " + Factor);
            Console.WriteLine("Se necesitan " + CantDonantes + " Donantes");
        }

        //REGISTRAR DATOS DE LA PETICION
        public void RegistrarPeticion(SocioAsignado sa, List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones, 
            Peticion peticion, ValidarPeticion vp)
        {

            Console.Write("Ingrese la fecha con el formato **/**/****: ");
            string stringfechaDePeticion = Console.ReadLine();
            fechaDePeticion = vp.ValidarFechaDePeticion(stringfechaDePeticion);

            Console.Write("Ingrese la fecha limite con el formato **/**/****: ");
            string stringfechaLimite = Console.ReadLine();
            fechaLimite = vp.ValidarFechaLimite(stringfechaLimite, fechaDePeticion);
    
            Console.Write("Ingrese la cantidad de donantes (en numero): ");
            string stringcantDonantes = Console.ReadLine();
            cantDonantes = vp.ValidarCantidadDeDonantes(stringcantDonantes);

            Console.Write("Ingrese el grupo en mayuscula (A, B, AB o 0): ");
            grupo = Console.ReadLine();
            grupo = vp.ValidarGrupo(grupo);

            Console.Write("Ingrese el factor (+ o -): ");
            factor = Console.ReadLine();
            factor = vp.ValidarFactor(factor);

            //SI EL FACTOR ES + DESCARTA LA PETICION Y SI ES - CARGA LA PETICION Y LE ASIGNA LOS SOCIOS A DONAR.
            if (factor == "+")
            {
                Console.WriteLine("\nLa peticion no se puede realizar porque el circulo solo tiene sangre RH Negativo.");
            }
            else
            {
                Console.WriteLine("\nLa peticion se registró exitosamente.");
                CargarPeticion();
                sa.AsignarSocios(ListaDeSocios, ListaDePeticiones, peticion);
            }
        }
        
        //CARGAR LOS DATOS DE LA PETICION EN LA LISTA
        public void CargarPeticion()
        {
            numero++;
            ListaDePeticiones.Add(new Peticion()
            {
                Numero = numero,
                FechaDePeticion = fechaDePeticion,
                FechaLimite = fechaLimite,
                CantDonantes = cantDonantes,
                Grupo = grupo,
                Factor = factor            
            });
        }

        //MOSTRAR LISTADO DE PETICIONES
        public void MostrarPeticiones()
        {
            foreach (var item in ListaDePeticiones)
            {
                item.DatosDePeticion();
                Console.WriteLine();
            }
        }
    }
}
