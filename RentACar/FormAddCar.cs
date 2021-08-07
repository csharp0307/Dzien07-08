using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.jpg;*.bmp;*.png;*.jpeg";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                //wyswietlic obraz w komponencie
                picCar.Image = new Bitmap(dialog.FileName);
            }
        }

        private void btnDelPic_Click(object sender, EventArgs e)
        {
            if (picCar.Image!=null)
            {
                picCar.Image.Dispose();
                picCar.Image = null;
            }
        }
    }
}
