using Market.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string Nd = Parser.Parse().GetAwaiter().GetResult();
            if (Nd != "ban")
            {
                Nd= Nd.Replace(" ", "");
                string tmp = "";
                for (int i =0; i < 4; i++)
                {
                    tmp += Nd[i];
                }
                DateTime today = DateTime.Today;
                Price p = new Price();

                p.date = today.ToString("d");
                p.prise = Convert.ToInt32(tmp);

                DataHandler.InsertData(p);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
