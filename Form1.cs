using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BigInteger;
//

using Int = System.Int64;
using RSAtype = RSA_T.S_RSAmaker;
namespace RSA_T
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RSAtype rsa;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string tmp = this.richTextBox1.Text;
            List<Int> ee = rsa.Encrypt(ref tmp);
            this.richTextBox3.Text = rsa.getEncrypt(ref ee);
            this.richTextBox2.Text = rsa.Decrypt(ref ee);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.rsa = new RSAtype(new Random());
            string tmp = this.richTextBox1.Text;
            List<Int> ee = rsa.Encrypt(ref tmp);
            this.richTextBox3.Text = rsa.getEncrypt(ref ee);
            this.richTextBox2.Text = rsa.Decrypt(ref ee);
            this.richTextBox4.Text = "P: " + rsa.P.ToString() + "\nQ: "
            + rsa.Q.ToString() ;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int delta = (this.Height - 520) / 3;
            this.richTextBox1.Height = 120 + delta;
            this.richTextBox2.Height = 120 + delta;
            this.richTextBox3.Height = 155 + delta;
            this.richTextBox4.Height = 120 + delta;
            this.button1.Location = new Point(this.button1.Location.X, 302 + 2 * delta);
            this.label2.Location = new Point(15, 155 + delta);
            this.label3.Location = new Point(this.richTextBox4.Location.X + 1, 155 + delta);
            this.label4.Location = new Point(15, 330 + 2 * delta);
            this.richTextBox3.Location = new Point(12, 172 + delta);
            this.richTextBox4.Location = new Point(this.richTextBox4.Location.X, 172 + delta);
            this.richTextBox2.Location = new Point(12, 354 + 2 * delta);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Height = 600;
            this.Width = 900;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string tmp = this.richTextBox1.Text;
            this.rsa = new RSAtype(new Random());
            List<Int> ee = rsa.Encrypt(ref tmp);
            this.richTextBox3.Text = rsa.getEncrypt(ref ee);
            this.richTextBox2.Text = rsa.Decrypt(ref ee);
            this.richTextBox4.Text = "P: " + rsa.P.ToString() + "\nQ: "
            + rsa.Q.ToString() ;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
