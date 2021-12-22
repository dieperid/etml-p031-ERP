///ETML
///Auteur : Alexis Rojas, Stefan Petrovic, David Dieperink, Samuel Hörler
///Date : 01.12.2021
///Description: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appErp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Création de la vue login
            ViewLogin aView = new ViewLogin();

            //Création de la vue tableau
            ViewTable bView = new ViewTable();

            //Création du modèle
            ModelDBConnection aModel = new ModelDBConnection();

            //Création du controlleur
            Controller aController = new Controller(aView, aModel , bView);

            Application.Run(aView);
        }
    }
}
