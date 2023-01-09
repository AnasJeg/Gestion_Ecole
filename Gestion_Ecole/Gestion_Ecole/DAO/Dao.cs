using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Ecole.DAO
{
    internal interface Dao<T>
    {
         void ajouter(T c);
        void modifier(T c);
        void supprimer(T c);

        void afficher(T c);
        void searchById(int id);
    }
}
