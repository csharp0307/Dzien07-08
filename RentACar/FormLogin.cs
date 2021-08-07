using MySql.Data.MySqlClient;
using RentACar.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.AppSettings["cs"];
            try
            {
                if (
                    String.IsNullOrWhiteSpace(tbLogin.Text) ||
                    String.IsNullOrWhiteSpace(tbPassword.Text) 
                    )
                {
                    DialogHelper.E("Podaj dane do logowania");
                    return;
                }

                cs = String.Format(cs, tbLogin.Text.Trim(), tbPassword.Text.Trim());
                new MySqlConnection(cs);
            }
            catch (Exception exc)
            {

            }
        }
    }
}
