
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
            this.SuspendLayout();
            // 
            // repair
            // 
            this.repair.Location = new System.Drawing.Point(119, 24);
            this.repair.Name = "repair";
            this.repair.Size = new System.Drawing.Size(188, 35);
            this.repair.TabIndex = 0;
            this.repair.Text = "Восстановить";
            this.repair.UseVisualStyleBackColor = true;
            this.repair.Click += new System.EventHandler(this.repair_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(27, 98);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(110, 32);
            this.import.TabIndex = 0;
            this.import.Text = "Импорт";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(27, 233);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(136, 42);
            this.exit.TabIndex = 0;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // tables
            // 
            this.tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables.FormattingEnabled = true;
            this.tables.Location = new System.Drawing.Point(160, 99);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(262, 32);
            this.tables.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 287);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.import);
            this.Controls.Add(this.repair);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button repair;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.ComboBox tables;
    }
}

