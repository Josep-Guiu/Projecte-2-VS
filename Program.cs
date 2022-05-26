using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Menu());
            //Application.Run(new AdministrarGrupos());
            //Application.Run(new Comunicados());
            //Application.Run(new ModificarGrupos());
            //Application.Run(new FormReports());
            //Application.Run(new HorarisGrup());
        }
    }
}
