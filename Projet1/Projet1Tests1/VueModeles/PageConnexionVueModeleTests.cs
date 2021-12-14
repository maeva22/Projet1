using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet1.Modeles;
using Projet1.VueModeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1.VueModeles.Tests
{
    [TestClass()]
    public class PageConnexionVueModeleTests
    {
        [TestMethod()]
        public void OnSubmitTest()
        {
            // jeu d'essai 
            Patient TR1 = new Patient(1,"homme","nom1","prenom1",DateTime.Now,"0546821946","adresse@gamil.com","password");
            
            Patient.CollPatientConnecter.Add(TR1);
            //test methode
            int expective = Patient.CollPatientConnecter.Count;

            // Assert
            Assert.AreEqual(expective, 1);
        }
    }
}