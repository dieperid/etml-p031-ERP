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
        ModelDBConnection _model;
        ViewLogin _view;
        ViewTable _viewTable;
        #endregion

        #region Propriétés des attributs
        public ModelDBConnection Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public ViewTable ViewTable
        {
            get { return _viewTable; }
            set { _viewTable = value; }
        }
        #endregion

        #region Constructeurs
        public Controller(ViewLogin view, ModelDBConnection model, ViewTable viewTable)
        {
            _view = view;
            _model = model;
            _viewTable = viewTable;
            _view.Controller = this;           
            _model.Controller = this;
            _viewTable.Controller = this;
        }
        #endregion

        #region Methodes
        #endregion

    }
}
