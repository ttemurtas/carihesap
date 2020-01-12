using CariHesap.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var isim = textBox1.Text;
            var sifre = textBox2.Text;

            var t = HelperKullanici.SignIn(isim, sifre);

            if (t.Item2)
            {
                Hide();
                MessageBox.Show("Hosgeldiniz");
                Form2 form2 = new Form2(t.Item1);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Böyle bir kullanici bulunamadi!");
            }
        }
    }
}
