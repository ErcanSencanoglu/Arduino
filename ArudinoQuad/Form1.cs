using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ArudinoQuad
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        string[] ports = SerialPort.GetPortNames();
        SerialPort serialPort1 = new SerialPort();

        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
        }
        int n = 0, m1 = 0, m2 = 0, m3 = 0, m4 = 0;
        bool a1 = false, a2 = false, a3 = false, a4 = false;
        string degerler = "";

        void m1DegerDegistir()
        {
            m1Gonder();
            m1GoruntuDegistir();
        }
        void m2DegerDegistir()
        {
            m2Gonder();
            m2GoruntuDegistir();
        }
        void m3DegerDegistir()
        {
            m3Gonder();
            m3GoruntuDegistir();
        }
        void m4DegerDegistir()
        {
            m4Gonder();
            m4GoruntuDegistir();
        }
        void m1GoruntuDegistir()
        {
            lblMtr1.Text = m1.ToString();
            lblM1G.Text = n.ToString();
            lblM1M.Text = m1.ToString();
            nmrM1.Value = m1;

            if (m1 <= trckM1.Maximum) { trckM1.Value = m1; }
           // prgM1.Value = m1 * 100 / trckM1.Maximum;
        }
        void m2GoruntuDegistir()
        {
            lblMtr2.Text = m2.ToString();
            lblM2G.Text = n.ToString();
            lblM2M.Text = m2.ToString();
            nmrM2.Value = m2;

            if (m2 <= trckM2.Maximum) { trckM2.Value = m2; }
            //prgM2.Value = m2 * 100 / trckM2.Maximum;
        }
        void m3GoruntuDegistir()
        {
            lblMtr3.Text = m3.ToString();
            lblM3G.Text = n.ToString(); ;
            lblM3M.Text = m3.ToString();
            nmrM3.Value = m3;

            if (m3 <= trckM3.Maximum) { trckM3.Value = m3; }
           // prgM3.Value = m3 * 100 / trckM3.Maximum;
        }
        void m4GoruntuDegistir()
        {
            lblMtr4.Text = m4.ToString();
            lblM4G.Text = n.ToString();
            lblM4M.Text = m4.ToString();
            nmrM4.Value = m4;

            if (m4 <= trckM4.Maximum) { trckM4.Value = m4; }
           // prgM4.Value = m4 * 100 / trckM4.Maximum;
        }
        void m1Gonder()
        {
            serialPort1.Open();
            degerler = "/"+m1;
            serialPort1.Write(degerler);
            serialPort1.Close();
        }
        void m2Gonder()
        {
            serialPort1.Open();
            degerler = "*" + m2;
            serialPort1.Write(degerler);
            serialPort1.Close();
        }
        void m3Gonder()
        {
            serialPort1.Open();
            degerler = "-" + m3;
            serialPort1.Write(degerler);
            serialPort1.Close();
        }
        void m4Gonder()
        {
            serialPort1.Open();
            degerler = "+" + m4;
            serialPort1.Write(degerler);
            serialPort1.Close();
        }

        void allGonder()
        {
            m1Gonder();
            m2Gonder();
            m3Gonder();
            m4Gonder();
        }
        void allDegerDegistir()
        {
            m1 = n+8;
            m2 = n + 18;
            m3 = n + 2;
            m4 = n;
            allGonder();
            allGoruntuDegistir();
        }
        void allGoruntuDegistir()
        {
            lblDeger.Text = n.ToString();
            nmrAll.Value = n;
            if (n <= trckAll.Maximum) { trckAll.Value = n; }

            m1GoruntuDegistir();
            m2GoruntuDegistir();
            m3GoruntuDegistir();
            m4GoruntuDegistir();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            lblM1C.Text = "150";
            lblM2C.Text = "150";
            lblM3C.Text = "150";
            lblM4C.Text = "150";
        }

        private void btnAllArttır_Click(object sender, EventArgs e)
        {
            n++;
            allDegerDegistir();
            
        }

        private void btnAllAzalt_Click(object sender, EventArgs e)
        {
            if (!(n <= 0)) { n--; }
            allDegerDegistir();
        }

        private void trckAll_Scroll(object sender, EventArgs e)
        {
            n = trckAll.Value;
            allDegerDegistir();
        }

        private void nmrAll_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(nmrAll.Value);
            allDegerDegistir();
        }

        //
        //Tek tek değiştirme
        private void btnM1Ar_Click(object sender, EventArgs e)
        {
            m1++;
            a1 = false;
            m1DegerDegistir();
        }

        private void btnM1Az_Click(object sender, EventArgs e)
        {
            if (!(m1 <= 0))
            {
                m1--;
                a1 = false;
                m1DegerDegistir();
            }
        }

        private void nmrM1_ValueChanged(object sender, EventArgs e)
        {
            if (a1 == true)
            {
                m1 = Convert.ToInt32(nmrM1.Value);
                m1DegerDegistir();
            }
            a1 = true;
        }
      
        private void trckM1_Scroll(object sender, EventArgs e)
        {
            m1 = trckM1.Value;
            m1DegerDegistir();
        }


        private void btnM2Ar_Click(object sender, EventArgs e)
        {
            m2++;
            a2 = false;
            m2DegerDegistir();
        }

        private void btnM2Az_Click(object sender, EventArgs e)
        {
            if (!(m2 <= 0))
            {
                m2--;
                a2 = false;
                m2DegerDegistir();
            }
        }

        private void nmrM2_ValueChanged(object sender, EventArgs e)
        {
            if (a2 == true)
            {
                m2 = Convert.ToInt32(nmrM2.Value);
                m2DegerDegistir();
            }
            a2 = true;
        }   

        private void trckM2_Scroll(object sender, EventArgs e)
        {
            m2 = trckM2.Value;
            m2DegerDegistir();
        }

        private void btnM3Ar_Click(object sender, EventArgs e)
        {
            m3++;
            a3 = false;
            m3DegerDegistir();
        }

        private void btnM3Az_Click(object sender, EventArgs e)
        {
            if (!(m3 <= 0))
            {
                m3--;
                a3 = false;
                m3DegerDegistir();
            }
        }

        private void nmrM3_ValueChanged(object sender, EventArgs e)
        {
            if (a3 == true)
            {
               m3 = Convert.ToInt32(nmrM3.Value);
               m3DegerDegistir();
            }
            a3 = true;
        }

        private void trckM3_Scroll(object sender, EventArgs e)
        {
            m3 = trckM3.Value;
            m3DegerDegistir();
        }

        private void btnM4Ar_Click(object sender, EventArgs e)
        {
            m4++;
            a4 = false;
            m4DegerDegistir();
        }

        private void btnM4Az_Click(object sender, EventArgs e)
        {
            if (!(m4 <= 0))
            {
                m4--; 
                a4 = false;
                m4DegerDegistir();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void nmrM4_ValueChanged(object sender, EventArgs e)
        {
            if(a4 == true)
            {
                m4 = Convert.ToInt32(nmrM4.Value);
                m4DegerDegistir();
            }
            a4 = true;
           
        }

        private void trckM4_Scroll(object sender, EventArgs e)
        {
            m4 = trckM4.Value;
            m4DegerDegistir();
        }

        //
        //

        private void btnSecArttır_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                m1 += Convert.ToInt32(nmrSec.Value);
                m1DegerDegistir();
            }
            if (checkBox2.Checked == true)
            {
                m2 += Convert.ToInt32(nmrSec.Value);
                m2DegerDegistir();
            }
            if (checkBox3.Checked == true)
            {
                m3 += Convert.ToInt32(nmrSec.Value);
                m3DegerDegistir();
            }
            if (checkBox4.Checked == true)
            {
                m4 += Convert.ToInt32(nmrSec.Value);
                m4DegerDegistir();
            }
        }

        private void btnSecAzalt_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                m1 -= Convert.ToInt32(nmrSec.Value);
                m1DegerDegistir();
            }
            if (checkBox2.Checked == true)
            {
                m2 -= Convert.ToInt32(nmrSec.Value);
                m2DegerDegistir();
            }
            if (checkBox3.Checked == true)
            {
                m3 -= Convert.ToInt32(nmrSec.Value);
                m3DegerDegistir();
            }
            if (checkBox4.Checked == true)
            {
                m4 -= Convert.ToInt32(nmrSec.Value);
                m4DegerDegistir();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            n = 0;
            m1 = 0;
            m2 = 0;
            m3 = 0;
            m4 = 0;
            m1DegerDegistir();
            m2DegerDegistir();
            m3DegerDegistir();
            m4DegerDegistir();
        }

        private void btnEsitle_Click(object sender, EventArgs e)
        {
            allDegerDegistir();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) { serialPort1.Close(); }
        }
        


    }
}
