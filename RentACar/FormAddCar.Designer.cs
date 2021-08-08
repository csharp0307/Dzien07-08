
namespace RentACar
{
    partial class FormAddCar
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
            this.cbBrands = new System.Windows.Forms.ComboBox();
            this.cbModels = new System.Windows.Forms.ComboBox();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.tbRegPlate = new System.Windows.Forms.MaskedTextBox();
            this.cbFuel = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picCar = new System.Windows.Forms.PictureBox();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.btnDelPic = new System.Windows.Forms.Button();
            this.numEngine = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEngine)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBrands
            // 
            this.cbBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrands.FormattingEnabled = true;
            this.cbBrands.Location = new System.Drawing.Point(51, 43);
            this.cbBrands.Name = "cbBrands";
            this.cbBrands.Size = new System.Drawing.Size(182, 21);
            this.cbBrands.TabIndex = 0;
            // 
            // cbModels
            // 
            this.cbModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModels.FormattingEnabled = true;
            this.cbModels.Location = new System.Drawing.Point(51, 90);
            this.cbModels.Name = "cbModels";
            this.cbModels.Size = new System.Drawing.Size(182, 21);
            this.cbModels.TabIndex = 1;
            // 
            // cbTypes
            // 
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(51, 135);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(182, 21);
            this.cbTypes.TabIndex = 2;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(51, 182);
            this.numYear.Maximum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(182, 20);
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // tbRegPlate
            // 
            this.tbRegPlate.AsciiOnly = true;
            this.tbRegPlate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.tbRegPlate.Location = new System.Drawing.Point(51, 286);
            this.tbRegPlate.Mask = "AAAaaaaa";
            this.tbRegPlate.Name = "tbRegPlate";
            this.tbRegPlate.Size = new System.Drawing.Size(182, 20);
            this.tbRegPlate.TabIndex = 5;
            // 
            // cbFuel
            // 
            this.cbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            "PB",
            "ON",
            "LPG"});
            this.cbFuel.Location = new System.Drawing.Point(51, 342);
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(182, 21);
            this.cbFuel.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 54);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Zapisz";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(501, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 54);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // picCar
            // 
            this.picCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCar.Location = new System.Drawing.Point(262, 43);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(320, 320);
            this.picCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCar.TabIndex = 8;
            this.picCar.TabStop = false;
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(604, 41);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(131, 23);
            this.btnLoadPic.TabIndex = 7;
            this.btnLoadPic.Text = "Wczytaj obraz";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // btnDelPic
            // 
            this.btnDelPic.Location = new System.Drawing.Point(604, 116);
            this.btnDelPic.Name = "btnDelPic";
            this.btnDelPic.Size = new System.Drawing.Size(131, 23);
            this.btnDelPic.TabIndex = 8;
            this.btnDelPic.Text = "Usuń obraz";
            this.btnDelPic.UseVisualStyleBackColor = true;
            this.btnDelPic.Click += new System.EventHandler(this.btnDelPic_Click);
            // 
            // numEngine
            // 
            this.numEngine.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numEngine.Location = new System.Drawing.Point(51, 232);
            this.numEngine.Maximum = new decimal(new int[] {
            6500,
            0,
            0,
            0});
            this.numEngine.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numEngine.Name = "numEngine";
            this.numEngine.Size = new System.Drawing.Size(182, 20);
            this.numEngine.TabIndex = 4;
            this.numEngine.Value = new decimal(new int[] {
            1598,
            0,
            0,
            0});
            // 
            // FormAddCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(747, 477);
            this.Controls.Add(this.numEngine);
            this.Controls.Add(this.btnDelPic);
            this.Controls.Add(this.btnLoadPic);
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbFuel);
            this.Controls.Add(this.tbRegPlate);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.cbModels);
            this.Controls.Add(this.cbBrands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj nowy samochód";
            this.Load += new System.EventHandler(this.FormAddCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEngine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBrands;
        private System.Windows.Forms.ComboBox cbModels;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.MaskedTextBox tbRegPlate;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.Button btnDelPic;
        private System.Windows.Forms.NumericUpDown numEngine;
    }
}