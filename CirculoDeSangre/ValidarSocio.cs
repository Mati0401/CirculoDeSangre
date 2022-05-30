using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CirculoDeSangre
{
    public class ValidarSocio
    {
        public string ValidarGrupoSanguineo(string grupoSanguineo)
        {
            while (!Regex.Match(grupoSanguineo, @"(A|B|AB|O)(\+|-)").Success)
            {
                Console.WriteLine("Ingrese nuevamente el grupo sanguineo (letra en mayuscula y simbolo + o -): ");
                grupoSanguineo = Console.ReadLine();
            }
            return grupoSanguineo;
        }
        public string ValidarNombre(string nombre)
        {
            //El nombre debe tener letras mayusculas o minusculas, entre 3 y 10 caracteres.
            //La persona puede tener 1 o 2 nombres.
            while (!Regex.Match(nombre, @"^[A-Za-z]{3,10}$|^[A-Za-z]{3,10}\s[A-Za-z]{3,10}$").Success)
            {
                Console.Write("Ingrese nuevamente el nombre: ");
                nombre = Console.ReadLine();
            }
            return nombre;
        }
        public string ValidarApellido(string apellido)
        {
            //El apellido debe tener letras mayusculas o minusculas, entre 3 y 12 caracteres.
            //La persona puede tener 1 o 2 apellidos.
            while (!Regex.Match(apellido, @"^[A-Za-z]{3,12}$|^[A-Za-z]{3,12}\s[A-Za-z]{3,12}$").Success)
            {
                Console.Write("Ingrese nuevamente el apellido: ");
                apellido = Console.ReadLine();
            }
            return apellido;
        }
        public int ValidarDni(string stringdni)
        {
            //El dni debe tener 8 numeros.
            while (!Regex.Match(stringdni, @"^\d{8}$").Success)
            {
                Console.Write("Ingrese nuevamente el dni: ");
                stringdni = Console.ReadLine();
            }
            int dni;
            dni = int.Parse(stringdni);
            return dni;
        }
        public DateTime ValidarFechaDeNacimiento(string stringfechaDeNacimiento)
        {
            //Solo acepta el formato dd/mm/aaaa.
            //La persona no puede tener mas de 120 años, ni haber naciedo en el futuro.
            while (!Regex.Match(stringfechaDeNacimiento, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$").Success)
            {
                Console.Write("Ingrese nuevamente la fecha de nacimiento: ");
                stringfechaDeNacimiento = Console.ReadLine();
            }
            while (Convert.ToDateTime(stringfechaDeNacimiento).Ticks <= (new DateTime(1902,01,01)).Ticks 
                || Convert.ToDateTime(stringfechaDeNacimiento).Ticks > (DateTime.Today).Ticks)
            {
                Console.Write("Ingrese nuevamente la fecha de nacimiento: ");
                stringfechaDeNacimiento = Console.ReadLine();
            }
            DateTime fechaDeNacimiento;
            fechaDeNacimiento = Convert.ToDateTime(stringfechaDeNacimiento);
            return fechaDeNacimiento;   
        }
        public string ValidarDomicilio(string domicilio)
        {
            //Solo acepta letras y numeros, una o dos palabras con 3 a 12 caracteres y un numero con 3 a 6 caracteres.
            while (!Regex.Match(domicilio, @"^[a-zA-Z]{3,12}\s[0-9]{3,6}$|^[a-zA-Z]{3,12}\s[a-zA-Z]{3,12}\s[0-9]{3,6}$").Success)
            {
                Console.Write("Ingrese nuevamente el domicilio: ");
                domicilio = Console.ReadLine();
            }
            return domicilio;
        }
        public string ValidarLocalidad(string localidad)
        {
            //Solo acepta letras, una o dos palabras con 3 a 12 caracteres.
            while (!Regex.Match(localidad, @"^[a-zA-Z]{3,12}$|^[a-zA-Z]{3,12}\s[a-zA-Z]{3,12}$").Success)
            {
                Console.Write("Ingrese nuevamente la localidad: ");
                localidad = Console.ReadLine();
            }
            return localidad;
        }
        public string ValidarTelefono(string telefono)
        {
            //Solo acepta numeros.
            //Formato 4 numeros - 6 numeros.
            while (!Regex.Match(telefono, @"^\d{4}\-\d{6}$").Success)
            {
                Console.Write("Ingrese nuevamente el telefono: ");
                telefono = Console.ReadLine();
            }
            return telefono;
        }
        public bool ValidarEnfermedad(string stringenfermedad)
        {
            while(!Regex.Match(stringenfermedad, @"true|false").Success)
            {
                Console.WriteLine("Ingrese nuevamente si posee una enfermedad(true o false): ");
                stringenfermedad = Console.ReadLine();
            }
            bool enfermedad;
            enfermedad = Convert.ToBoolean(stringenfermedad);
            return enfermedad;
        }
        public bool ValidarTomaMedicacion(string stringtomaMedicacion)
        {
            while(!Regex.Match(stringtomaMedicacion, @"true|false").Success)
            {
                Console.WriteLine("Ingrese nuevamente si toma alguna medicacion(true o false): ");
                stringtomaMedicacion = Console.ReadLine();
            }
            bool tomaMedicacion;
            tomaMedicacion = Convert.ToBoolean(stringtomaMedicacion);
            return tomaMedicacion;
        }
        public string ValidarMedicamento(string medicamento)
        {
            //Solo acepta una o dos palabras con 1 a 15 caracteres.
            while (!Regex.Match(medicamento, @"^[A-Za-z]{1,15}$|^[A-Za-z]{1,15}\s[A-Za-z]{1,15}$").Success)
            {
                Console.Write("Ingrese nuevamente el nombre: ");
                medicamento = Console.ReadLine();
            }
            return medicamento;
        }
        public string ValidarEmail(string email)
        {
            while (!Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                Console.Write("Ingrese nuevamente el email: ");
                email = Console.ReadLine();
            }
            return email;
        }
        public string ValidarContraseña(string contraseña)
        {
            //Solo acepta letras y numeros.
            //Debe tener entre 8 y 20 caracteres.
            while (!Regex.Match(contraseña, @"^[A-Za-z0-9]{8,20}$").Success)
            {
                Console.Write("Ingrese nuevamente la contraseña: ");
                contraseña = Console.ReadLine();
            }
            return contraseña;
        }
        public bool ValidarAceptarCondiciones(string stringresp)
        {
            while (!Regex.Match(stringresp, @"true|false").Success)
            {
                Console.WriteLine("Ingrese nuevamente si acepta o no las condiciones(true o false): ");
                stringresp = Console.ReadLine();
            }
            bool resp;
            resp = Convert.ToBoolean(stringresp);
            return resp;
        }
    }
}
