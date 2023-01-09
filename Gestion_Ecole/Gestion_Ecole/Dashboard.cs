using Gestion_Ecole.userControle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Ecole
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void AdduserControle(UserControl usc)
        {
                usc.Dock= DockStyle.Fill;
            deskpane.Controls.Clear();
            deskpane.Controls.Add(usc);
            deskpane.BringToFront();

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(x, y);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            AdduserControle(st);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
