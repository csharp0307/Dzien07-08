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
    public partial class FormCarList : Form
    {
        public FormCarList()
        {
            InitializeComponent();
        }

        BindingSource bSource = new BindingSource();

        private void RefreshData()
        {
            // TODO: try catch
            String sql = @"
                SELECT 
                   c.id , b.name AS brand , m.name AS model, ct.name AS car_type,
                   c.registration_plate, c.`engine`, c.manufacturer_year,
                   c.avail, c.fuel   
                FROM 
                  cars AS c , car_types AS ct, car_models AS m, car_brands AS b
                WHERE 
                  c.type_id = ct.id  AND c.model_id=m.id AND m.brand_id=b.id
                ORDER BY c.id  
            ";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt); //dump danych odczytanych z bazy do obiektu DataTable

            bSource.DataSource = dt;
            grid.DataSource = bSource;
        }

        private void FormCarList_Load(object sender, EventArgs e)
        {
            RefreshData();

            // dostosowanie nagłówków grida
            grid.Columns["id"].HeaderText = "ID";
            grid.Columns["brand"].HeaderText = "Marka";
            grid.Columns["model"].HeaderText = "Model";
            grid.Columns["car_type"].HeaderText = "Własność";
            grid.Columns["registration_plate"].HeaderText = "Nr rejestracyjny";
            
            grid.Columns["engine"].HeaderText = "Pojemność [cm3]";
            grid.Columns["engine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grid.Columns["manufacturer_year"].HeaderText = "Rok produkcji";
            grid.Columns["manufacturer_year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grid.Columns["avail"].HeaderText = "Dostępność";
            grid.Columns["fuel"].HeaderText = "Paliwo";
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex ==  grid.Columns["avail"].Index )
            {
                // formatowanie Avail
                e.Value = Convert.ToInt32(e.Value) == 1 ? "TAK" : "NIE";
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}

