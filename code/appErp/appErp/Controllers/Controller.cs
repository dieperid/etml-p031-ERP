///ETML
///Auteur : Alexis Rojas, Stefan Petrovic, David Dieperink, Samuel Hörler
///Date : 01.12.2021
///Description: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appErp
{
    public class Controller
    {
        #region Attributs
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Model _model;
        View _view;
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        public Controller(View view, Model model)
        {
            _view = view;
            _model = model;
            _view.Controller = this;           
            _model.Controller = this;
        }
        #endregion

        #region Methodes
        #endregion

    }
}
