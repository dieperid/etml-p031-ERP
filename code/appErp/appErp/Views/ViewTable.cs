using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections;

namespace appErp
{
    public partial class ViewTable : Form
    {
        #region Attributs
        Controller _controller;

        //arraylist to getter and setter data  
        private static ArrayList ListID = new ArrayList();
        private static ArrayList ListFirstname = new ArrayList();
        private static ArrayList ListLastname = new ArrayList();
        private static ArrayList ListTelephone = new ArrayList();
        private static ArrayList ListAddress = new ArrayList();
        #endregion

        #region Propriétés des attributs
        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        #region Constructeurs
        public ViewTable()
        {
            InitializeComponent();
        }
        #endregion

        #region Methodes
        private void Form2_Load(object sender, EventArgs e)
        {
            GetData();
            if (ListID.Count > 0)
            {
                updateDatagrid();
            }
            else
            {
                MessageBox.Show("Data not found");
            }
        }

        private void GetData()
        {
            try
            {
                string query = "select id,name,email,region,numberrange from newtable";

                MySqlDataReader row;
                row = Controller.Model.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        ListID.Add(row["id"].ToString());
                        ListFirstname.Add(row["name"].ToString());
                        ListLastname.Add(row["email"].ToString());
                        ListTelephone.Add(row["region"].ToString());
                        ListAddress.Add(row["numberrange"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

                Controller.Model.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void updateDatagrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = ListID[i];
                newRow.Cells[1].Value = ListFirstname[i];
                newRow.Cells[2].Value = ListLastname[i];
                newRow.Cells[3].Value = ListTelephone[i];
                dataGridView1.Rows.Add(newRow);
            }
        }
        #endregion
    }
}
