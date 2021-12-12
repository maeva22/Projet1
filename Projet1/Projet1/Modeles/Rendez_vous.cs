using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projet1.Modeles
{
    [Table("Rendez_vous")]
    public class Rendez_vous
    {
        #region Attributs
        private int _id;
        private DateTime _dateRendezVous;
        private int _idProfessionel;
        private int _idPatient;
        private int _idHoraire;

        #endregion

        #region Constructeurs
        public Rendez_vous()
        {
        }

        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public DateTime DateRendezVous { get => _dateRendezVous; set => _dateRendezVous = value; }
        [ForeignKey(typeof(Professionnel))]     // Specify the foreign key
        public int IDProfessionel { get => _idProfessionel; set => _idProfessionel = value; }
        [ForeignKey(typeof(Patient))]     // Specify the foreign key
        public int IDPatient { get => _idPatient; set => _idPatient = value; }
        [ForeignKey(typeof(Horaire))]     // Specify the foreign key
        public int IDHoraire { get => _idHoraire; set => _idHoraire = value; }
        #endregion

        #region Methodes
        public static ObservableCollection<Rendez_vous> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Rendez_vous>();
        }

        #endregion
    }
}
