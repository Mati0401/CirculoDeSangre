using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    internal class Socio
    {
        private string grupoSanguineo;
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fechaDeNacimiento;
        private string domicilio;
        private string localidad;
        private string categoria;
        private bool enfermedad;
        private bool tomaMedicacion;
        private string medicamento;
        private string email;
        private string contraseña;

        private string[,] arregloDeSocios = new string[50, 13];
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public bool Enfermedad { get => enfermedad; set => enfermedad = value; }
        public bool TomaMedicacion { get => tomaMedicacion; set => tomaMedicacion = value; }
        public string Medicamento { get => medicamento; set => medicamento = value; }
        public string Email { get => email; set => email = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string[,] ArregloDeSocios { get => arregloDeSocios; set => arregloDeSocios = value; }
        public void SociosYaRegistrados()
        {
            //SOCIO 1
            arregloDeSocios[0, 0] = "A-";
            arregloDeSocios[0, 1] = "Matías";
            arregloDeSocios[0, 2] = "Rodriguez";
            arregloDeSocios[0, 3] = "12345678";
            arregloDeSocios[0, 4] = "4/1/2001";
            arregloDeSocios[0, 5] = "Cabrera";
            arregloDeSocios[0, 6] = "San Francisco";
            arregloDeSocios[0, 7] = "activo";
            arregloDeSocios[0, 8] = "false";
            arregloDeSocios[0, 9] = "false";
            arregloDeSocios[0, 10] = "no consume ninguna medicacion";
            arregloDeSocios[0, 11] = "matiasr@gmail.com";
            arregloDeSocios[0, 12] = "1234";
            //SOCIO 2
            arregloDeSocios[1, 0] = "B-";
            arregloDeSocios[1, 1] = "Juan";
            arregloDeSocios[1, 2] = "Perez";
            arregloDeSocios[1, 3] = "47659345";
            arregloDeSocios[1, 4] = "20/03/1999";
            arregloDeSocios[1, 5] = "Roca";
            arregloDeSocios[1, 6] = "San Francisco";
            arregloDeSocios[1, 7] = "pasivo";
            arregloDeSocios[1, 8] = "true";
            arregloDeSocios[1, 9] = "true";
            arregloDeSocios[1, 10] = "glimepirida";
            arregloDeSocios[1, 11] = "juanp@gmail.com";
            arregloDeSocios[1, 12] = "0000";
        } //PARA PROBAR INICIAR SESION
        public void VerificarGrupoSanguineo()
        {
            string msgRechazar = "\nUsted no puede ingresar al circulo. Solo se permite sangre RH Negativo";
            string msgAceptar = "\nUsted es aceptado en el circulo. Complete el resto de los datos.\n";
            bool error = false;
            do
            {
                Console.Write("Ingrese su grupo sanguineo (letra en mayúscula y simbolo [+ o -]) : "); //SOLO SE ACEPTA RH NEGATIVO
                GrupoSanguineo = Console.ReadLine();
                error = false;
                switch (grupoSanguineo)
                {
                    case "A+":
                        Console.WriteLine(msgRechazar);
                        Environment.Exit(0);
                        break;
                    case "A-":
                        Console.WriteLine(msgAceptar);
                        break;
                    case "B+":
                        Console.WriteLine(msgRechazar);
                        Environment.Exit(0);
                        break;
                    case "B-":
                        Console.WriteLine(msgAceptar);
                        break;
                    case "AB+":
                        Console.WriteLine(msgRechazar);
                        Environment.Exit(0);
                        break;
                    case "AB-":
                        Console.WriteLine(msgAceptar);
                        break;
                    case "0+":
                        Console.WriteLine(msgRechazar);
                        Environment.Exit(0);
                        break;
                    case "0-":
                        Console.WriteLine(msgAceptar);
                        break;
                    default:
                        Console.WriteLine("ERROR: El grupo sanguineo ingresado no existe");
                        error = true;
                        break;
                }
            } while (error == true);
        } //VERIFICA QUE SEA RH NEGATIVO
        public void RegistrarDatosDeLaPersona(int num)
        {
            VerificarGrupoSanguineo();
            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido: ");
            apellido = Console.ReadLine();
            Console.Write("Ingrese su DNI sin puntos: ");
            dni = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese su fecha de nacimiento con el formato **/**/**** : ");
            fechaDeNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese su domicilio: ");
            domicilio = Console.ReadLine();
            Console.Write("Ingrese su localidad: ");
            localidad = Console.ReadLine();
            Console.Write("Posee alguna enfermedad cronica (true o false): ");
            enfermedad = Convert.ToBoolean(Console.ReadLine());
            if (enfermedad == true)
            {
                Console.Write("Toma alguna medicacion (true o false): ");
                tomaMedicacion = Convert.ToBoolean(Console.ReadLine());
                if (tomaMedicacion == true)
                {
                    Console.Write("Ingrese que medicacion consume: ");
                    medicamento = Console.ReadLine();
                }
                else
                {
                    medicamento = "no consume ninguna medicacion";
                }
            }
            else
            {
                tomaMedicacion = false;
                medicamento = "no consume ninguna medicacion";
            }
            Console.Clear();
            Console.WriteLine("\n- - - - - - - - - - - - TÉRMINOS Y CONDICIONES DEL CIRCULO DE SANGRE - - - - - - - - - - - -\n");
            MostrarTerminosYcondiciones();
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
            Console.Write("\nEsta de acuerdo con las condiciones (true o false): ");
            bool c = Convert.ToBoolean(Console.ReadLine());
            Console.Clear();
            if (c == true)
            {
                Console.WriteLine("CREDENCIALES DE INICIO DE SESION\n");
                Console.Write("Ingrese su email: ");
                email = Console.ReadLine();
                Console.Write("Ingrese una contraseña: ");
                contraseña = Console.ReadLine();
                CalcularCategoria();
                CargarArregloConDatosDelSocio(num);
            }
            else
            {
                Console.WriteLine("No puede entrar al circulo.");
                Environment.Exit(0);
            }
        }
        public string CalcularCategoria()
        {
            int edad = DateTime.Today.AddTicks(-fechaDeNacimiento.Ticks).Year - 1;
            if (edad >= 18 && edad <= 56 && enfermedad == false)
            {
                categoria = "activo";
            }
            else
            {
                categoria = "pasivo";
            }
            return categoria;
        } //PASIVO O ACTIVO
        public void MostrarTerminosYcondiciones()
        {
            Console.WriteLine("El circulo de sangre RH Negativo reúne a todas las personas que posean el factor RH " +
            "Negativo, sea cual fuera su grupo sanguíneo, logrando de esta manera un sistema de autoprotección " +
            "mediante el cual los asociados, podrán donarse sangre entre si para el momento en que así lo " +
            "necesiten. \nExisten dos categorías de socios, activos y pasivos, los activos son quienes están " +
            "en condiciones de donar sangre y se determina por la edad (entre 18 y 56 años); los pasivos son " +
            "los menores a 18 años y mayores a 56 años. Además, se considera pasivos a quienes posean una enfermedad " +
            "crónica y deban tomar medicamentos de forma permanente. \nPara poder pertencer al Circulo las personas " +
            "se deben asociar y pagar una cuota de manera mensual.");
        }
        public void CargarArregloConDatosDelSocio(int num)
        {
            arregloDeSocios[num, 0] = grupoSanguineo;
            arregloDeSocios[num, 1] = nombre;
            arregloDeSocios[num, 2] = apellido;
            arregloDeSocios[num, 3] = dni.ToString();
            arregloDeSocios[num, 4] = fechaDeNacimiento.ToString();
            arregloDeSocios[num, 5] = domicilio;
            arregloDeSocios[num, 6] = localidad;
            arregloDeSocios[num, 7] = categoria;
            arregloDeSocios[num, 8] = enfermedad.ToString();
            arregloDeSocios[num, 9] = tomaMedicacion.ToString();
            arregloDeSocios[num, 10] = medicamento;
            arregloDeSocios[num, 11] = email;
            arregloDeSocios[num, 12] = contraseña;
        } //SE CARGAN LOS DATOS EN EL ARREGLO (Si acepta los terminos y condiones)
        public void IniciarSesion(int num)
        {
            Console.Clear();
            bool emailExiste, usuarioLogueado, contraCorrecta;
            do
            {
                emailExiste = true;
                usuarioLogueado = false;
                Console.Write("Ingrese su email: ");
                string isEmail = Console.ReadLine();
                for (int i = 0; i < num; i++)
                {
                    if (isEmail == arregloDeSocios[i, 11])
                    {
                        do
                        {
                            contraCorrecta = true;
                            Console.Write("Ingrese su contraseña: ");
                            string isContraseña = Console.ReadLine();
                            if (isContraseña == arregloDeSocios[i, 12])
                            {
                                Console.Clear();
                                Console.WriteLine("Usuario logueado correctamente.\n");
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
                    Console.WriteLine("Usuario Inexistente\n");
                }
            } while (emailExiste == false);
        }
        public void MostrarArregloDeSocios(int num)
        {
            Console.Clear();
            Console.WriteLine("_____________________________________ LISTADO DE SOCIOS ______________________________________________\n");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i + 1 + ". Grupo Sanguineo: " + arregloDeSocios[i, 0] + "\tNombre: " + arregloDeSocios[i, 1] +
                    " " + arregloDeSocios[i, 2] + "\tDNI: " + arregloDeSocios[i, 3] + "\n");
                Console.WriteLine("   Fecha de nacimiento: " + arregloDeSocios[i, 4] + "\tDomicilio: " + arregloDeSocios[i, 5] +
                    "\tCiudad: " + arregloDeSocios[i, 6] + "\n");
                Console.WriteLine("   Enfermedad Crónica: " + arregloDeSocios[i, 8] + "\tToma medicacion: " + arregloDeSocios[i, 9] +
                    "\tMedicacion: " + arregloDeSocios[i, 10] + "\n");
                Console.WriteLine("   Categoria: " + arregloDeSocios[i, 7] + "\n");
                Console.WriteLine("   Credenciales de Inicio ==> Email: " + arregloDeSocios[i, 11] + "\tContraseña: " +
                    arregloDeSocios[i, 12] + "\n");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");
            }
            Console.WriteLine("\n______________________________________________________________________________________________________\n");
        }
    }
}
