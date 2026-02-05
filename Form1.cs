using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace buscador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = @"historial.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)

            {
                comboBox1.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private void Guardar(string archivo, string texto)
        {
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text;
            comboBox1.Items.Clear();
            if (url.StartsWith("http://") || url.StartsWith("https://"))
                {           
                }
            else
            {
                if (url.Contains("."))
                {
                    url = "http://" + url;
                }
                else
                {
                    url = "https://www.google.com/search?q=" + Uri.EscapeDataString(url);
                }
            }

                webView.CoreWebView2.Navigate(url);
            Guardar(@"historial.txt", comboBox1.Text);

            string fileName = @"historial.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)

            {
                comboBox1.Items.Add(reader.ReadLine());
            }
            reader.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoForward();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("http://www.google.com");
        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }
}
