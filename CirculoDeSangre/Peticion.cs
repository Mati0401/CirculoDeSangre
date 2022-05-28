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
        public void RegistrarPeticion(SocioAsignado sa, List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones, Peticion peticion)
        {
            Vfecha();
            void Vfecha(){
                try
                {
                    Console.Write("Ingrese la fecha con el formato **/**/****: ");
                    fechaDePeticion = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    Vfecha();
                }
            }
            VfechaLimite();
            void VfechaLimite(){
                try
                {
                    Console.Write("Ingrese la fecha limite con el formato **/**/****: ");
                    fechaLimite = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    VfechaLimite();
                }
            }
            VcantDonantes();
            void VcantDonantes()
            {
                try
                {
                    Console.Write("Ingrese la cantidad de donantes: ");
                    cantDonantes = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    VcantDonantes();
                }
            }
            Vgrupo();
            void Vgrupo() 
            {
                Console.Write("Ingrese el grupo en mayuscula: ");
                grupo = Console.ReadLine();
                if (grupo != "A" && grupo != "B" && grupo != "0" && grupo != "AB")
                {
                    Vgrupo();
                }
            }
            Vfactor();
            void Vfactor()
            {
                Console.Write("Ingrese el factor (+ o -): ");
                factor = Console.ReadLine();
                if (factor == "+")
                {
                    Console.WriteLine("El circulo solo tiene sangre rh negativo.");
                }
                else if (factor == "-")
                {
                    Console.Clear();
                    Console.WriteLine("Solicitud registrada.\n");
                }
                else
                {
                    Vfactor();
                }
            }
            
            CargarPeticion();
            sa.AsignarSocios(ListaDeSocios, ListaDePeticiones, peticion);
        }
        
        //CARGAR LOS DATOS EN LA LISTA
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
