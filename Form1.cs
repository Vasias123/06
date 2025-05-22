using _06.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06
{
    public partial class Form1 : Form
    {

        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            priceListsBindingSource.DataSource = db.PriceLists.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.db = db;

            DialogResult dr = form2.ShowDialog();

            if (dr == DialogResult.OK)
            {
                priceListsBindingSource.DataSource = db.PriceLists.ToList();
            }
        }
    }
}
