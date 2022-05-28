using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoDeSangre
{
    class Program
    {
        static void Main(string[] args)
        {

            Socio socio = new Socio();
            socio.SociosYaRegistrados();

            Menu menu = new Menu();

            Peticion peticion = new Peticion();

            Donacion donacion = new Donacion();

            BancoDeSangre bds = new BancoDeSangre();
            bds.BancoDeSangreYaRegistrados();

            SocioAsignado sa = new SocioAsignado();

            ValidarSocio vs = new ValidarSocio();

            menu.IniciarPrograma(socio, socio.ListaDeSocios, bds, peticion, donacion, peticion.ListaDePeticiones, sa, menu, vs, sa.SociosAsignados);

        }
    }
}
