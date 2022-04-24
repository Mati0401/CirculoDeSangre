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
            menu.IniciarPrograma(socio);
        }
    }
}
