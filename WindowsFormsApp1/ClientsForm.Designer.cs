
namespace WindowsFormsApp1
{
    partial class ClientsForm
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
            this.clientsTable = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clientsTable
            // 
            this.clientsTable.AllowUserToAddRows = false;
            this.clientsTable.AllowUserToDeleteRows = false;
            this.clientsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.clientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.clientNameCol,
            this.phoneCol,
            this.emailCol});
            this.clientsTable.Location = new System.Drawing.Point(13, 13);
            this.clientsTable.Name = "clientsTable";
            this.clientsTable.ReadOnly = true;
            this.clientsTable.RowHeadersVisible = false;
            this.clientsTable.Size = new System.Drawing.Size(641, 316);
            this.clientsTable.TabIndex = 0;
            this.clientsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsTable_CellClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(13, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idCol
            // 
            this.idCol.HeaderText = "Column1";
            this.idCol.Name = "idCol";
            this.idCol.ReadOnly = true;
            this.idCol.Visible = false;
            // 
            // clientNameCol
            // 
            this.clientNameCol.FillWeight = 5F;
            this.clientNameCol.HeaderText = "Имя клиента";
            this.clientNameCol.Name = "clientNameCol";
            this.clientNameCol.ReadOnly = true;
            // 
            // phoneCol
            // 
            this.phoneCol.FillWeight = 3F;
            this.phoneCol.HeaderText = "Телефон";
            this.phoneCol.Name = "phoneCol";
            this.phoneCol.ReadOnly = true;
            // 
            // emailCol
            // 
            this.emailCol.FillWeight = 3F;
            this.emailCol.HeaderText = "Эл. почта";
            this.emailCol.Name = "emailCol";
            this.emailCol.ReadOnly = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clientsTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView clientsTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailCol;
    }
}