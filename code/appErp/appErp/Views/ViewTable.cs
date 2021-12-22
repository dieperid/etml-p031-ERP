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

        // ArrayList to getter and setter data  
        private static ArrayList ListID = new ArrayList();
        private static ArrayList ListFirstname = new ArrayList();
        private static ArrayList ListMail = new ArrayList();
        private static ArrayList ListRegion = new ArrayList();
        private static ArrayList ListNumberRange = new ArrayList();
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
            _controller.ViewLogin.Hide();
            GetData();
            if (ListID.Count > 0)
            {
                UpdateDatagrid();
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
                string query = "select id, name, email, region, numberrange from newtable";

                MySqlDataReader row;
                row = Controller.Model.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        ListID.Add(row["id"].ToString());
                        ListFirstname.Add(row["name"].ToString());
                        ListMail.Add(row["email"].ToString());
                        ListRegion.Add(row["region"].ToString());
                        ListNumberRange.Add(row["numberrange"].ToString());
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

        private void UpdateDatagrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = ListID[i];
                newRow.Cells[1].Value = ListFirstname[i];
                newRow.Cells[2].Value = ListMail[i];
                newRow.Cells[3].Value = ListRegion[i];
                newRow.Cells[4].Value = ListNumberRange[i];
                dataGridView1.Rows.Add(newRow);
            }
        }
        #endregion
    }
}
