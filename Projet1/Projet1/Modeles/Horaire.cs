using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Modeles
{
    [Table("Horaire")]
    public class Horaire
    {
        #region Attributs
        private int _id;
        private string _heuredébut;
        private int _professionelId;
        #endregion

        #region Constructeurs
        public Horaire()
        {
            
        }
        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public  int ID { get => _id; set => _id = value; }
        public string Heuredébut { get => _heuredébut; set => _heuredébut = value; }
        [ForeignKey(typeof(Professionnel))]     // Specify the foreign key
        public int IDProfessionel { get => _professionelId; set => _professionelId = value; }

        #endregion

        #region Methodes

        public static ObservableCollection<Horaire> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Horaire>();
        }
        public static async Task<Horaire> AjoutItemSqlite(Horaire param)
        {
            await App.Database.SaveItemAsync<Horaire>(param);
            return param;
        }
        #endregion
    }
}
