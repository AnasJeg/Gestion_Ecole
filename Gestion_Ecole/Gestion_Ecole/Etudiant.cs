using Gestion_Ecole.services;
using Guna.UI2.WinForms;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_Ecole
{
    public partial class Etudiant : UserControl
    {
        EtudService st=new EtudService();
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        private int id = 0;
        private byte[] img;

        public Etudiant()
        {
            InitializeComponent();
            textBox1.Hide();
            ViewData();
        }

        public void refresh()
        {

        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string gr = combGenre.GetItemText(0);
            string vl = combVille.GetItemText(0);
            DateTime dateNais = dateN.Value.Date;
            
            if (Tn.Text == "" || Tp.Text == "" || Tc.Text == "" || Te.Text == "" || Ta.Text == "" || Tt.Text == "")
            {
                DialogResult dialog = MessageBox.Show("veuillez remplir tous les champs", "champs !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult dialogClose = MessageBox.Show("Ajouter ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                EtudiantC et = new EtudiantC(Tn.Text, Tp.Text, Tc.Text, Tt.Text, Te.Text, Ta.Text, dateNais, gr, vl, textBox1.Text);
                //  st.ajouter(et);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void picEtud_Click(object sender, EventArgs e)
        {


        }

        private void upload_Click(object sender, EventArgs e)
        {
           /*
            Image image;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files |.|JPG|.jpg|PNG|.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picEtud.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    image = System.Drawing.Image.FromFile(ofd.FileName); ;
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] i = ms.ToArray();
                    img = i;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
            */
            OpenFileDialog opf=new OpenFileDialog();
            opf.Filter = "etudiant_pic(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                picEtud.Image = Image.FromFile(opf.FileName);
              //  picEtud.ImageLocation = opf.FileName;
                textBox1.Text = opf.FileName.ToString();
            }
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            id = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
          */
        }
      
        public void ViewData()
        {
            
            MySqlDataAdapter req = new MySqlDataAdapter("SELECT id, nom,prenom,cin,tell,email,adresse,date_N,genre,ville,image FROM etudiant order by id asc", con);
            DataTable dt = new DataTable();
            req.Fill(dt);
            dt.Columns.Add("Img", Type.GetType("System.Byte[]"));
            foreach(DataRow dr in dt.Rows)
            {
                dr["Img"] = File.ReadAllBytes(dr["image"].ToString());
                    dataGridView1.DataSource = dt;
            }
            
            con.Close();

            
        }
        
    }

}