using System;
using System.Collections.Generic;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetListLigne()
        {
            UtilApi prog = new UtilApi(new FakeAppelsApi(), "5.727718", "45.185603");
            Dictionary<string, List<ArrayJson>> ATeste = prog.getListLigne(500);
            ArrayJson pourTest = new ArrayJson();
            pourTest.id = "SEM:1986";
            pourTest.name = "GRENOBLE, CASERNE DE BONNE";
            pourTest.lon = 5.72533;
            pourTest.lat = 45.18506;
            pourTest.zone = "SEM_GENCASBONNE";
            pourTest.lines = new List<string>();
            pourTest.lines.Add("SEM:16");

            
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].lines[0], pourTest.lines[0]);
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].id, pourTest.id);
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].name, pourTest.name);
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].lon, pourTest.lon);
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].lat, pourTest.lat);
            Assert.AreEqual(ATeste["GRENOBLE, CASERNE DE BONNE"][0].zone, pourTest.zone);
        }

        [TestMethod]
        public void TestGetLigneInfos()
        {
            UtilApi prog = new UtilApi(new FakeAppelsApi2(), "5.727718", "45.185603");
            String ATeste = prog.getLigneInfos("10");
            InfoArret pourTest = new InfoArret();
            pourTest.id = "C38:6020";
            pourTest.gtfsId = "C38:6020";
            pourTest.shortName = "6020";
            pourTest.longName = "CROLLES-MEYLAN-GRENOBLE";
            pourTest.color = "ff7917";
            pourTest.textColor = "FFFFFF";
            pourTest.mode = "BUS";
            pourTest.type = "C38";

            String affiche = "ligne " + pourTest.longName + " ------- Mode : " + pourTest.mode + " ------ Type : " + pourTest.type;

            Assert.AreEqual(ATeste, affiche);
        }
    }
}
