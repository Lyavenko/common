using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Cars
{
    public partial class Form1 : Form
    {
        XmlDocument carsDocument = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carsDocument.Load("../../cars.xml");
            /*foreach (XmlNode brand in carsDocument["cars"])
            {
                string name = brand["name"].InnerText;
                brandCombo.Items.Add(name);
            }*/
            var brandNodes = carsDocument.SelectNodes(
                "/cars/brand/name");
            foreach (XmlNode nameNode in brandNodes)
            {
                brandCombo.Items.Add(nameNode.InnerText);
            }
        }

        private void brandCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string xpath =
                "/cars/brand[name='" + (string) brandCombo.SelectedItem + "']/models/model/name";
            this.Text = xpath;
            var modelNodes = carsDocument.SelectNodes(xpath);
            modelCombo.Items.Clear();
            foreach (XmlNode nameNode in modelNodes)
            {
                modelCombo.Items.Add(nameNode.InnerText);
            }
        }
    }
}
