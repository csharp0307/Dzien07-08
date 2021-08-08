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

        int LastRecordId; 
        private void FormOperation_Load(object sender, EventArgs e)
        {
            if (OperBack)
            {
                Text = "Zdaj auto -" + RegPlate;
                DataTable dt = GlobalData.ExecSQL($"select id from operations where car_id={CarId} order by id desc limit 0,1 ");
                if (dt.Rows.Count>0)
                {
                    LastRecordId = Convert.ToInt32(dt.Rows[0]["id"]);
                }

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
                sql = @"update operations set
                        ts_in=@ts, mileage_in=@mileage, description=concat(description,';',@descr)
                        where id=@id
                    ";
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
            cmd.Parameters.AddWithValue("@id", LastRecordId);
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
