///ETML
///Auteur : Alexis Rojas, Stefan Petrovic, David Dieperink, Samuel Hörler
///Date : 01.12.2021
///Description: 
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace appErp
{
    public class ModelDBConnection
    {
        #region Attributs
        Controller _controller;

        private MySqlConnection _connection;

        private string _myConnectionString;

        private string _server;

        private string _dataBaseName;

        private string _userName;

        private string _password;

        private string _strProvider;
        #endregion

        #region Propriétés des attributs
        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        public string MyConnectionString
        {
            get { return _myConnectionString; }
            set { _myConnectionString = value; }
        }
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        public string DatabaseName
        {
            get { return _dataBaseName; }
            set { _dataBaseName = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string strProvider
        {
            get { return ""; }
            set { _strProvider = value; }
        }
        private MySqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        #endregion

        #region Constructeurs
        public ModelDBConnection()
        {
        }
        #endregion

        #region Methodes
        public bool Open()
        {
            _strProvider = string.Format("Server=" + _server + ";database=" + _dataBaseName + ";UID=" + _userName + ";password=" + _password);
            _connection = new MySqlConnection(_strProvider);
            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Error ! " + er.Message, "Information");
            }
            return false;
        }

        public void Close()
        {
            _connection.Close();
            _connection.Dispose();
        }
        public DataTable GetData(string sqlCommand)
        {
            DataTable dtClient = new DataTable();

            using (MySqlConnection con = new MySqlConnection(_strProvider))
            {
                using (MySqlCommand cmd = new MySqlCommand(sqlCommand, con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtClient.Load(reader);
                }
            }
            return dtClient;
        }
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, _connection);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, _connection);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = _connection.BeginTransaction();
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
        #endregion
    }
}
