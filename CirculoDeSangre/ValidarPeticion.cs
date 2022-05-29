using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CirculoDeSangre
{
    public class ValidarPeticion
    {
        public DateTime ValidarFechaDePeticion(string stringfechaDePeticion)
        {
            //Solo acepta el formato dd/mm/aaaa.
            while (!Regex.Match(stringfechaDePeticion, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$").Success)
            {
                Console.Write("Ingrese nuevamente la fecha de petición: ");
                stringfechaDePeticion = Console.ReadLine();
            }
            DateTime fechaDePeticion;
            fechaDePeticion = Convert.ToDateTime(stringfechaDePeticion);
            return fechaDePeticion;
        }
        public DateTime ValidarFechaLimite(string stringfechaLimite, DateTime fechaDePeticion)
        {
            //Solo acepta el formato dd/mm/aaaa.
            while (!Regex.Match(stringfechaLimite, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$").Success)
            {
                Console.Write("Ingrese nuevamente la fecha limite: ");
                stringfechaLimite = Console.ReadLine();
            }
            while ((Convert.ToDateTime(stringfechaLimite)).Ticks <= fechaDePeticion.Ticks)
            {
                Console.Write("Ingrese nuevamente la fecha limite (debe ser mayor que la fecha de peticion): ");
                stringfechaLimite = Console.ReadLine();
            }
            DateTime fechaLimite;
            fechaLimite = Convert.ToDateTime(stringfechaLimite);
            return fechaLimite;
        }
        public int ValidarCantidadDeDonantes(string stringcantDonantes)
        {
            //Solo acepta numeros entre 1 y 999.
            while (!Regex.Match(stringcantDonantes, @"^\d{1,3}$").Success)
            {
                Console.Write("Ingrese nuevamente la cantidad de donantes: ");
                stringcantDonantes = Console.ReadLine();
            }
            while (Convert.ToInt32(stringcantDonantes) <= 0)
            {
                Console.Write("Ingrese nuevamente la cantidad de donantes: ");
                stringcantDonantes = Console.ReadLine();
            }
            int cantDonantes;
            cantDonantes = Convert.ToInt32(stringcantDonantes);
            return cantDonantes;
        }
        public string ValidarGrupo(string grupo)
        {
            //Acepta una o dos letras mayusculas, o un numero.
            //Las letras solo pueden ser A, B y AB, y el numero 0.
            while (!Regex.Match(grupo, @"^[A-Z]{1}$|^[A-Z]{2}$|^[0-9]{1}$").Success)
            {
                Console.Write("Ingrese nuevamente el grupo: ");
                grupo = Console.ReadLine();
            }
            while (grupo != "A" && grupo != "B" && grupo != "AB" && grupo != "0")
            {
                Console.Write("Ingrese nuevamente el grupo: ");
                grupo = Console.ReadLine();
            }
            return grupo;
        }
        public string ValidarFactor(string factor)
        {
            //Solo acepta un caracter.
            //Debe ser + o - .
            while (!Regex.Match(factor, @"^-{1}$|^\+{1}$").Success)
            {
                Console.Write("Ingrese nuevamente el factor: ");
                factor = Console.ReadLine();
            }
            return factor;
        }
    }
}
