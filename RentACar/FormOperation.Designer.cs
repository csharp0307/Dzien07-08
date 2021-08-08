
namespace RentACar
{
    partial class FormOperation
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
            this.numMileage = new System.Windows.Forms.NumericUpDown();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.tbDescr = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMileage)).BeginInit();
            this.SuspendLayout();
            // 
            // numMileage
            // 
            this.numMileage.Location = new System.Drawing.Point(27, 33);
            this.numMileage.Name = "numMileage";
            this.numMileage.Size = new System.Drawing.Size(171, 20);
            this.numMileage.TabIndex = 0;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(27, 87);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(171, 20);
            this.dtDate.TabIndex = 1;
            // 
            // tbDescr
            // 
            this.tbDescr.Location = new System.Drawing.Point(27, 137);
            this.tbDescr.Multiline = true;
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.Size = new System.Drawing.Size(231, 260);
            this.tbDescr.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(294, 33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 58);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 58);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.numMileage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOperation";
            this.Text = "FormOperation";
            this.Load += new System.EventHandler(this.FormOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMileage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numMileage;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox tbDescr;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}