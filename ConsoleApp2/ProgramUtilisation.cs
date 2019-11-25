using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class ProgramUtilisation
    {
        private UtilApi utilApi;

        public ProgramUtilisation()
        {
            this.utilApi = new UtilApi("5.727718", "45.185603");
        }

        public void afficheLigne()
        {
            Dictionary<string, List<ArrayJson>> listeArretTram = this.utilApi.getListLigne(600);
            
            foreach (KeyValuePair<string, List<ArrayJson>> element in listeArretTram)
            {
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================");
                Console.WriteLine(element.Key);
                Console.WriteLine("==============================================================");
                Console.WriteLine(" ");
                foreach (ArrayJson p in element.Value)
                {
                    foreach(String ligne in p.lines)
                    {
                        Console.WriteLine(ligne);
                        Console.WriteLine(this.utilApi.getLigneInfos(ligne));
                        Console.WriteLine("                                  ----------------                  ");
                    }
                }
            }
        }
    }
}
