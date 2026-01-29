using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Web.WebView2.Core;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buscador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text;
            

            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                if (!url.Contains("."))
                {
                    url = "https://www.google.com/search?q=" + Uri.EscapeDataString(url);
                }
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
    }
}
