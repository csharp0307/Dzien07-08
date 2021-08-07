using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindingExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Person> people = new List<Person>();
        private void Form1_Load(object sender, EventArgs e)
        {
            people.Add(new Person() { FName="Jan", LName="Kowalski", Age=44, Job="Spawacz", Active=false  } );
            people.Add(new Person() { FName="Marek", LName="Nowak", Age=30, Job="Tiktoker", Active = true} );
            people.Add(new Person() { FName="Emil", LName="Zatopek", Age=66, Job="Biegacz", Active = false } );
            people.Add(new Person() { FName="Zenek", LName="Martyniuk", Age=52, Job="Śpiewak", Active = true } );

            lbPeople.Items.Clear();
            //foreach (var person in people)
            //{
            //    lbPeople.Items.Add($"{person.FName} {person.LName}");
            //}

            // DataBinding
            lbPeople.DataSource = people;
            lbPeople.DisplayMember = "FullName";

            // przypisanie danych do kontrolek TextBox na podstawie bieżacego indeksu danych w ListBox
            tbFName.DataBindings.Add(new Binding("Text", lbPeople.DataSource, "FName"));

            
            tbLName.DataBindings.Add(new Binding("Text", lbPeople.DataSource, "LName"));
            
            tbAge.DataBindings.Add(new Binding("Text", lbPeople.DataSource, "Age"));
            
            tbJob.DataBindings.Add(new Binding("Text", lbPeople.DataSource, "Job"));
            tbJob.DataBindings.Add(new Binding("Enabled", lbPeople.DataSource, "Active"));


        }

        private void lbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = lbPeople.SelectedIndex;
            //if (index>-1)
            //{
            //    Person person = people[index];
            //    tbFName.Text = person.FName;
            //    tbLName.Text = person.LName;
            //    tbAge.Text = person.Age.ToString();
            //    tbJob.Text = person.Job;
            //}
        }
    }
}
