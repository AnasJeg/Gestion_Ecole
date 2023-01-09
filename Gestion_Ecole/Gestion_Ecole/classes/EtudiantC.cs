using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Ecole
{
    internal class EtudiantC
    {
        private int id;
        private string nom;
        private string prenom;
        private string cin;
        private string tell;
        private string email;
        private string adresse;
        private DateTime date_N;
        private string genre;
        private string ville;
        private string image;
        private static int cnt = 0;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Tell { get => tell; set => tell = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime Date_N { get => date_N; set => date_N = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Image { get => image; set => image = value; }

        public EtudiantC( string nom, string prenom, string cin, string tell, string email, string adresse, DateTime date_N, string genre, string ville, string image)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.tell = tell;
            this.email = email;
            this.adresse = adresse;
            this.date_N = date_N;
            this.genre = genre;
            this.ville = ville;
            this.image = image;
        }

        public EtudiantC(int id, string nom, string prenom, string cin, string tell, string email, string adresse, DateTime date_N, string genre, string ville, string image)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.tell = tell;
            this.email = email;
            this.adresse = adresse;
            this.date_N = date_N;
            this.genre = genre;
            this.ville = ville;
            this.image = image;
        }
    }
}
