using Gestion_Ecole.classes;
using Gestion_Ecole.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Ecole.services
{
    internal class FilierService : Dao<FiliereC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");

        public void afficher(FiliereC c)
        {
            throw new NotImplementedException();
        }

        public void ajouter(FiliereC c)
        {
            throw new NotImplementedException();
        }

        public void modifier(FiliereC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public void supprimer(FiliereC c)
        {
            throw new NotImplementedException();
        }

        public int getFilierbyNom(String nf)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                MySqlCommand cmd = new MySqlCommand("select id from filiere where nom='" + nf + "'",con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("getFilierbyNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }
    }
}
