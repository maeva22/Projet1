using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Modeles
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        #region Attributs
        private int _id;
        private string _genre;
        private string _nom;
        private string _prenom;
        private DateTime _dateDeNaissance;
        private string _numeroTelephone;
        private string _email; 
        private string _password;

        #endregion

        #region Constructeurs
        public Utilisateur()
        {
        }

        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public DateTime DateDeNaissance { get => _dateDeNaissance; set => _dateDeNaissance = value; }
        public string NumeroTelephone { get => _numeroTelephone; set => _numeroTelephone = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        #endregion

        #region Methodes
        public static ObservableCollection<Utilisateur> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Utilisateur>();
        }

        #endregion
    }
}
