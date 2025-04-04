
namespace WindowsFormsApp1
{
    partial class Menu
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
            this.projbtn = new System.Windows.Forms.Button();
            this.clientbtn = new System.Windows.Forms.Button();
            this.leavebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projbtn
            // 
            this.projbtn.Location = new System.Drawing.Point(57, 31);
            this.projbtn.Name = "projbtn";
            this.projbtn.Size = new System.Drawing.Size(241, 43);
            this.projbtn.TabIndex = 0;
            this.projbtn.Text = "Проекты";
            this.projbtn.UseVisualStyleBackColor = true;
            this.projbtn.Click += new System.EventHandler(this.projbtn_Click);
            // 
            // clientbtn
            // 
            this.clientbtn.Location = new System.Drawing.Point(57, 92);
            this.clientbtn.Name = "clientbtn";
            this.clientbtn.Size = new System.Drawing.Size(241, 46);
            this.clientbtn.TabIndex = 1;
            this.clientbtn.Text = "Клиенты";
            this.clientbtn.UseVisualStyleBackColor = true;
            this.clientbtn.Click += new System.EventHandler(this.clientbtn_Click);
            // 
            // leavebtn
            // 
            this.leavebtn.Location = new System.Drawing.Point(57, 220);
            this.leavebtn.Name = "leavebtn";
            this.leavebtn.Size = new System.Drawing.Size(258, 50);
            this.leavebtn.TabIndex = 2;
            this.leavebtn.Text = "Покинуть личный кабинет";
            this.leavebtn.UseVisualStyleBackColor = true;
            this.leavebtn.Click += new System.EventHandler(this.leavebtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 307);
            this.Controls.Add(this.leavebtn);
            this.Controls.Add(this.clientbtn);
            this.Controls.Add(this.projbtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button projbtn;
        private System.Windows.Forms.Button clientbtn;
        private System.Windows.Forms.Button leavebtn;
    }
}