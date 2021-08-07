﻿using MySql.Data.MySqlClient;
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

        private DataTable GetDataFromDb()
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
            return dt;
        }

        private void RefreshData()
        {            
            //bSource.DataSource = dt;
            //grid.DataSource = bSource;
        }

        private void FormCarList_Load(object sender, EventArgs e)
        {
            DataTable dt = GetDataFromDb();
            bSource.DataSource = dt;

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn(); //kolumna z checkbox'em
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "avail-cb";
            dgvCmb.HeaderText = "Dostępny";
            grid.Columns.Add(dgvCmb);

            grid.DataSource = bSource;

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

            grid.Columns["avail-cb"].DisplayIndex = grid.Columns.Count - 1;

            
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex ==  grid.Columns["avail"].Index )
            {
                // formatowanie Avail
                e.Value = Convert.ToInt32(e.Value) == 1 ? "TAK" : "NIE";
            }

            // wypełnianie checkbox'a w zaleznosci o wartosci kolumny 'avail'
            grid.Rows[e.RowIndex].Cells["avail-cb"].Value = 
            Convert.ToInt32(grid.Rows[e.RowIndex].Cells["avail"].Value) == 1 ? true : false;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            FormAddCar form = new FormAddCar();
            form.ShowDialog();
        }
    }
}

