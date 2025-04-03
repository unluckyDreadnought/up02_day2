
namespace WindowsFormsApp1
{
    partial class ProjectForm
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
            this.linesCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchLine = new System.Windows.Forms.TextBox();
            this.projTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.projTable)).BeginInit();
            this.SuspendLayout();
            // 
            // linesCount
            // 
            this.linesCount.AutoSize = true;
            this.linesCount.Location = new System.Drawing.Point(12, 476);
            this.linesCount.Name = "linesCount";
            this.linesCount.Size = new System.Drawing.Size(60, 24);
            this.linesCount.TabIndex = 7;
            this.linesCount.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 503);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 33);
            this.panel1.TabIndex = 6;
            // 
            // searchLine
            // 
            this.searchLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLine.Location = new System.Drawing.Point(12, 9);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(864, 29);
            this.searchLine.TabIndex = 5;
            this.searchLine.TextChanged += new System.EventHandler(this.searchLine_TextChanged);
            this.searchLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrow_KeyDown);
            // 
            // projTable
            // 
            this.projTable.AllowUserToAddRows = false;
            this.projTable.AllowUserToDeleteRows = false;
            this.projTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projTable.Location = new System.Drawing.Point(12, 55);
            this.projTable.Name = "projTable";
            this.projTable.Size = new System.Drawing.Size(864, 418);
            this.projTable.TabIndex = 4;
            this.projTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrow_KeyDown);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 548);
            this.Controls.Add(this.linesCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchLine);
            this.Controls.Add(this.projTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.projTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label linesCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox searchLine;
        private System.Windows.Forms.DataGridView projTable;
    }
}