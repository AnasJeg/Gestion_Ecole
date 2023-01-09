using Gestion_Ecole.classes;
using Gestion_Ecole.services;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Gestion_Ecole.userControle
{
    public partial class Student : UserControl
    {
        EtudService st = new EtudService();
        FilierService filierServ= new FilierService();
        MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        byte[] img;
        DataTable dataTable;
        static int id;
        String nomfiliere;
        String fil;
        public Student()
        {
            InitializeComponent();
         
        }

        private void Student_Load(object sender, EventArgs e)
        {
            remplirFilieresModule();
            remplirVille();
            remplirGroupe();
            remplirNiveau();
            remplirlisteEtudiant(null);


        }

        public String SexeCheck()
        {
            String s="default";
            if (men.Checked)
                s="homme";
           else if (women.Checked)
                s="femme";
            
            return s;
        }

        public void remplirFilieresModule()
        {
            comFilier.Items.Clear();
            combFS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nom from filiere", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comFilier.Items.Add(reader[0]);
                combFS.Items.Add(reader[0]);

            }
            
            con.Close();


        }

        public void remplirGroupe()
        {
                combGS.Items.Clear();
                if (con.State != ConnectionState.Open) { con.Open(); }
            String nn = "iir4";
              MySqlCommand cmd = new MySqlCommand(" SELECT g.num from groupe g,filiere f where g.id_filiere=f.id AND f.nom='"+ nn +"'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("combFS >>>>>  " + combFS.ToString());
                while (reader.Read())
                {
                    combGS.Items.Add(reader[0]);
                }
               
                con.Close();

        }
        public void remplirNiveau()
        {
            combNS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            //  SELECT num from groupe WHERE id_filiere=(SELECT id from filiere where nom="iir4");
            //  MySqlCommand cmd = new MySqlCommand("select num from groupe where id_filiere='" + fil + "'", con);
            MySqlCommand cmd = new MySqlCommand(" SELECT num from niveau", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                combNS.Items.Add(reader[0]);
            }

            con.Close();

        }

        public void remplirVille()
        {
            combVille.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select ville from ville", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                combVille.Items.Add(reader[0]);

            }
            con.Close();
        }

        public void remplirlisteEtudiant(String a)
        {
            String fili = "nomfiliere";
            String query;
            if (con.State != ConnectionState.Open) { con.Open(); }
            if (String.IsNullOrEmpty(a))
                query = "Select e.nom,e.prenom,e.cin,e.cne,e.email,e.age,e.sexe,e.date_naissance,e.ville,e.telephone,e.adresse,e.image,f.nom'" + fili + "',e.niveau,e.groupe from etudiants e,filiere f where e.id_filiere = f.id";
           
            else
                query = "select  Nom,prenom,cin,cne,email,telephone,adresse,age,niveau,groupe,image  from etudiants where Nom='" + a + "'";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoEtud.DataSource = dataTable;
           con.Close();


        }

        private void upload_Click(object sender, EventArgs e)
        {
            Image image;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                // ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                ofd.Filter = "All Files(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picEtud.Image = Image.FromFile(ofd.FileName);
                    image = Image.FromFile(ofd.FileName); ;
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
        }

        private void add_Click(object sender, EventArgs e)
        {


            String email = Temail.Text.ToString();
            if (email == "" || !(email.Contains("@")))
            {
                Temail.BorderColor= Color.Red;
                return;
            }

            String nom = Tn.Text.ToString();
            String prenom = Tp.Text.ToString();
            int age = int.Parse(NumAge.Value.ToString());

            string pattern = "^[0-9]{10}$";
            Regex reg = new Regex(pattern);

            String tell = Ttell.Text.ToString();
            if (tell == "" || !reg.IsMatch(tell))
            {
              Ttell.BorderColor= Color.Red;
                return;

            }
            String address = Tadresse.Text.ToString();
            String sexe = SexeCheck();
            String cne = Tcne.Text.ToString();
            String cin = Tcin.Text.ToString();
            String dateNais = dateN.ToString();
            String villeO = combVille.SelectedItem.ToString();
            byte[] image = img;
            int nv = int.Parse(NumAnne.Value.ToString());

            String  nameF = comFilier.SelectedItem.ToString();

            int id_filiere = filierServ.getFilierbyNom(nameF);
            int num_gr=  int.Parse( NumGroupe.Value.ToString());

            DialogResult dialogClose = MessageBox.Show("Ajouter ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                StudentC stud = new StudentC(nom,prenom,cin,cne,email,age,sexe,dateNais,villeO,tell,address,image,id_filiere,nv,num_gr);
                st.ajouter(stud);
            }
        }

        private void InfoEtud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else
            {

                DataGridViewRow selectedRow = InfoEtud.Rows[index];
                cneD.Text = selectedRow.Cells["cne"].Value.ToString();
                cinD.Text = selectedRow.Cells["cin"].Value.ToString();
                tellD.Text = selectedRow.Cells["telephone"].Value.ToString();
                villeD.Text = selectedRow.Cells["ville"].Value.ToString();
                {
                    Tn.Text = selectedRow.Cells["nom"].Value.ToString();
                    Tp.Text = selectedRow.Cells["prenom"].Value.ToString();
                    Tcne.Text = selectedRow.Cells["cne"].Value.ToString();
                    Tcin.Text = selectedRow.Cells["cin"].Value.ToString();
                    String sexe = selectedRow.Cells["sexe"].Value.ToString();
                    if (sexe.Equals("men"))
                        men.Checked = true;
                    else
                        women.Checked = true;

                    Temail.Text = selectedRow.Cells["email"].Value.ToString();
                    Tadresse.Text = selectedRow.Cells["adresse"].Value.ToString();
                    NumAge.Value = Decimal.Parse(selectedRow.Cells["age"].Value.ToString());
                    NumAnne.Value = Decimal.Parse(selectedRow.Cells["niveau"].Value.ToString());
                    Ttell.Text = selectedRow.Cells["telephone"].Value.ToString();

                    update.Enabled = true;
                    
                    comFilier.Text = selectedRow.Cells["id_filiere"].Value.ToString();
                    combVille.Text = selectedRow.Cells["ville"].Value.ToString();
                    id = st.getIdEtudiantByCIN(cinD.Text.ToString());

                    byte[] c = null;
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    String query = "select image from etudiants where cin='" + cinD.Text.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    byte[] imgg = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(imgg);
                    picEtud.Image = System.Drawing.Image.FromStream(ms);
                    picEtud2.Image = System.Drawing.Image.FromStream(ms);

                    con.Close();
                }
            }
            }

            private void combFilier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            String NomStudent;
            if (combFS.SelectedIndex < 0 || combGS.SelectedIndex < 0 || combNS.SelectedIndex < 0)
            {

                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            }
            else

            {

                String fili = "nomfiliere";
                String nomF = combFS.SelectedItem.ToString();
               // int id_F = filierServ.getFilierbyNom(nomF);
                int gS = int.Parse(combGS.SelectedItem.ToString());
                int nS=int.Parse(combNS.SelectedItem.ToString());

                Console.WriteLine("nomfiliere :>>>> " + combFS.SelectedItem.ToString());
                String ir = "iir4";
                String query = "Select e.nom,e.prenom,e.cin,e.cne,e.email,e.age,e.sexe,e.date_naissance,e.ville,e.telephone,e.adresse,e.image,f.nom'" + fili + "',e.niveau,e.groupe from etudiants e,filiere f where e.id_filiere = f.id AND f.nom ='" + nomF + "' AND e.niveau='" + nS + "' AND e.groupe='" + gS + "'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable datatable = new DataTable();
                MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                oleDbData.Fill(datatable);
                con.Close();
                InfoEtud.DataSource = datatable;
            }
        }
    }
}
