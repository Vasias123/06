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

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            PriceLists price = (PriceLists)priceListsBindingSource.Current;
            frm.db = db;
            frm.price = price;

            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                priceListsBindingSource.DataSource = db.PriceLists.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PriceLists price = (PriceLists)priceListsBindingSource.Current;

            DialogResult dr = MessageBox.Show("ВЫ дествительно хотите удалить роль - " +
                price.ID.ToString(), "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                db.PriceLists.Remove(price);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                priceListsBindingSource.DataSource = db.PriceLists.ToList();
            }
        }
    }
}
