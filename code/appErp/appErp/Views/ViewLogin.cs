///ETML
///Auteur : Alexis Rojas, Stefan Petrovic, David Dieperink, Samuel Hörler
///Date : 01.12.2021
///Description: 
using System;
using System.Data;
using System.Windows.Forms;

namespace appErp
{
    public partial class ViewLogin : Form
    {
        #region Attributs
        Controller _controller;
        #endregion

        #region Propriétés des attributs
        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        #region Constructeurs
        public ViewLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Methodes
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            Controller.Model.UserName = txtBoxUserName.Text;

            Controller.Model.Password = txtBoxPassword.Text;

            Controller.Model.DatabaseName = "db_erp";

            Controller.Model.Server = "192.168.109.130";

            if(Controller.Model.Open())
            {
                MessageBox.Show("Bien joué mon ami !");

                Controller.ViewTable.Show();
            }
        }
    }
}
