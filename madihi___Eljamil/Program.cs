using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace madihi___Eljamil
{
    class Program
    {



        static void Main(string[] args)
        {

            afd O = new afd();
            Console.WriteLine("Entrez Le nom de fichier (.txt) du l'automate  : ");
            //string nom_fichier = Console.ReadLine();
            O.read("autom.txt");
            O.print();

            Console.WriteLine("\nEntrez Le nom de fichier (.txt) a analyser: ");
            // string test = Console.ReadLine();           

            O.accept("test.txt");
           




            /*
                        StreamReader R = new StreamReader("test.txt");
                        int k = -1;
                        int etat = O.ei;
                        char[] c = new char[50];

                        do
                        {

                            k++;
                            c[k] = (char)R.Read();

                            c[k + 1] = '\0';

                            if (c[k] == '\n' || c[k] == -1) 
                                        {
                                            c[k] = ' ';
                                        }
                                        etat = O.action(c[k], etat);

                                        int j = 0;
                                        for (; (j < O.nef) && (etat != Int16.Parse(O.ef[j])); j++) ;
                            if (j != O.nef)
                            {
                                if (etat == Int16.Parse(O.ef[j]))
                                {
                                    if (etat != 26) //hadi f le cas dial commentaire(* ......*) titignora
                                    {
                                           // Console.WriteLine("{0}", );
                                        string resultat = String.Copy(O.test(etat, c.ToString()));

                                        if (etat == 15 || etat == 17 || etat == 21 || etat == 24 || etat == 26 || etat == 27) // had condition jma3t fiha ga3 les etats finaux li tissaliw b Autre 7
                                        {

                                            if (etat == 15 || etat == 17) // hna 7it an affichi INF wla  SUPP  li atkun F C  hadchi 3lach dertha  dozo else bach tfhmo kter
                                            {
                                                Console.WriteLine("\n<{0},{0}>", resultat, c);                                                                                                    //hadchi 3lach dert f dik condition dok les etat li fihom SUUPP w INFF bach man2ecrasich caracter lakhar dialhom
                                            }
                                            else // f had else kan khasni n2affichi la valeur dial C mais la valeur dial C kan endha dak autre f lakhar hadchi 3lach   ecrasito    f had else // kml hna^
                                            {
                                                c[k] = '\0';
                                                Console.WriteLine("\n<{0},{0}>", resultat, c);
                                            }
                                            if (!R.EndOfStream)
                                            R.BaseStream.Seek(-1, SeekOrigin.Current);
                                            //R.Seek(-1, SeekOrigin.Current);
                                            //fseek(F, -1, SEEK_CUR); // tanrja3 pointeur b case w7da hiya f le cas dial autre marche en arriere
                                        }
                                        else//had else dial if ster 359 ya3ni hadok li mafihomch autre
                                        {

                                            Console.WriteLine("\n<{0},{0}>", resultat, c);
                                        }
                                        k = -1; // hna tan2initialisi kolchi
                                        c[0] = '\0';
                                        etat = 0;
                                    }
                                }
                            }
                                        if (etat == -1 || etat == 26) // hadi dert etat -1 ya3ni ila massad9atch transition wla wslt f  etats final 26 dial commentaire  taninitialisi kolchi
                                        {

                                            k = -1;
                                            c[0] = '\0';
                                            etat = 0;
                                        }

                                    } while (!R.EndOfStream); // feof tatrja3 true ila kanat nihaya dial fichier w false ila kena ba9in  mawslna lnihaya

                               */

            Console.ReadKey();
        }
    }
}
