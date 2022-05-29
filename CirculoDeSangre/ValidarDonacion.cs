using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CirculoDeSangre
{
    public class ValidarDonacion
    {
        public DateTime ValidarFechaDeDonacion(string stringfechaDeDonacion, List<Peticion>ListaDePeticiones,
            int numPeticion)
        {
            //Solo acepta el formato dd/mm/aaaa.
            bool coincide = false;
            do
            {
                while (!Regex.Match(stringfechaDeDonacion, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$").Success)
                {
                    Console.Write("Ingrese nuevamente la fecha de donación: ");
                    stringfechaDeDonacion = Console.ReadLine();
                }
                foreach (var item in ListaDePeticiones)
                {
                    if (item.Numero == numPeticion)
                    {
                        if ((Convert.ToDateTime(stringfechaDeDonacion)).Ticks <= item.FechaLimite.Ticks
                            && (Convert.ToDateTime(stringfechaDeDonacion)).Ticks >= item.FechaDePeticion.Ticks)
                        {
                            coincide = true;
                        }
                    }
                }
                if (coincide == false)
                {
                    Console.WriteLine("La fecha ingresada no está dentro del plazo para donar.");
                    Console.Write("Ingrese nuevamente la fecha de petición: ");
                    stringfechaDeDonacion = Console.ReadLine();
                }
            } while (coincide == false);
            DateTime fechaDeDonacion;
            fechaDeDonacion = Convert.ToDateTime(stringfechaDeDonacion);
            return fechaDeDonacion;
        }
        public int ValidarDDni(string stringddni, List<SocioAsignado>SociosAsignados)
        {
            //El dni debe tener 8 numeros.
            //El dni debe coincidir con el de un socio asignado para donar.
            bool coincide = false;
            do
            {
                while (!Regex.Match(stringddni, @"^\d{8}$").Success)
                {
                    Console.Write("Ingrese nuevamente el dni: ");
                    stringddni = Console.ReadLine();
                }
                foreach (var item in SociosAsignados)
                {
                    if (Convert.ToInt32(stringddni) == item.AsDni)
                    {
                        coincide = true;
                    }
                }
                if(coincide == false)
                {
                    Console.WriteLine("El DNI ingresado no corresponde al de ningún socio en condición de donar.\n");
                    Console.Write("Ingrese nuevamente el dni: ");
                    stringddni = Console.ReadLine();
                }
            } while (coincide == false);
            int ddni;
            ddni = int.Parse(stringddni);
            return ddni;
        }
        public int ValidarNumeroDePeticion(string stringnumPeticion, List<Peticion>ListaDePeticiones)
        {
            //Debe ser un numero entre 1 y 9999.
            //Debe coincidir con el numero de una peticion existente.
            bool coincide = false;
            do
            {
                while (!Regex.Match(stringnumPeticion, @"^\d{1,4}$").Success)
                {
                    Console.Write("Ingrese nuevamente el numero de la peticion: ");
                    stringnumPeticion = Console.ReadLine();
                }
                foreach (var item in ListaDePeticiones)
                {
                    if (int.Parse(stringnumPeticion) == item.Numero)
                    {
                        coincide = true;
                    }
                }
                if (coincide == false)
                {
                    Console.WriteLine("El numero de petición ingresado no corresponde a ninguna petición.\n");
                    Console.Write("Ingrese nuevamente el numero de la peticion: ");
                    stringnumPeticion = Console.ReadLine();
                }
            } while (coincide == false);
            int numPeticion;
            numPeticion = int.Parse(stringnumPeticion);
            return numPeticion;
        }
    }
}
