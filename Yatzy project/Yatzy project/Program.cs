using System.Security.Cryptography.X509Certificates;

namespace Yatzy_project
{

    internal class Program
    {
        //Alle spillerer har deres eget scoreboard i toppen af deres skærm under deres runde
        //Alle spillerer kører runde X igennem, fuld scoreboard for alle spillerer vises før runde X+1


        static void Main(string[] args)
        {
            int kørteRunder = 0;
            string spiller1Navn = "Spiller 1";  //Bruger input senere
            string spiller2Navn = "Spiller 2";
            int[] spiller1Scoreboard = new int[16] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0 };
            int[] spiller2Scoreboard = new int[16] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0 };
            bool spiller1Bonus = false, spiller2Bonus = false;
            int spiller1Total = 0, spiller2Total = 0;

            Console.WriteLine("Velkommen til Team 10's Yatzy!");
            Console.WriteLine("Her spiller vi med følgene regler: ");
            Console.WriteLine("6 terninger, 1 par, 2 par, 3 ens, 4 ens, lille straight, store straight, chancen, yatzy, og 63 total.");
            Console.Write("\nIndsæt brugernavn for {0}: ", spiller1Navn);
            spiller1Navn = Console.ReadLine();
            Console.Write("\nIndsæt brugernavn for {0}: ", spiller2Navn);
            spiller2Navn = Console.ReadLine();

