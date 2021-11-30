﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projet1.Modeles
{
    [Table("Patient")]
    public class Patient : Utilisateur
    {
        #region Attributs
        private int _id;
        #endregion

        #region Constructeurs
        public Patient()
        {
        }
        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public new int ID { get => _id; set => _id = value; }


        #endregion

        #region Methodes
        public static new ObservableCollection<Patient> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Patient>();
        }
        #endregion
    }
}