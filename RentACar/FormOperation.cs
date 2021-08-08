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
    public partial class FormOperation : Form
    {
        public bool OperBack { get; set; }
        public string RegPlate { get; set; }
        public int CarId { get; set; }

        public FormOperation()
        {
            InitializeComponent();
        }

        private void FormOperation_Load(object sender, EventArgs e)
        {
            if (OperBack)
            {
                Text = "Zdaj auto -" + RegPlate;
            } else
            {
                Text = "Wydaj auto -" + RegPlate;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            String sql;
            if (OperBack)
            {
                // aktualizacja rekordu w operacjach
                sql = "";
            } else
            {
                // dodanie rekordu
                sql = @"
                    insert into operations
                    (car_id, ts_out, mileage_out, description)
                    values
                    (@car_id, @ts, @mileage, @descr)
                ";
            }
            MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);
            cmd.Parameters.AddWithValue("@car_id", CarId);
            cmd.Parameters.AddWithValue("@ts", dtDate.Value);
            cmd.Parameters.AddWithValue("@mileage", numMileage.Value);
            cmd.Parameters.AddWithValue("@descr", tbDescr.Text);
            cmd.ExecuteNonQuery();

            sql = "update cars set avail=@avail where id=@car_id";
            cmd = new MySqlCommand(sql, GlobalData.connection);
            cmd.Parameters.AddWithValue("@car_id", CarId);
            cmd.Parameters.AddWithValue("@avail", OperBack ? 1:0);
            cmd.ExecuteNonQuery();

            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
