using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static List<Panel> Listpan = new List<Panel>();     //celkový list

        private void button1_Click(object sender, EventArgs e)
        {
            Panel row = new Panel()         //jeden řádek
            {
                Size = new Size(700, 45),
                Location = new Point(45, 5)
                
            };
            RichTextBox rtb = new RichTextBox()
            {
                Parent = row,
                Size = new Size(420, 21),
                Location = new Point(10, 5)
                
            };
            CheckBox cb = new CheckBox()
            {
                Parent = row,
                Size = new Size(21, 21),
                Location = new Point(490, 5)
                
            };
            Button but = new Button()
            {
                Parent = row,
                Size = new Size(70, 21),
                Location = new Point(570, 5),
                
                Text = "Smazat"
            };

            but.Click += new System.EventHandler(Smazat_Click);
            Listpan.Add(row);
            Controls.Add(row);      //bez vas bych o controls nevěděl

            foreach (Control item in Controls)
            {
                if (item.GetType().Name == "Panel")
                {
                    item.Location = new Point(45, 50 + Listpan.IndexOf((Panel)item) * 40);
                }
                if (item.GetType().Name == "Button")
                {
                    item.Location = new Point(20, 50 + Listpan.Count * 40);
                }
            }

        }


        private void Smazat_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            Listpan.Remove((Panel)bt.Parent);
            Controls.Remove((Panel)bt.Parent);

            foreach (Control item in Controls)
            {
                if (item.GetType().Name == "Panel")
                {
                    item.Location = new Point(45, 50 + Listpan.IndexOf((Panel)item) * 40);
                }
                if (item.GetType().Name == "Button")
                {
                    item.Location = new Point(21, 50 + Listpan.Count * 40);
                }
            }

        }
    }
}