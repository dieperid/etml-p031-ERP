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
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
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
        private void InitializeDataGridView(string nomTable)
        {
            try
            {
                dataGridView1.Location = new Point(200,200);
                // Set up the DataGridView.
                dataGridView1.Dock = DockStyle.Fill;

                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;

                // Set up the data source.
                string req = "SELECT * FROM " + nomTable;
                bindingSource1.DataSource = _controller.Model.GetData(req);

                dataGridView1.DataSource = bindingSource1;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string to a Northwind" +
                    " database accessible to your system.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            _controller.ViewLogin.Hide();
            UpdateGrid("employees");          
            //if (ListID.Count > 0)
            //{
            //    UpdateDatagrid();
            //}
            //else
            //{
            //    MessageBox.Show("Data not found");
            //}
        }
        private void UpdateGrid(string nomTable)
        {
            dataGridView1.Dock = DockStyle.Fill;
            this.Controls.Add(dataGridView1);
            InitializeDataGridView(nomTable);
        }
        //private void GetData()
        //{
        //    try
        //    {
        //        string query = "select id, name, email, region, numberrange from newtable";

        //        MySqlDataReader row;
        //        row = Controller.Model.ExecuteReader(query);
        //        if (row.HasRows)
        //        {
        //            while (row.Read())
        //            {
        //                ListID.Add(row["id"].ToString());
        //                ListFirstname.Add(row["name"].ToString());
        //                ListMail.Add(row["email"].ToString());
        //                ListRegion.Add(row["region"].ToString());
        //                ListNumberRange.Add(row["numberrange"].ToString());
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Data not found");
        //        }

        //        Controller.Model.Close();
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.ToString());
        //    }

        //}

        //private void UpdateDatagrid()
        //{
        //    dataGridView1.Rows.Clear();
        //    for (int i = 0; i < ListID.Count; i++)
        //    {
        //        DataGridViewRow newRow = new DataGridViewRow();

        //        newRow.CreateCells(dataGridView1);
        //        newRow.Cells[0].Value = ListID[i];
        //        newRow.Cells[1].Value = ListFirstname[i];
        //        newRow.Cells[2].Value = ListMail[i];
        //        newRow.Cells[3].Value = ListRegion[i];
        //        newRow.Cells[4].Value = ListNumberRange[i];
        //        dataGridView1.Rows.Add(newRow);
        //    }
        //}
        #endregion

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid(cBxNomTable.Text);
        }
    }
}
