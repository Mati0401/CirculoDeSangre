using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    public class SocioAsignado
    {
        //ATRIBUTOS

        private int asNumPeticion;
        private int asDni;
        private string asNombre;
        private string asApellido;

        //CAMPOS ENCAPSULADOS

        public int AsNumPeticion { get => asNumPeticion; set => asNumPeticion = value; }
        public int AsDni { get => asDni; set => asDni = value; }
        public string AsNombre { get => asNombre; set => asNombre = value; }
        public string AsApellido { get => asApellido; set => asApellido = value; }


        //LISTADO DE SOCIOS ASIGNADOS

        private List<SocioAsignado> sociosAsignados = new List<SocioAsignado>();
        public List<SocioAsignado> SociosAsignados { get => sociosAsignados; set => sociosAsignados = value; }
        

        //METODOS

        //DATOS DEL SOCIO ASIGNADO
        public void DatosSociosAsignados()
        {
            Console.WriteLine("DNI: " + AsDni + ", Nombre: " + AsNombre + " " + AsApellido + ".");
        }

        //ASIGNAR SOCIOS PARA QUE VAYAN A DONAR
        string gs;
        public void AsignarSocios(List<Socio> ListaDeSocios, List<Peticion>ListaDePeticiones, Peticion peticion)
        {
            gs = peticion.Grupo + peticion.Factor;

            foreach (var item in ListaDeSocios)
            {
                if (item.GrupoSanguineo == gs && item.Condicion == "disponible")
                {
                    SociosAsignados.Add(new SocioAsignado()
                    {
                        AsNumPeticion = peticion.Numero,
                        AsDni = item.Dni,
                        AsNombre = item.Nombre,
                        AsApellido = item.Apellido
                    });
                }
            }  
        }
        //MOSTRAR LISTADO DE SOCIOS ASIGNADOS PARA DONAR
        public void MostrarSociosAsignados(Peticion peticion)
        {
            for (int i = 1; i <= peticion.Numero; i++)
            {
                Console.WriteLine("PETICION " + i + "\n");
                foreach (var item in SociosAsignados)
                {
                    if (item.AsNumPeticion == i)
                    {
                        item.DatosSociosAsignados();
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
