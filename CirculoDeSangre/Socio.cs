using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class Socio
    {
        //ATRIBUTOS 

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

        //CAMPOS ENCAPSULADOS 

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


        public static List<Socio> listaDeSocios = new List<Socio>();

        //METODOS

        //DATOS DEL SOCIO
        public void DatosDelSocio()
        {
            Console.WriteLine("\nNombre y apellido: " + Nombre + " " + Apellido);
            Console.WriteLine("DNI: " + Dni);
            Console.WriteLine("Fecha de nacimiento: " + FechaDeNacimiento.ToShortDateString());
            Console.WriteLine("Domicilio y localidad: " + Domicilio + ", " + Localidad);
            Console.WriteLine("Enfermedad, toma medicacion y medicamento: " + Enfermedad + ", " + TomaMedicacion + ", " + Medicamento);
            Console.WriteLine("Email y contraseña: " + Email + ", " + Contraseña);
            Console.WriteLine("Categoria: " + Categoria);
        }

        //SOCIOS REGISTRADOS PREVIAMENTE
        public void SociosYaRegistrados()
        {
            //SOCIO 1
            listaDeSocios.Add(new Socio()
            {
                Nombre = "Fernando",
                Apellido = "Ramirez",
                Dni = 14759956,
                FechaDeNacimiento = new DateTime(1965, 09, 15),
                Domicilio = "Roca 767",
                Localidad = "San Francisco",
                Enfermedad = false,
                TomaMedicacion = false,
                Medicamento = "no consume ningun medicamento",
                Email = "ferramirez@gmail.com",
                Contraseña = "fer12345",
                Categoria = CalcularCategoria()
            });
            //SOCIO 2
            listaDeSocios.Add(new Socio()
            {
                Nombre = "Hugo",
                Apellido = "Ballesteros",
                Dni = 18954940,
                FechaDeNacimiento = new DateTime(1968, 09, 08),
                Domicilio = "Cabrera 1678",
                Localidad = "San Francisco",
                Enfermedad = true,
                TomaMedicacion = true,
                Medicamento = "glimepirida",
                Email = "hugob@gmail.com",
                Contraseña = "hug12345",
                Categoria = CalcularCategoria()
            });
            //SOCIO 3
            listaDeSocios.Add(new Socio()
            {
                Nombre = "Juan",
                Apellido = "Guzman",
                Dni = 46435756,
                FechaDeNacimiento = new DateTime(2005,06,21),
                Domicilio = "Honduras 654",
                Localidad = "San Francisco",
                Enfermedad = false,
                TomaMedicacion = false,
                Medicamento = "no consume ninguna medicacion",
                Email = "juang@gmail.com",
                Contraseña = "jua12345",
                Categoria = CalcularCategoria()
            });
        }

        //LA PERSONA INGRESA LOS DATOS 
        public void RegistrarDatosDeLaPersona()
        {
            VgrupoSanguineo();
            void VgrupoSanguineo()
            {
                string msgRechazar = "\nUsted no puede ingresar al circulo. Solo se permite sangre RH Negativo";
                string msgAceptar = "\nUsted es aceptado en el circulo. Complete el resto de los datos.\n";
                bool error = false;
                do
                {
                    Console.Write("Ingrese su grupo sanguineo (letra en mayúscula y simbolo + o -) : "); //SOLO SE ACEPTA RH NEGATIVO
                    grupoSanguineo = Console.ReadLine();
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

            Vnombre();
            void Vnombre()
            {
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine();
                if (nombre == "")
                {
                    Console.WriteLine("\nNo puede dejar el campo nombre vacío.\n");
                    Vnombre();
                }
            }

            Vapellido();
            void Vapellido()
            {
                Console.Write("\nIngrese su apellido: ");
                apellido = Console.ReadLine();
                if (apellido == "")
                {
                    Console.WriteLine("\nNo puede dejar el campo apellido vacío.\n");
                    Vapellido();
                }
            }

            Vdni();
            void Vdni()
            {
                try
                {
                    Console.Write("\nIngrese su DNI sin puntos: ");
                    dni = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    Vdni();
                }

            }

            Vfecha();
            void Vfecha()
            {
                try
                {
                    Console.Write("\nIngrese su fecha de nacimiento con el formato **/**/**** : ");
                    fechaDeNacimiento = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato Incorrecto.");
                    Vfecha();
                }
            }

            Vdomicilio();
            void Vdomicilio()
            {
                Console.Write("\nIngrese su domicilio: ");
                domicilio = Console.ReadLine();
                if (domicilio == "")
                {
                    Console.WriteLine("\nNo puede dejar el campo domicilio vacío.\n");
                    Vdomicilio();
                }
            }

            Vlocalidad();
            void Vlocalidad()
            {
                Console.Write("\nIngrese su localidad: ");
                localidad = Console.ReadLine();
                if (localidad == "")
                {
                    Console.WriteLine("\nNo puede dejar el campo localidad vacío.\n");
                    Vlocalidad();
                }
            }

            Venfermedad();
            void Venfermedad()
            {
                try
                {
                    Console.Write("\nPosee alguna enfermedad cronica (true o false): ");
                    enfermedad = Convert.ToBoolean(Console.ReadLine());
                    if (enfermedad == true)
                    {
                        VtomaMedicacion();
                    }
                    else
                    {
                        tomaMedicacion = false;
                        medicamento = "no consume ninguna medicacion";
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorrecto.");
                    Venfermedad();
                }
            }

            void VtomaMedicacion()
            {
                try
                {
                    Console.Write("\nToma alguna medicacion (true o false): ");
                    tomaMedicacion = Convert.ToBoolean(Console.ReadLine());
                    if (tomaMedicacion == true)
                    {
                        Vmedicamento();

                    }
                    else
                    {
                        medicamento = "no consume ninguna medicacion";
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorrecto.");
                    VtomaMedicacion();
                }
            }

            void Vmedicamento()
            {
                Console.Write("\nIngrese que medicacion consume: ");
                medicamento = Console.ReadLine();
                if (medicamento == "")
                {
                    Console.WriteLine("No puede dejar el campo medicamento vacío.");
                    Vmedicamento();
                }
            }

            Console.Clear();

            Console.WriteLine("\n- - - - - - - - - - - - - - - REGLAMENTO DEL CIRCULO DE SANGRE - - - - - - - - - - - - - - - -\n");
            MostrarReglamento();
            void MostrarReglamento()
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
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");

            Vresp();
            void Vresp()
            {
                try
                {
                    Console.Write("\nEsta de acuerdo con las condiciones (true o false): ");
                    bool c = Convert.ToBoolean(Console.ReadLine());
                    Console.Clear();
                    if (c == true)
                    {
                        Console.WriteLine("CREDENCIALES DE INICIO DE SESION\n");
                        Console.Write("Ingrese su email: ");
                        email = Console.ReadLine();
                        Console.Write("\nIngrese una contraseña: ");
                        contraseña = Console.ReadLine();
                        CalcularCategoria();
                        CargarListado();
                    }
                    else
                    {
                        Console.WriteLine("No puede entrar al circulo.");
                        Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato incorrecto.");
                    Vresp();
                }
            }
        }

        //SE CARGAN LOS DATOS EN LA LISTA SI LA PERSONA ACEPTA EL REGLAMENTO
        public void CargarListado()
        {
            listaDeSocios.Add(new Socio()
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                FechaDeNacimiento = fechaDeNacimiento,
                Domicilio = domicilio,
                Localidad = localidad,
                Enfermedad = enfermedad,
                TomaMedicacion = tomaMedicacion,
                Medicamento = medicamento,
                Email = email,
                Contraseña = contraseña,
                Categoria = CalcularCategoria()
            });
        }

        //MUESTRA TODOS LOS DATOS DE LOS SOCIOS (DE PREUBA)
        public void MostrarListado()
        {
            foreach (var item in listaDeSocios)
            {
                item.DatosDelSocio();
            }
        }
        
        //PASIVO O ACTIVO
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
        } 

        //LOGUEARSE CON EMAIL Y CONTRASEÑA
        public void IniciarSesion()
        {
            Console.Clear();
            bool emailExiste, usuarioLogueado, contraCorrecta;
            do
            {
                emailExiste = true;
                usuarioLogueado = false;
                Console.Write("Ingrese su email: ");
                string isEmail = Console.ReadLine();
                foreach (Socio item in listaDeSocios)
                {
                    if (isEmail == item.Email)
                    {
                        do
                        {
                            contraCorrecta = true;
                            Console.Write("Ingrese su contraseña: ");
                            string isContraseña = Console.ReadLine();
                            if (isContraseña == item.Contraseña)
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
    }
}