            while (kørteRunder < 14) //antal runder den skal køre
            {
                int[] terningerVærdi = new int[5] { 0, 0, 0, 0, 0 };
                bool[] erTerningerLåst = new bool[5] { false, false, false, false, false }; //Skal alle sættes til falsk før vi bruger dem
                bool kasterTerninger = true;
                int tilbageVærendeTerninger = 5;
                int kastNummer = 0;

                while (kasterTerninger)
                {
                    kastNummer++;
                    Console.Clear();
                    VisScoreboard(spiller1Navn, spiller1Scoreboard);
                    //Kald metoden med disse værdier
                    KastTerninger(terningerVærdi, erTerningerLåst);
                    LåsTerninger(kastNummer, erTerningerLåst);

                    if (kastNummer == 3 || tilbageVærendeTerninger == 0)
                    {
                        kasterTerninger = false;

                        Scoreboard1(terningerVærdi, spiller1Navn, spiller1Scoreboard, spiller1Bonus);
                    }
                }

                Console.Clear();
                VisScoreboard(spiller1Navn, spiller1Scoreboard);
                Console.WriteLine("\nTryk Enter for at fortsætte.");
                Console.ReadLine();
                Console.Clear();

                terningerVærdi = new int[5] { 0, 0, 0, 0, 0 };
                erTerningerLåst = new bool[5] { false, false, false, false, false };
                kasterTerninger = true;
                tilbageVærendeTerninger = 5;
                kastNummer = 0;

                while (kasterTerninger)
                {
                    kastNummer++;
                    Console.Clear();
                    VisScoreboard(spiller2Navn, spiller2Scoreboard);
                    //Kald metoden med disse værdier
                    KastTerninger(terningerVærdi, erTerningerLåst);
                    LåsTerninger(kastNummer, erTerningerLåst);

                    if (kastNummer == 3 || tilbageVærendeTerninger == 0)
                    {
                        kasterTerninger = false;
                        Scoreboard2(terningerVærdi, spiller2Navn, spiller2Scoreboard, spiller2Bonus);
                    }
                }

                Console.Clear();
                VisScoreboard(spiller2Navn, spiller2Scoreboard);
                Console.WriteLine("\nTryk Enter for at fortsætte.");
                Console.ReadLine();
                Console.Clear();

                kørteRunder += 1;
                if(kørteRunder == 14)
                {

                    Console.Write("Spillet er slut");
                    VisScoreboard(spiller1Navn, spiller1Scoreboard);
                    VisScoreboard(spiller2Navn, spiller2Scoreboard);
                    if (spiller1Scoreboard[15] > spiller2Scoreboard[15]) Console.WriteLine("{0} vandt med {1} point over {2} der havde {3} point", spiller1Navn, spiller1Scoreboard[15], spiller2Navn, spiller2Scoreboard[15]);
                    else if (spiller1Scoreboard[15] < spiller2Scoreboard[15]) Console.WriteLine("{0} vandt med {1} point over {2} der havde {3} point", spiller2Navn, spiller2Scoreboard[15], spiller1Navn, spiller1Scoreboard[15]);
                    else Console.WriteLine("Spillet endte uafgjort");
                }


            }
            Console.WriteLine("Spillet er afsluttet");
        }

        private static void KastTerninger(int[] terningerVærdi, bool[] erTerningerLåst)
        {
            Random r = new Random();
            //For hver terning...
            for (int i = 0; i < 5; i++)
            {       //Hvis terningen ikke er låst, randomize. 
                if (erTerningerLåst[i] == false)
                {
                    Console.WriteLine("Terning {0}: {1}", (i + 1), terningerVærdi[i] = r.Next(1, 7));
                }
                else    //Ellers udskriv kendte/forrige værdi
                {
                    Console.WriteLine("Terning {0}: {1}", (i + 1), terningerVærdi[i]);
                    erTerningerLåst[i] = false;
                }

            }

        }

        private static void LåsTerninger(int kastNummer, bool[] erTerningerLåst)
        {
            if (kastNummer < 3)
            {
                Console.Write("Vælg de terninger du vil beholde: ");
                string str = Console.ReadLine();

                if (str.Contains('1')) erTerningerLåst[0] = true;
                if (str.Contains('2')) erTerningerLåst[1] = true;
                if (str.Contains('3')) erTerningerLåst[2] = true;
                if (str.Contains('4')) erTerningerLåst[3] = true;
                if (str.Contains('5')) erTerningerLåst[4] = true;
            }
            else
            {
                Console.WriteLine("");
            }
        }

        static int SumOfNumberOfEyes(int eyes, int t1, int t2, int t3, int t4, int t5)
        {
            int r = 0;
            if (eyes == t1) r++;
            if (eyes == t2) r++;
            if (eyes == t3) r++;
            if (eyes == t4) r++;
            if (eyes == t5) r++;
            return r;
        }

        static void SumOf1Pair(int i, int[] spiller1Scoreboard, int sum1, int sum2, int sum3, int sum4, int sum5, int sum6)
        {
            if (sum6 > 1)
            {
                spiller1Scoreboard[i] = (6 * 2);
            }
            else if (sum5 > 1)
            {
                spiller1Scoreboard[i] = (5 * 2);
            }
            else if (sum4 > 1)
            {
                spiller1Scoreboard[i] = (4 * 2);
            }
            else if (sum3 > 1)
            {
                spiller1Scoreboard[i] = (3 * 2);
            }
            else if (sum2 > 1)
            {
                spiller1Scoreboard[i] = (2 * 2);
            }
            else if (sum1 > 1)
            {
                spiller1Scoreboard[i] = (1 * 2);
            }
            else
            {
                spiller1Scoreboard[i] = 0;
            }
        }



        static bool[] parCheck(int sum1, int sum2, int sum3, int sum4, int sum5, int sum6)
        {
            int parVærdi = 2;
            bool par1 = false, par2 = false, par3 = false, par4 = false, par5 = false, par6 = false;



            if (parVærdi <= sum1)
            {
                par1 = true;
            }
            if (parVærdi <= sum2)
            {
                par2 = true;
            }
            if (parVærdi <= sum3)
            {
                par3 = true;
            }
            if (parVærdi <= sum4)
            {
                par4 = true;
            }
            if (parVærdi <= sum5)
            {
                par5 = true;
            }
            if (parVærdi <= sum6)
            {
                par6 = true;  
            }

            bool[] muligePar = {par1, par2, par3, par4, par5, par6};  
            //Console.WriteLine(string.Join(", ",muligePar));
            return muligePar;
        }
        
        static void VisScoreboard(string spillerXNavn, int[] spillerXScoreboard)
        {

            /*Console.WriteLine("Tryk Enter for at fortsætte.");
            Console.ReadLine();
            Console.Clear();*/
            Console.WriteLine(spillerXNavn);  //Sæt til variable
            Console.WriteLine(" | a 1ere | b 2ere | c 3ere | d 4ere | e 5ere | f 6ere | g 1par | h 2par | i 3ens | j 4ens | ");
            Console.WriteLine(" |    {0,3} |    {1,3} |    {2,3} |    {3,3} |    {4,3} |    {5,3} |    {6,3} |    {7,3} |    {8,3} |    {9,3} | ",
            spillerXScoreboard[0], spillerXScoreboard[1], spillerXScoreboard[2], spillerXScoreboard[3], spillerXScoreboard[4],
            spillerXScoreboard[5], spillerXScoreboard[6], spillerXScoreboard[7], spillerXScoreboard[8], spillerXScoreboard[9]);
            Console.WriteLine(" | k lille straight | l store straight | m chancen | n yatzy | - | total 1-6 | - | total | ");
            Console.WriteLine(" | (15)         {0,3} | (20)         {1,3} |       {2,3} | (50){3,3} | - | (50)  {4,3} | - |   {5,3} | ",
            spillerXScoreboard[10], spillerXScoreboard[11], spillerXScoreboard[12], spillerXScoreboard[13], spillerXScoreboard[14], spillerXScoreboard[15]);

        }

        static int[] Scoreboard1(int[] terningerVærdi, string spiller1Navn, int[] spiller1Scoreboard, bool spiller1Bonus)
        {
            int sum1, sum2, sum3, sum4, sum5, sum6;

            sum1 = SumOfNumberOfEyes(1, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum2 = SumOfNumberOfEyes(2, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum3 = SumOfNumberOfEyes(3, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum4 = SumOfNumberOfEyes(4, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum5 = SumOfNumberOfEyes(5, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum6 = SumOfNumberOfEyes(6, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);



            /*
            Console.WriteLine("Tryk Enter for at fortsætte.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(spiller1Navn);  //Sæt til variable
            Console.WriteLine(" | a-1ere | b-2ere | c-3ere | d-4ere | e-5ere | f-6ere | g-1par | h-2par | i-3ens | j-4ens | ");
            Console.WriteLine(" |    {0,3} |    {1,3} |    {2,3} |    {3,3} |    {4,3} |    {5,3} |    {6,3} |    {7,3} |    {8,3} |    {9,3} | ",
            spiller1Scoreboard[0], spiller1Scoreboard[1], spiller1Scoreboard[2], spiller1Scoreboard[3], spiller1Scoreboard[4], 
            spiller1Scoreboard[5], spiller1Scoreboard[6], spiller1Scoreboard[7], spiller1Scoreboard[8], spiller1Scoreboard[9]);
            Console.WriteLine(" | k-lille straight | l-store straight | m-chancen | n-yatzy | - | total 1-6 | -  total | ");
            Console.WriteLine(" | (15)         {0,3} | (20)         {1,3} |       {2,3} | (50){3,3} | - | (50)  {4,3} | - |   {5,3} | ",
            spiller1Scoreboard[10], spiller1Scoreboard[11], spiller1Scoreboard[12], spiller1Scoreboard[13], spiller1Scoreboard[14], spiller1Scoreboard[15]);
            */

            




            

            bool[] muligePar = parCheck(sum1, sum2, sum3, sum4, sum5, sum6);
            char allocationSelected = '0';
            bool scoreboardAktiv = true;
            while (scoreboardAktiv == true)
            {
                Console.Clear();

                VisScoreboard(spiller1Navn, spiller1Scoreboard);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Terning {0}: {1}", (i + 1), terningerVærdi[i]);
                }
                Console.Write("Vælg et punkt: ");
                allocationSelected = Console.ReadKey(false).KeyChar;
                if (allocationSelected >= 97 && allocationSelected <= 110)
                {
                    scoreboardAktiv = false;
                    switch (allocationSelected)
                    {
                        case 'a' when spiller1Scoreboard[0] == -1:
                            spiller1Scoreboard[0] = sum1;
                            Console.WriteLine("Du valgte 1ere: {0} ", spiller1Scoreboard[0]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[0];
                            spiller1Scoreboard[14] += spiller1Scoreboard[0];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'b' when spiller1Scoreboard[1] == -1:
                            spiller1Scoreboard[1] = sum2 * 2;
                            Console.WriteLine("Du valgte 2ere: {0} ", spiller1Scoreboard[1]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[1];
                            spiller1Scoreboard[14] += spiller1Scoreboard[1];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'c' when spiller1Scoreboard[2] == -1:
                            spiller1Scoreboard[2] = sum3 * 3;
                            Console.WriteLine("Du valgte 3ere: {0} ", spiller1Scoreboard[2]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[2];
                            spiller1Scoreboard[14] += spiller1Scoreboard[2];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'd' when spiller1Scoreboard[3] == -1:
                            spiller1Scoreboard[3] = 0;
                            spiller1Scoreboard[3] = sum4 * 4;
                            Console.WriteLine("Du valgte 4ere: {0} ", spiller1Scoreboard[3]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[3];
                            spiller1Scoreboard[14] += spiller1Scoreboard[3];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'e' when spiller1Scoreboard[4] == -1:
                            spiller1Scoreboard[4] = 0;
                            spiller1Scoreboard[4] = sum5 * 5;
                            Console.WriteLine("Du valgte 5ere: {0} ", spiller1Scoreboard[4]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[4];
                            spiller1Scoreboard[14] += spiller1Scoreboard[4];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'f' when spiller1Scoreboard[5] == -1:
                            spiller1Scoreboard[5] = 0;
                            spiller1Scoreboard[5] = sum6 * 6;
                            Console.WriteLine("Du valgte 6ere: {0} ", spiller1Scoreboard[5]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[5];
                            spiller1Scoreboard[14] += spiller1Scoreboard[5];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'g' when spiller1Scoreboard[6] == -1:
                            spiller1Scoreboard[6] = 0;
                            SumOf1Pair(6, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte 1par: {0} ", spiller1Scoreboard[6]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[6];
                            spiller1Scoreboard[14] += spiller1Scoreboard[6];
                            if (spiller1Scoreboard[14] >= 63 && spiller1Bonus!) spiller1Scoreboard[15] += 50;
                            break;
                        case 'h' when spiller1Scoreboard[7] == -1:

                            int antalMuligePar = 0;
                            spiller1Scoreboard[7] = 0;

                            for (int i = 0; i < 6; i++)
                            {


                                if (muligePar[i])
                                {
                                    antalMuligePar += 1;

                                    spiller1Scoreboard[7] += (i + 1) * 2;

                                }

                            }


                            if (antalMuligePar < 2)
                            {
                                spiller1Scoreboard[7] = 0;
                                Console.WriteLine("Ingen mulige par");
                            }



                            Console.WriteLine("Du valgte 2par: {0} ", spiller1Scoreboard[7]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[7];
                            break;

                        case 'i' when spiller1Scoreboard[8] == -1:
                            if (sum1 >= 3) spiller1Scoreboard[8] = 3;
                            else if (sum2 >= 3) spiller1Scoreboard[8] = 6;
                            else if (sum3 >= 3) spiller1Scoreboard[8] = 9;
                            else if (sum4 >= 3) spiller1Scoreboard[8] = 12;
                            else if (sum5 >= 3) spiller1Scoreboard[8] = 14;
                            else if (sum6 >= 3) spiller1Scoreboard[8] = 18;
                            else spiller1Scoreboard[8] = 0;

                            Console.WriteLine("Du valgte 3 ens: {0}", spiller1Scoreboard[8]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[8];
                            break;

                        case 'j' when spiller1Scoreboard[9] == -1:
                            if (sum1 >= 4) spiller1Scoreboard[9] = 4;
                            else if (sum2 >= 4) spiller1Scoreboard[9] = 8;
                            else if (sum3 >= 4) spiller1Scoreboard[9] = 12;
                            else if (sum4 >= 4) spiller1Scoreboard[9] = 15;
                            else if (sum5 >= 4) spiller1Scoreboard[9] = 20;
                            else if (sum6 >= 4) spiller1Scoreboard[9] = 24;
                            else spiller1Scoreboard[9] = 0;

                            Console.WriteLine("Du valgte 4 ens: {0}", spiller1Scoreboard[9]);
                            spiller1Scoreboard[15] += spiller1Scoreboard[9];
                            break;

                        case 'k' when spiller1Scoreboard[10] == -1:


                            if (terningerVærdi.Contains(1) && terningerVærdi.Contains(2) && terningerVærdi.Contains(3)
                               && terningerVærdi.Contains(4) && terningerVærdi.Contains(5))
                            {
                                spiller1Scoreboard[10] = 15;
                                Console.WriteLine("Du valgte lille straight: {0}", spiller1Scoreboard[10]);
                                spiller1Scoreboard[15] += spiller1Scoreboard[10] + 15;
                            }
                            else
                            {
                                spiller1Scoreboard[10] = 0;
                                Console.WriteLine("Du har ikke et lille straight");
                            }
                            break;

                        case 'l' when spiller1Scoreboard[11] == -1:
                            if (terningerVærdi.Contains(2) && terningerVærdi.Contains(3) && terningerVærdi.Contains(4)
                                  && terningerVærdi.Contains(5) && terningerVærdi.Contains(6))
                            {
                                spiller1Scoreboard[11] = 20;
                                Console.WriteLine("Du valgte store straight: {0} ", spiller1Scoreboard[11]);
                                spiller1Scoreboard[15] += spiller1Scoreboard[11] + 20;
                            }
                            else
                            {
                                spiller1Scoreboard[11] = 0;
                                Console.WriteLine("Du har ikke et stort straight");
                            }
                            break;

                        case 'm' when spiller1Scoreboard[12] == -1:
                            spiller1Scoreboard[12] = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                spiller1Scoreboard[12] += terningerVærdi[i];
                            }
                            spiller1Scoreboard[15] += spiller1Scoreboard[12];
                            Console.WriteLine("Du valgte chancen: {0} ", spiller1Scoreboard[12]);

                            break;

                        case 'n' when spiller1Scoreboard[13] == -1:
                            spiller1Scoreboard[13] = 0;
                            if (terningerVærdi[0] == terningerVærdi[1] && terningerVærdi[1] == terningerVærdi[2]
                            && terningerVærdi[2] == terningerVærdi[3] && terningerVærdi[3] == terningerVærdi[4])
                            {
                                spiller1Scoreboard[13] = terningerVærdi[0] * 5;
                                spiller1Scoreboard[15] += spiller1Scoreboard[13] + 50;
                                Console.WriteLine("Du valgte yatzy: {0} (bonus {1})", spiller1Scoreboard[13], 50);
                                
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke yatzy");
                            }

                            break;

                        default:
                            scoreboardAktiv = true;
                            Console.WriteLine("Indtast et andet punkt"); 
                            Console.WriteLine("Tryk Enter for at fortsætte.");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input ubrugeligt"); 
                    Console.WriteLine("Tryk Enter for at fortsætte.");
                    Console.ReadLine();
                }
            }

            return spiller1Scoreboard;


        }
        static int[] Scoreboard2(int[] terningerVærdi, string spiller2Navn, int[] spiller2Scoreboard, bool spiller2Bonus)
        {
            int sum1, sum2, sum3, sum4, sum5, sum6;

            sum1 = SumOfNumberOfEyes(1, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum2 = SumOfNumberOfEyes(2, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum3 = SumOfNumberOfEyes(3, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum4 = SumOfNumberOfEyes(4, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum5 = SumOfNumberOfEyes(5, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
            sum6 = SumOfNumberOfEyes(6, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);



            /*
            Console.WriteLine("Tryk Enter for at fortsætte.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(spiller2Navn);  //Sæt til variable
            Console.WriteLine(" | a 1ere | b 2ere | c 3ere | d 4ere | e 5ere | f 6ere | g 1par | h 2par | i-3ens | j-4ens | ");
            Console.WriteLine(" |    {0} |    {1} |    {2} |    {3} |    {4} |    {5} |    {6} |    {7} |    {8} |    {9} | ",
            spiller2Scoreboard[0], spiller2Scoreboard[1], spiller2Scoreboard[2], spiller2Scoreboard[3], spiller2Scoreboard[4],
            spiller2Scoreboard[5], spiller2Scoreboard[6], spiller2Scoreboard[7], spiller2Scoreboard[8], spiller2Scoreboard[9]);
            Console.WriteLine(" | k lille straight | l store straight | m chancen | n yatzy | - | total 1-6 | total | ");
            Console.WriteLine(" | (14)         {0} | (20)         {1} |       {2} | (50){3} | - | (50)  {4} |   {5} | ",
            spiller2Scoreboard[10], spiller2Scoreboard[11], spiller2Scoreboard[12], spiller2Scoreboard[13], spiller2Scoreboard[14]);
            */






            bool[] muligePar = parCheck(sum1, sum2, sum3, sum4, sum5, sum6);
            char allocationSelected = '0';
            bool scoreboardAktiv = true;
            while (scoreboardAktiv == true)
            {
                Console.Clear();

                VisScoreboard(spiller2Navn, spiller2Scoreboard);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Terning {0}: {1}", (i + 1), terningerVærdi[i]);
                }
                Console.Write("Vælg et punkt: ");
                allocationSelected = Console.ReadKey(false).KeyChar;
                if (allocationSelected >= 97 && allocationSelected <= 110)
                {
                    scoreboardAktiv = false;
                    switch (allocationSelected)
                    {
                        case 'a' when spiller2Scoreboard[0] == -1:
                            spiller2Scoreboard[0] = sum1;
                            Console.WriteLine("Du valgte 1ere: {0} ", spiller2Scoreboard[0]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[0];
                            spiller2Scoreboard[14] += spiller2Scoreboard[0];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'b' when spiller2Scoreboard[1] == -1:
                            spiller2Scoreboard[1] = sum2 * 2;
                            Console.WriteLine("Du valgte 2ere: {0} ", spiller2Scoreboard[1]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[1];
                            spiller2Scoreboard[14] += spiller2Scoreboard[1];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'c' when spiller2Scoreboard[2] == -1:
                            spiller2Scoreboard[2] = sum3 * 3;
                            Console.WriteLine("Du valgte 3ere: {0} ", spiller2Scoreboard[2]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[2];
                            spiller2Scoreboard[14] += spiller2Scoreboard[2];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'd' when spiller2Scoreboard[3] == -1:
                            spiller2Scoreboard[3] = sum4 * 4;
                            Console.WriteLine("Du valgte 4ere: {0} ", spiller2Scoreboard[3]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[3];
                            spiller2Scoreboard[14] += spiller2Scoreboard[3];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'e' when spiller2Scoreboard[4] == -1:
                            spiller2Scoreboard[4] = sum5 * 5;
                            Console.WriteLine("Du valgte 5ere: {0} ", spiller2Scoreboard[4]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[4];
                            spiller2Scoreboard[14] += spiller2Scoreboard[4];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'f' when spiller2Scoreboard[5] == -1:
                            spiller2Scoreboard[5] = sum6 * 6;
                            Console.WriteLine("Du valgte 6ere: {0} ", spiller2Scoreboard[5]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[5];
                            spiller2Scoreboard[14] += spiller2Scoreboard[5];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'g' when spiller2Scoreboard[6] == -1:
                            SumOf1Pair(6, spiller2Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte 1par: {0} ", spiller2Scoreboard[6]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[6];
                            spiller2Scoreboard[14] += spiller2Scoreboard[6];
                            if (spiller2Scoreboard[14] >= 63 && spiller2Bonus!) spiller2Scoreboard[15] += 50;
                            break;
                        case 'h' when spiller2Scoreboard[7] == -1:

                            int antalMuligePar = 0;
                            spiller2Scoreboard[7] = 0;

                            for (int i = 0; i < 6; i++)
                            {


                                if (muligePar[i])
                                {
                                    antalMuligePar += 1;

                                    spiller2Scoreboard[7] += (i + 1) * 2;

                                }

                            }


                            if (antalMuligePar < 2)
                            {
                                spiller2Scoreboard[7] = 0;
                                Console.WriteLine("Ingen mulige par");
                            }



                            Console.WriteLine("Du valgte 2par: {0} ", spiller2Scoreboard[7]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[7];
                            break;

                        case 'i' when spiller2Scoreboard[8] == -1:
                            if (sum1 >= 3) spiller2Scoreboard[8] = 3;
                            else if (sum2 >= 3) spiller2Scoreboard[8] = 6;
                            else if (sum3 >= 3) spiller2Scoreboard[8] = 9;
                            else if (sum4 >= 3) spiller2Scoreboard[8] = 12;
                            else if (sum5 >= 3) spiller2Scoreboard[8] = 14;
                            else if (sum6 >= 3) spiller2Scoreboard[8] = 18;
                            else spiller2Scoreboard[8] = 0;

                            Console.WriteLine("Du valgte 3 ens: {0}", spiller2Scoreboard[8]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[8];
                            break;

                        case 'j' when spiller2Scoreboard[9] == -1:
                            if (sum1 >= 4) spiller2Scoreboard[9] = 4;
                            else if (sum2 >= 4) spiller2Scoreboard[9] = 8;
                            else if (sum3 >= 4) spiller2Scoreboard[9] = 12;
                            else if (sum4 >= 4) spiller2Scoreboard[9] = 15;
                            else if (sum5 >= 4) spiller2Scoreboard[9] = 20;
                            else if (sum6 >= 4) spiller2Scoreboard[9] = 24;
                            else spiller2Scoreboard[9] = 0;

                            Console.WriteLine("Du valgte 4 ens: {0}", spiller2Scoreboard[9]);
                            spiller2Scoreboard[15] += spiller2Scoreboard[9];
                            break;

                        case 'k' when spiller2Scoreboard[10] == -1:


                            if (terningerVærdi.Contains(1) && terningerVærdi.Contains(2) && terningerVærdi.Contains(3)
                               && terningerVærdi.Contains(4) && terningerVærdi.Contains(5))
                            {
                                spiller2Scoreboard[10] = 15;
                                Console.WriteLine("Du valgte lille straight: {0}", spiller2Scoreboard[10]);
                                spiller2Scoreboard[15] += spiller2Scoreboard[10] + 15;
                            }
                            else
                            {
                                spiller2Scoreboard[10] = 0;
                                Console.WriteLine("Du har ikke et lille straight");
                            }
                            break;

                        case 'l' when spiller2Scoreboard[11] == -1:
                            if (terningerVærdi.Contains(2) && terningerVærdi.Contains(3) && terningerVærdi.Contains(4)
                                  && terningerVærdi.Contains(5) && terningerVærdi.Contains(6))
                            {
                                spiller2Scoreboard[11] = 20;
                                Console.WriteLine("Du valgte store straight: {0} ", spiller2Scoreboard[11]);
                                spiller2Scoreboard[15] += spiller2Scoreboard[11] + 20;
                            }
                            else
                            {
                                spiller2Scoreboard[11] = 0;
                                Console.WriteLine("Du har ikke et stort straight");
                            }
                            break;

                        case 'm' when spiller2Scoreboard[12] == -1:
                            spiller2Scoreboard[12] = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                spiller2Scoreboard[12] += terningerVærdi[i];
                            }
                            spiller2Scoreboard[15] += spiller2Scoreboard[12];
                            Console.WriteLine("Du valgte chancen: {0} ", spiller2Scoreboard[12]);

                            break;

                        case 'n' when spiller2Scoreboard[13] == -1:
                            spiller2Scoreboard[13] = 0;
                            if (terningerVærdi[0] == terningerVærdi[1] && terningerVærdi[1] == terningerVærdi[2]
                            && terningerVærdi[2] == terningerVærdi[3] && terningerVærdi[3] == terningerVærdi[4])
                            {
                                spiller2Scoreboard[13] = terningerVærdi[0] * 5;
                                spiller2Scoreboard[15] += spiller2Scoreboard[13] + 50;
                                Console.WriteLine("Du valgte yatzy: {0} (bonus {1})", spiller2Scoreboard[13], 50);

                            }
                            else
                            {
                                Console.WriteLine("Du har ikke yatzy");
                            }

                            break;

                        default:
                            scoreboardAktiv = true;
                            Console.WriteLine("Indtast et andet punkt");
                            Console.WriteLine("Tryk Enter for at fortsætte.");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input ubrugeligt");
                    Console.WriteLine("Tryk Enter for at fortsætte.");
                    Console.ReadLine();
                }
            }

            return spiller2Scoreboard;
        }

    }

}

