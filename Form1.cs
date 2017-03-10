using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab1
{
    public partial class Form1 : Form
    {
        ECB ecb;
        public Form1()
        {
            InitializeComponent();
            ecb = new ECB();
        }

        private void lrRB_CheckedChanged(object sender, EventArgs e)
        {
            if(lrRB.Checked)
            {
                dirPB.Image = Properties.Resources.r;
                GB1.Text = "In";
                GB2.Text = "Out";
            }
            else
            {
                dirPB.Image = Properties.Resources.l;
                GB1.Text = "In ";
                GB2.Text = "Out";
            }
        }

        private void genB_Click(object sender, EventArgs e)
        {
            kTB.Text = "";
            Random r = new Random();
            for (int i = 0; i < 8; i++)
            {
                switch(r.Next(1, 4))
                {
                    case 1: kTB.Text += (char)r.Next((int)'0', (int)'9' + 1); break;
                    case 2: kTB.Text += (char)r.Next((int)'a', (int)'z' + 1); break;
                    case 3: kTB.Text += (char)r.Next((int)'A', (int)'Z' + 1); break;
                }
            }
        }

        string SymsToHex(string str)
        {
            string rez = "";

            Byte[] aByte = Encoding.GetEncoding(1251).GetBytes(str);
            for (int i = 0; i < aByte.Length; i++)
                rez += Convert.ToString((int)aByte[i], 16);
            return rez.ToUpper();
        }

        string HexToSyms(string str)
        {
            str = str.ToLower();
            int x = 0;

            Byte[] aByte = new Byte[str.Length/2];
            for (int i = 0; i < str.Length; i += 2)
            {
                x = 0;
                for (int j = 0; j < 2; j++ )
                    if (str[i+j] >= '0' && str[i+j] <= '9') x = x * 16 + str[i+j] - '0';
                    else if (str[i+j] >= 'a' && str[i+j] <= 'f') x = x * 16 + str[i+j] - 'a' + 10;
                aByte[i/2] = (byte)x;
            }
            return Encoding.GetEncoding(1251).GetString(aByte);
        }

        private void encB_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            string ot, sht = "";
            string k = kTB.Text;
            if (formatCB.Checked) k = HexToSyms(k);
            if (lrRB.Checked) ot = TB1.Text;
                else ot = TB2.Text;
            if (ot.Length % 8 != 0)
            {
                if (lrRB.Checked) TB2.Text = "Ошибка! Длина открытого текста меньше 64-х бит\n Нехватает "
                    + Convert.ToSingle(8 - ot.Length % 8) + " символов";
                else TB1.Text = "Ошибка! Длина открытого текста меньше 64-х бит\n Нехватает "
                    + Convert.ToSingle(8 - ot.Length % 8) + " символов";
                return;
            }
            if (ecbRB.Checked) sht = des.Encript(Alg.ECB, ot, k);
            if (cbcRB.Checked) sht = des.Encript(Alg.CBC, ot, k);
            if (lrRB.Checked) TB2.Text = sht;
                else TB1.Text = sht;
        }

        private void decB_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            string ot, sht = "";
            string k = kTB.Text;
            if (formatCB.Checked) k = HexToSyms(k);
            if (lrRB.Checked) ot = TB1.Text;
                else ot = TB2.Text;

            if (sht.Length % 8 != 0)
            {
                if (lrRB.Checked) TB2.Text = "Ошибка! Длина шифр текста меньше 64-х бит\n Нехватает "
                    + Convert.ToSingle(8 - sht.Length % 8) + " символов";
                else TB1.Text = "Ошибка! Длина шифр текста меньше 64-х бит\n Нехватает "
                    + Convert.ToSingle(8 - sht.Length % 8) + " символов";
                return;
            }

            if (ecbRB.Checked) sht = des.Decript(Alg.ECB, ot, k);
            if (cbcRB.Checked) sht = des.Decript(Alg.CBC, ot, k);

            if (lrRB.Checked) TB2.Text = sht;
                else TB1.Text = sht;
        }

        private void formatCB_CheckedChanged(object sender, EventArgs e)
        {
            if(formatCB.Checked)
                kTB.Text = SymsToHex(kTB.Text);
            else kTB.Text = HexToSyms(kTB.Text);
        }
    }
}
