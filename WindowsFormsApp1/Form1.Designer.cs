
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.repair = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.tables = new System.Windows.Forms.ComboBox();
            this.rowImportResults = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // repair
            // 
            this.repair.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repair.Location = new System.Drawing.Point(187, 24);
            this.repair.Name = "repair";
            this.repair.Size = new System.Drawing.Size(208, 51);
            this.repair.TabIndex = 0;
            this.repair.Text = "Восстановить";
            this.repair.UseVisualStyleBackColor = true;
            this.repair.Click += new System.EventHandler(this.repair_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(12, 100);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(125, 38);
            this.import.TabIndex = 0;
            this.import.Text = "Импорт";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exit.Location = new System.Drawing.Point(27, 352);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(136, 42);
            this.exit.TabIndex = 0;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // tables
            // 
            this.tables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables.FormattingEnabled = true;
            this.tables.Location = new System.Drawing.Point(153, 101);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(449, 37);
            this.tables.TabIndex = 1;
            // 
            // rowImportResults
            // 
            this.rowImportResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowImportResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rowImportResults.FormattingEnabled = true;
            this.rowImportResults.ItemHeight = 25;
            this.rowImportResults.Location = new System.Drawing.Point(12, 145);
            this.rowImportResults.Name = "rowImportResults";
            this.rowImportResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.rowImportResults.Size = new System.Drawing.Size(590, 179);
            this.rowImportResults.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(204, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowImportResults);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.import);
            this.Controls.Add(this.repair);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button repair;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.ComboBox tables;
        private System.Windows.Forms.ListBox rowImportResults;
        private System.Windows.Forms.Label label1;
    }
}

