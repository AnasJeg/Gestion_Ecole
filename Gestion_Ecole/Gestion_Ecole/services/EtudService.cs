using Gestion_Ecole.classes;
using Gestion_Ecole.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Ecole.services
{
    internal class EtudService : Dao<StudentC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
      

        public void ajouter(StudentC c)
        {
            
        try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
    MySqlCommand req = new MySqlCommand("INSERT INTO etudiants(nom,prenom,cin,cne,email,age,sexe,date_naissance,ville,telephone,adresse,image,id_filiere,niveau,groupe) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)", con);
    req.Parameters.AddWithValue("@n", c.Nom);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Prenom);
                req.Parameters.AddWithValue("@3", c.Cin);
                req.Parameters.AddWithValue("@4", c.Cne);
                req.Parameters.AddWithValue("@5", c.Email);
                req.Parameters.AddWithValue("@6", c.Age);
                req.Parameters.AddWithValue("@7", c.Sexe);
                req.Parameters.AddWithValue("@8", c.Date_N);
                req.Parameters.AddWithValue("@9", c.Ville);
                req.Parameters.AddWithValue("@10",c.Telephone);
                req.Parameters.AddWithValue("@11",c.Address);
                req.Parameters.AddWithValue("@12",c.Image);
                req.Parameters.AddWithValue("@13",c.Filiere);
                req.Parameters.AddWithValue("@14",c.Niveau);
                req.Parameters.AddWithValue("@15",c.Groupe);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
{
    DialogResult dd = MessageBox.Show("add etudiants sql !!");
    Console.WriteLine(ex.Message);

}
        }

        public void modifier(StudentC c)
        {
            throw new NotImplementedException();
        }

     

        public void supprimer(StudentC c)
        {
            throw new NotImplementedException();
        }

        public void afficher(StudentC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public int getIdEtudiantByCIN(String a)
        {

            if (con.State != ConnectionState.Open) { con.Open(); }
            int c = 0;
            MySqlCommand cmd = new MySqlCommand("select id from etudiants where cin='" + a + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = (int)reader[0];

            }
            con.Close();
            return c;
        }
    }
}
