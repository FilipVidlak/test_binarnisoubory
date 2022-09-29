using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test_ukol910_binarnisoubory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                FileStream aktualnisoubor = new FileStream(@"..\..\cisla.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter psat = new BinaryWriter(aktualnisoubor);
                for (int i = 0; i < 10; i++)
                {
                    int cislo = random.Next(-10, 11);
                    psat.Write(cislo.ToString());
                }
                aktualnisoubor.Close();
                psat.Close();
               
            }
            catch
            {
                MessageBox.Show("Něco se nepovedlo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream aktualnisoubor2 = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader precist = new BinaryReader(aktualnisoubor2);
            string cisla = string.Empty;
            precist.BaseStream.Position = 0;
            while (precist.BaseStream.Position < precist.BaseStream.Length)
            {
                cisla = precist.ReadString();
                listBox1.Items.Add(precist.ReadString());
            }
            aktualnisoubor2.Close();
            precist.Close();
            FileStream upravenysoubor = new FileStream(@"..\..\cisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter prepis = new BinaryWriter(upravenysoubor);
            char posledniznak = cisla[cisla.Length - 1];
            int lol = 1;
            if (posledniznak % 2 == 1)
            {
                for (int i = 0; i < cisla.Length; i++)
                {

                    if (cisla[i] % 2 == 0)
                    {
                        cisla[i]++;
                    }
                    listBox2.Items.Add(cisla);
                }
            }
            else
            {
                for (int i = 0; i < cisla.Length; i++)
                {
                    if (cisla[i] % 2 == 1)
                    {
                        cisla[i] *= 2; //nelze ve stringu prirazovat konkretni hodnoty a u toho jsem koncil, nemel jsem cas to prepisovat..
                    }
                    listBox2.Items.Add(cisla);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
