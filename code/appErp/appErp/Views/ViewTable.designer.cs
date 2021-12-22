namespace appErp
{
    partial class ViewTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBxNomTable = new System.Windows.Forms.ComboBox();
            this.lblNomTable = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNomTable);
            this.panel1.Controls.Add(this.cBxNomTable);
            this.panel1.Location = new System.Drawing.Point(12, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 59);
            this.panel1.TabIndex = 1;
            // 
            // cBxNomTable
            // 
            this.cBxNomTable.FormattingEnabled = true;
            this.cBxNomTable.Items.AddRange(new object[] {
            "employees",
            "regions",
            "countries",
            "locations",
            "job_history",
            "jobs",
            "departments"});
            this.cBxNomTable.Location = new System.Drawing.Point(12, 27);
            this.cBxNomTable.Name = "cBxNomTable";
            this.cBxNomTable.Size = new System.Drawing.Size(121, 21);
            this.cBxNomTable.TabIndex = 1;
            this.cBxNomTable.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // lblNomTable
            // 
            this.lblNomTable.AutoSize = true;
            this.lblNomTable.Location = new System.Drawing.Point(30, 11);
            this.lblNomTable.Name = "lblNomTable";
            this.lblNomTable.Size = new System.Drawing.Size(81, 13);
            this.lblNomTable.TabIndex = 3;
            this.lblNomTable.Text = "Nom de la table";
            this.lblNomTable.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ViewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 455);
            this.Controls.Add(this.panel1);
            this.Name = "ViewTable";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNomTable;
        private System.Windows.Forms.ComboBox cBxNomTable;
    }
}