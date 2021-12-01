///ETML
///Auteur : Alexis Rojas, Stefan Petrovic, David Dieperink, Samuel Hörler
///Date : 01.12.2021
///Description: 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appErp
{
    public partial class View : Form
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
        public View()
        {
            InitializeComponent();
        }
        #endregion

        #region Methodes
        #endregion

    }
}
