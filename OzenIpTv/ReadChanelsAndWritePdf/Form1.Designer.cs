namespace ReadChanelsAndWritePdf
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_writeToExcel = new System.Windows.Forms.Button();
            this.btn_saveExcelFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(402, 368);
            this.listBox1.TabIndex = 0;
            // 
            // btn_writeToExcel
            // 
            this.btn_writeToExcel.Location = new System.Drawing.Point(422, 13);
            this.btn_writeToExcel.Name = "btn_writeToExcel";
            this.btn_writeToExcel.Size = new System.Drawing.Size(366, 23);
            this.btn_writeToExcel.TabIndex = 1;
            this.btn_writeToExcel.Text = "Kanal Listesini Excel\'e Yaz";
            this.btn_writeToExcel.UseVisualStyleBackColor = true;
            // 
            // btn_saveExcelFile
            // 
            this.btn_saveExcelFile.Location = new System.Drawing.Point(422, 42);
            this.btn_saveExcelFile.Name = "btn_saveExcelFile";
            this.btn_saveExcelFile.Size = new System.Drawing.Size(366, 23);
            this.btn_saveExcelFile.TabIndex = 2;
            this.btn_saveExcelFile.Text = "Excel Dosyasını Kaydet";
            this.btn_saveExcelFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_saveExcelFile);
            this.Controls.Add(this.btn_writeToExcel);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_writeToExcel;
        private System.Windows.Forms.Button btn_saveExcelFile;
    }
}

