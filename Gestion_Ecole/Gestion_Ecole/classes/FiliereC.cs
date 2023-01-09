using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Ecole.classes
{
    internal class FiliereC
    {
        private int id;
        private string nom;
        private string specialite;
        private int id_resp;
        private int id_dept;
        private static int cnt = 0;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Specialite { get => specialite; set => specialite = value; }
        public int Id_resp { get => id_resp; set => id_resp = value; }
        public int Id_dept { get => id_dept; set => id_dept = value; }

        public FiliereC( string nom, string specialite, int id_resp, int id_dept)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.specialite = specialite;
            this.id_resp = id_resp;
            this.id_dept = id_dept;
        }

        public FiliereC(int id, string nom, string specialite, int id_resp, int id_dept)
        {
            this.id = id;
            this.nom = nom;
            this.specialite = specialite;
            this.id_resp = id_resp;
            this.id_dept = id_dept;
        }
    }
}
