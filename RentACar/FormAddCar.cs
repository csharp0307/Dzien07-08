using MySql.Data.MySqlClient;
using RentACar.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class FormAddCar : Form
    {
        public FormAddCar()
        {
            InitializeComponent();
        }

        BindingSource bsBrands = new BindingSource();
        BindingSource bsModels = new BindingSource();
        BindingSource bsTypes = new BindingSource();

        private void LoadDictionaries()
        {
            // brands
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String sql = "SELECT * FROM car_brands";
            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            bsBrands.DataSource = dt;
            cbBrands.DataSource = bsBrands;
            cbBrands.DisplayMember = "name";
            cbBrands.ValueMember = "id";
            cbBrands.SelectedIndex = -1;
            cbBrands.SelectedIndexChanged += CbBrands_SelectedIndexChanged;

            // models
            adapter = new MySqlDataAdapter();
            sql = "SELECT * FROM car_models";
            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            dt = new DataTable();
            adapter.Fill(dt);
            bsModels.DataSource = dt;
            cbModels.DataSource = bsModels;
            cbModels.DisplayMember = "name";
            cbModels.ValueMember = "id";
            cbModels.SelectedIndex = -1;
            cbModels.Enabled = false;

            // types
            adapter = new MySqlDataAdapter();
            sql = "SELECT * FROM car_types";
            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            dt = new DataTable();
            adapter.Fill(dt);
            bsTypes.DataSource = dt;
            cbTypes.DataSource = bsTypes;
            cbTypes.DisplayMember = "name";
            cbTypes.ValueMember = "id";
            cbTypes.SelectedIndex = -1;

        }

        private void CbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBrands.SelectedIndex>-1)
            {
                bsModels.Filter = $"brand_id={cbBrands.SelectedValue}";
                cbModels.DataSource = bsModels;
                if (bsModels.Count>0)
                {
                    cbModels.Enabled = true;
                    cbModels.SelectedIndex = -1;
                }
            }
        }

        private void FormAddCar_Load(object sender, EventArgs e)
        {
            LoadDictionaries();
            numYear.Value = DateTime.Now.Year;
            numYear.Maximum = DateTime.Now.Year;
        }

        string pictureFileName = null;
        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.jpg;*.bmp;*.png;*.jpeg";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                //wyswietlic obraz w komponencie
                picCar.Image = new Bitmap(dialog.FileName);
                pictureFileName = dialog.FileName;
            }
        }

        private void btnDelPic_Click(object sender, EventArgs e)
        {
            if (picCar.Image!=null)
            {
                picCar.Image.Dispose();
                picCar.Image = null;
                pictureFileName = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = ValidateData();
            if (!result)
            {
                DialogHelper.E("Podaj wszystkie wymagane dane");
                return;
            }

            try
            {
                SaveData();
            }
            catch (Exception exc)
            {
                DialogHelper.E(exc.Message);
            }
            
            
        }

        private void SaveData()
        {
            String sql = @"
            INSERT INTO cars 
            ( model_id, type_id, registration_plate, `engine`, manufacturer_year, image, fuel) 
            VALUES
            ( @model_id, @type_id, @reg_plate, @engine, @year, @image, @fuel)
            ";

            // deklaracja parametrów do zapytania
            MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);
            cmd.Parameters.Add("@model_id", MySqlDbType.Int32);
            cmd.Parameters.Add("@type_id", MySqlDbType.Int32);
            cmd.Parameters.Add("@reg_plate", MySqlDbType.VarChar, 10);
            cmd.Parameters.Add("@engine", MySqlDbType.Int32);
            cmd.Parameters.Add("@year", MySqlDbType.Int32);
            cmd.Parameters.Add("@fuel", MySqlDbType.VarChar, 3);
            cmd.Parameters.Add("@image", MySqlDbType.LongBlob);

            // załadowanie wartości z kontrolek do parametrów zapytania SQL
            cmd.Parameters["@model_id"].Value = cbModels.SelectedValue;
            cmd.Parameters["@type_id"].Value = cbTypes.SelectedValue;
            cmd.Parameters["@reg_plate"].Value = tbRegPlate.Text.ToUpper();
            cmd.Parameters["@year"].Value = numYear.Value;
            cmd.Parameters["@engine"].Value = numEngine.Value;
            cmd.Parameters["@fuel"].Value = cbFuel.SelectedItem; //tylko jesli nie ma DataSource przypisanego
            if (pictureFileName!=null)
            {
                cmd.Parameters["@image"].Value = File.ReadAllBytes(pictureFileName);
            } else
            {
                cmd.Parameters["@image"].Value = null;
            }
            cmd.ExecuteNonQuery();

            // zamykamy okno
            DialogResult = DialogResult.OK;
            Close();


        }

        private bool ValidateData()
        {
            if (cbModels.SelectedIndex>-1 
                && cbTypes.SelectedIndex>-1
                && cbFuel.SelectedIndex>-1
                && !String.IsNullOrWhiteSpace(tbRegPlate.Text) ) 
                return true;


            return false;
        }
    }
}
