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
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Нужно ввести все данные");
                return;
            }

            int id = 0;



            bool b = int.TryParse(textBox1.Text, out id);


            if (b == false)
            {

                MessageBox.Show("Неверный формат ID" + textBox1);
                return;
            }

            string name = textBox2.Text.Trim();
            string color = textBox3.Text.Trim();


            PriceLists priceLists = new PriceLists();

            priceLists.ID = id;
            priceLists.Name = textBox2.Text;
            priceLists.Color = textBox3.Text;
            priceLists.Price = textBox4.Text;

            db.PriceLists.Add(priceLists);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.Message);

            }
        }
    }
}
