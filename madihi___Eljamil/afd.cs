using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace madihi___Eljamil
{
    class afd
    {
        public int Nbr_etat { get; set; }


        public List<string> A { get; set; }

        public int ei { get; set; }

        public int nef { get; set; }

        public List<string> ef { get; set; }

        public int nbT { get; set; }

        public List<fct_trans> t { get; set; }

        public afd()
        {

        }

        public afd read(string namefile)
        {
            int j, A = 0, D = 0;
            char S = ' ';
     
            using (StreamReader O = new StreamReader(namefile))
            {
                int CH = 1;
                string L;

                this.t = new List<fct_trans>(); // intialisation des listes
                this.A = new List<string>();

                this.ef = new List<string>();


                while ((L = O.ReadLine()) != null)            // lire les lignes du fichier ligne par ligne

                {

                    switch (CH)                  
                    {

                        case 1:                              // stocker le nombre d'etat

                            this.Nbr_etat = Int16.Parse(L);

                            break;

                        case 2:                              // stocker les alphabets
                            {
                                string[] alp = L.Split(','); // decoupage de string en plusieur strings selon les                                                                                    virgules

                                foreach (string al in alp)
                                {

                                    this.A.Add(al);          //l'ajout de chaque alphabet dans la liste

                                }

                            }
                            break;

                        case 3:                                  // stocker l'etat initial

                            this.ei = Int16.Parse(L);

                            break;

                        case 4:

                            this.nef = Int16.Parse(L);          // stocker le nombre des etats finaux

                            break;

                        case 5:                                 // stocker les etats finaux

                            string[] ef = L.Split(char.Parse(" "));    // séparer la ligne des etats finaux selon                                                                       "espace"

                            foreach (string e in ef)
                            {
                                this.ef.Add(e);                       // ajouter les etat finaux dans la liste

                            }
                            break;

                        default:  // les transitions


                            string[] trasac = L.Split(char.Parse(" "));   // séparer la ligne(transition) selon "espace"

                            int a = 0;
                            foreach (string tr in trasac)
                            {

                                if (a == 0)
                                    D = (Int16.Parse(tr));            // enregister l'etat initiale 
                                if (a == 1)
                                    S = (char.Parse(tr));            // enregister le symbole                        
                                if (a == 2)
                                    A = (Int16.Parse(tr));            // enregister l'etat finale 

                                a++;


                            }



                            if (S == 'l')       //  L== lettre
                            {
                                for (j = 65; j <= 90; j++)       //Ajouter les symboles de (A-Z)Majiscules par code                                              ASCII
                                {
                                    fct_trans aide = new fct_trans(D, (char)j, A);
                                    this.t.Add(aide);
                                }
                                for (j = 97; j <= 122; j++)     //Ajouter les symboles (a-z)minuscules par code ASCII
                                {
                                    fct_trans aide = new fct_trans(D, (char)j, A);
                                    this.t.Add(aide);
                                }
                            }
                            if (S == 'c')        // c==chiffre
                            {
                                for (j = 48; j <= 57; j++)     //Ajouter les symboles (0-9)chiffres par code ASCII
                                {
                                    fct_trans aide = new fct_trans(D, (char)j, A);
                                    this.t.Add(aide);
                                }
                            }
                            if (S == '1')                  //autre 1 
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if (j != 61)            // Sauf (=)
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '2')             // autre 2
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if (j != 61 && j != 62)           // Sauf (=) et (>)
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '3')             // autre 3
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if ((j < 48) || (j > 57 && j < 65) || (j > 90 && j < 97) || (j > 122)) 
                                    {
                                        // sauf les lettres et les chiffres 

                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '4')          // autre 4
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if ((j < 48 || j > 57) && j != 46) // sauf les chiffres et (.)
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '5')        // autre 5
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if ((j < 48 || j > 57) && j != 69)  // sauf les chiffres et (E)
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '6')                // autre 6
                            {
                                for (j = 32; j <= 126; j++)
                                {
                                    if (j != 42 && j != 41)    // sauf (*) et la parenthese fermante 
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            if (S == '7')        // autre 7
                            {
                                for (j = 32; j <= 126; j++)
                                {

                                    if ((j < 48 || j > 57))   // sauf les chiffres
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }
                            

                            if (S == 'n')                  // n'importe quoi
                            {
                                for (j = 32; j <= 126; j++)
                                {
                                    if ((j != 42) && (j != 34)) //sauf * pour le cas du commentaire et " pour le cas de                                                                     string
                                    {
                                        fct_trans aide = new fct_trans(D, (char)j, A);
                                        this.t.Add(aide);
                                    }

                                }
                            }

                            if (S != 'l' && S != 'c' && S != 'a' && S != 'n' && S != '1' && S != '2' && S != '3' && S != '4' && S != '5' && S != '6' && S != '7')
                            {
                                fct_trans aide = new fct_trans(D, S, A); // le reste 
                                this.t.Add(aide);

                            }


                            break;
                    }
                    CH++;
                }
                this.nbT = this.t.Count;
                //Console.WriteLine("{0}", nbT);
            }

            return this;
        }



        public void print()               // Affichage de l'automate avant l'analyse
        {
                                               

            for (int i = 0; i < this.Nbr_etat; i++)

            {

                if (i == 0)
                    Console.Write("E=({0}", i);

                else
                         if (i == this.Nbr_etat - 1)
                    Console.WriteLine(",{0})", i);
                else
                    Console.Write(",{0}", i);

            }
            Console.Write("\nA={");

            for (int i = 0; i < this.A.Count; i++)
            {
                if (i != this.A.Count - 1)
                {
                    Console.Write("{0},", this.A[i]);
                }
                else
                {
                    Console.Write("{0}", '}', this.A[i]);
                }
            }
            Console.WriteLine();

            Console.WriteLine("\nEI={0}", this.ei);
            Console.WriteLine("\nNEF={0}", this.nef);
            Console.Write("\nEF={");
            for (int i = 0; i < this.ef.Count; i++)
            {
                if (i != this.ef.Count - 1)
                {
                    Console.Write("{0} ", this.ef[i]);
                }
                else
                {
                    Console.Write(this.ef[i], "{0}");
                }
            }
            Console.Write("}\n");

            Console.WriteLine("\nTransitions:");
            for (int i = 0; i < this.t.Count; i++)
            {
                Console.WriteLine("t({0},{1})={2}", this.t[i].etat_initial, this.t[i].sym, this.t[i].etat_Final);
            }


        }
      

        public void resultat(int EtatF, string mot)              // Affichage des resultats obtenu aprés l'analyse du                                                                   fichier
        {
            string[] Motcle = { "IF", "THEN", "ELSE", "BEGIN", "END" };
            int v = 0;
            switch (EtatF)
            {
                case 1:
                    Console.WriteLine("\n<REL,EGAL>");
                    break;
                case 15:
                    Console.WriteLine("\n<REL,SUP>");
                    break;
                case 17:
                    Console.WriteLine("\n<REL,INF>");
                    break;
                case 16:
                    Console.WriteLine("\n<REL,SUPPEGAL>");
                    break;
                case 18:
                    Console.WriteLine("\n<REL,INFEGAL>");
                    break;
                case 19:
                    Console.WriteLine("\n<REL,DIFF>");
                    break;
                case 20:
                    Console.WriteLine("\n<COMMENTAIRE,{0}>", mot);
                    break;
                case 23:
                    Console.WriteLine("\n<STRING,{0}>", mot);
                    break;
                case 24:
                    Console.WriteLine("\n<INT,{0}>", mot);
                    break;
                case 25:
                    Console.WriteLine("\n<OP,{0}>", mot);
                    break;
                case 26:
                    Console.WriteLine("\n<FLOAT,{0}>", mot);
                    break;
                case 27:
                    Console.WriteLine("\n<REAL,{0}>", mot);
                    break;
                case 21:

                    foreach (string m in Motcle)
                    {
                        if ((m.CompareTo(mot) == 0))
                        {
                            Console.WriteLine("\n<MOTCLE,{0}>", mot);
                            v = 1;
                        }
                    }
                    if (v == 0)

                        Console.WriteLine("\n<ID,{0}>", mot);
                    break;
            }
        }


        public int transition(char c, int E)             // Passer d'une etat à l'etat suivante
        {

            for (int i = 0; i < this.nbT; i++)               // parcourir la liste des transisions
            {
                if (this.t[i].etat_initial == E && this.t[i].sym == c)  
                {

                    return this.t[i].etat_Final;            //retourner l'etat finale

                }
            }

            return -1;        // -1 si l'expression régulière n'apparitent pas a la liste des transitions

        }


        public void accept(string fichier_test) // l'appel de la fonction accept se fait par un objet AFD 
                                             // Et prend un fichier test.txt qui contient les exepressions régulières

        {
            int etat = this.ei;
            StreamReader R = new StreamReader(fichier_test);
 
            List<char> caracteres = new List<char>();     // liste pour stocker chaque caractere

            int k = 0;
            int b = 0;
            int etat_temp;
            while (!R.EndOfStream)
            {
                char c = (char)R.Read();             //lire les exepressions régulières dans le fichier

                if (c == '\n')
                    c = ' ';

                caracteres.Add(c);                   // ajouter  les exepressions régulières à la liste

                k++;

            }

            char temp = ' ';                        // ajouter espace a la fin de la liste , pour vérifier le cas de                                              Autre à la fin du fichier.
            caracteres.Add(temp);


            for (int i = 0; i < caracteres.Count; i++) // Pour windows, le passage à la ligne dans un fichier txt est                                               formé de deux caractères : "\r\n"
            {
                caracteres.Remove('\r');               // pour ça on supprime les /r et /n et deja remplacé par espace.
            }


            Console.WriteLine();


            for (int i = 0; i < caracteres.Count; i++)      // parcourir la liste 
            {

                int double_cot = 0;
                int etoile = 0;
                string strin = "";                       
                string comment = "";
                string test = "";
                //Console.WriteLine(b);
                if (i < caracteres.Count)
                    b = 0;

                while ((etat == 0 || etat != 1 || etat != 15 || etat != 16 || etat != 17 || etat != 18 || etat != 19 || etat != 20 || etat != 21 || etat != 23 || etat != 24 || etat != 25 || etat != 27) && (b == 0))
                {
                                                 // cette boucle permet de continuer la vérification jusqu'a trouvé une                         etat Final ou sinon revenir a l'etat 0 pour tester un autre                                                         caractere
                    etat_temp = etat;

                    etat = this.transition(caracteres[i], etat);  // retourner l'etat suivante s'il existe
                    

                    if (etat == -1)                      // si -1 on appelle fct resultat 
                    {

                        b = 1;                                           // le b confirme le resultat trouvé pour                                                          arréter la  boucles while .

                        resultat(etat_temp, caracteres[i].ToString());    // affichage du caractere 
                    }

                    int j = 0;

                    for (; (j < this.nef) && (etat != Int16.Parse(this.ef[j])); j++) ; //vérifier si l'etat  appartient                                                                   à la liste des etats finaux

                    if (j == this.nef)    // decrémenter j par 1 pour qu'il ne depasse pas la taille de la liste vu                           qu'il  s'incremente à la fin de la boucle for
                    {
                        j--;
                    }
                    if (etat != Int16.Parse(this.ef[j]))         // si l'etat n'appartient pas à la liste des etats                                                 finaux 
                    {
                        if ((etat == 9) && (etoile == 1))        // continuer a concaténer les caracteres du commentaire                                         et les stocker dans la chaine comment jusqu'à                                                  l'arrivé  à l'etat finale (20)
                            comment += caracteres[i];

                        if (etat == 9) etoile = 1;            // tant que l'etat différent de 12

                        //------------------------------------------------------------------

                        if ((etat == 5) && (double_cot == 1))   // continuer a concaténer les caracteres du string                                                   et les stocker dans la chaine string jusqu'à                                                  l'arrivé  à l'etat finale (23)
                            strin += caracteres[i];

                        if (etat == 5)
                            double_cot = 1;                     // pour ne pas stocker les doubles cotes

                        test += caracteres[i];       // Autre 
                    }


                    if (etat == Int16.Parse(this.ef[j]))  // si etat appartient à la liste des etats finaux
                    {
                        if (etat == 15 || etat == 17 || etat == 21 || etat == 24 || etat == 26 || etat == 27) //autre
                        {
                            resultat(etat, test);

                            b = 1;

                            if (caracteres[i] == ' ')  // si Autre égale a espace on décremente i une seule fois pour se                            trouver sur l'exepression régulière suivante
                            {
                                i--;
                            }
                            else { i = i - 2; }   // sinon deux fois 

                        }
                        else
                        {
                            if (etat == 23 || etat == 20)   // l'etat finale du string ou commentaire 
                            {
                               // test += caracteres[i];
                                if (etat == 23) //string
                                {
                                    resultat(etat, strin);
                                }
                                if (etat == 20) // commentaire
                                {

                                    resultat(etat, comment);
                                }
                            }
                            if (etat == 25)  // les operateurs arithmitiqes
                            {
                                resultat(etat, caracteres[i].ToString());

                                i--;
                            }
                            b = 1;

                        }
                    }

                    i++;

                    if (i == caracteres.Count) b = 1;   // l'arret de la boucle while 
                }
                //i--;
                etat = 0;        //  réinitialiser l'etat par 0 pour tester une autre exepression régulière

            }
        }

    }
}