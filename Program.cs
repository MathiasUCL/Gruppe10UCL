using System.Security.Cryptography.X509Certificates;

namespace Yatzy_project
{

    internal class Program
    {
        //Alle spillerer har deres eget scoreboard i toppen af deres skærm under deres runde
        //Alle spillerer kører runde X igennem, fuld scoreboard for alle spillerer vises før runde X+1


        static void Main(string[] args)
        {
            bool gameProgress = true;
            //int playerAmount = Int.Parse(Console.ReadLine());
            //string[] playerName = new string[playerAmount];
            string spiller1Navn = "Spiller 1";
            while(gameProgress)
            {
                int valgtePar;
                int valgtPar2;
                int valgteSum;
                int[] terningerVærdi = new int[5] { 0, 0, 0, 0, 0 };
                bool[] erTerningerLåst = new bool[5] { false, false, false, false, false }; //Skal alle sættes til falsk før vi bruger dem
                bool kasterTerninger = true;
                int tilbageVærendeTerninger = 5;
                int kastNummer = 0;
                int sum1, sum2, sum3, sum4, sum5, sum6;
                int[] spiller1Scoreboard = new int[15];
                //int[] spiller2Scoreboard = new int[15];
                while (kasterTerninger == true)
                {
                    kastNummer++;

                    //Kald metoden med disse værdier
                    KastTerninger(terningerVærdi, erTerningerLåst);
                    LåsTerninger(kastNummer, erTerningerLåst);

                    if (kastNummer == 3 || tilbageVærendeTerninger == 0) kasterTerninger = false;

                }


                kasterTerninger = true; //Bruges for nu, bør have en anden bool til det, eller omnavngive

                //1ere, 2ere, 3ere, 4ere, 5ere, 6ere, 1par, 2par, 3ens, 4ens, hus, lillestraight (+15), storestraight (+20), chancen, yatzy (+50)
                //Score af 63 eller over i 1ere til 6ere giver (+50)

                terningerVærdi = new int[] { 5, 5, 4, 2, 2 };
                Console.WriteLine("ClearCheck");
                while (kasterTerninger)
                {
                    Console.Clear();
                    Console.WriteLine(spiller1Navn);  //Sæt til variable
                    Console.WriteLine("-|-a-1ere-|-b-2ere-|-c-3ere-|-d-4ere-|-e-5ere-|-f-6ere-|-g-1par-|-h-2par-|-i-3ens-|-j-4ens-|-");
                    Console.WriteLine("-|-    00-|-    00-|-    00-|-    00-|-    00-|-    00-|-    00-|-    00-|-    00-|-    00-|-");
                    Console.WriteLine("-|-k-lille straight-|-l-store straight-|-m-chancen-|-n-yatzy-|---|-total-|-");
                    Console.WriteLine("-|-(15)          00-|-(20)          00-|-       00-|-(50) 00-|---|-   00-|-");

                    sum1 = SumOfNumberOfEyes(1, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
                    sum2 = SumOfNumberOfEyes(2, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
                    sum3 = SumOfNumberOfEyes(3, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
                    sum4 = SumOfNumberOfEyes(4, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
                    sum5 = SumOfNumberOfEyes(5, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);
                    sum6 = SumOfNumberOfEyes(6, terningerVærdi[0], terningerVærdi[1], terningerVærdi[2], terningerVærdi[3], terningerVærdi[4]);

                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Terning {0}: {1}", (i + 1), terningerVærdi[i]);
                    }

                    //parCheck(sum1, sum2, sum3, sum4, sum5, sum6);

                    Console.Write("Vælg et punkt");
                    char valgteVærdi = Convert.ToChar(Console.ReadLine());
                    switch (valgteVærdi)
                    {
                        case 'a':
                            spiller1Scoreboard[0] = sum1;
                            Console.WriteLine("Du valgte 1ere: {0} ", spiller1Scoreboard[0]);
                            break;
                        case 'b':
                            spiller1Scoreboard[1] = sum2 * 2;
                            Console.WriteLine("Du valgte 2ere: {0} ", spiller1Scoreboard[1]);
                            break;
                        case 'c':
                            spiller1Scoreboard[2] = sum3 * 3;
                            Console.WriteLine("Du valgte 3ere: {0} ", spiller1Scoreboard[2]);
                            break;
                        case 'd':
                            spiller1Scoreboard[3] = sum4 * 4;
                            Console.WriteLine("Du valgte 4ere: {0} ", spiller1Scoreboard[3]);
                            break;
                        case 'e':
                            spiller1Scoreboard[4] = sum5 * 5;
                            Console.WriteLine("Du valgte 5ere: {0} ", spiller1Scoreboard[4]);
                            break;
                        case 'f':
                            spiller1Scoreboard[5] = sum6 * 6;
                            Console.WriteLine("Du valgte 6ere: {0} ", spiller1Scoreboard[5]);
                            break;
                        /*case 'g':
                            SumOf1Pair(6, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte 1par: {0} ", spiller1Scoreboard[6]);
                            break;
                        case 'h':
                            //valgtePar = Convert.ToInt32(Console.ReadLine());
                            //valgtePar2 = Convert.ToInt32(Console.ReadLine());
                            //spiller1Scoreboard[7] = ;
                            SumOf2Pair(7, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte 2par: {0} ", spiller1Scoreboard[7]);
                            break;*/
                        /*case 'i':
                            SumOf(8, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte : {0} ", spiller1Scoreboard[8]);
                            break;
                        case 'j':
                            SumOf(9, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte : {0} ", spiller1Scoreboard[9]);
                            break;
                        case 'k':
                            SumOf(10, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte : {0} ", spiller1Scoreboard[10]);
                            break;
                        case 'l':
                            SumOf(11, spiller1Scoreboard, sum1, sum2, sum3, sum4, sum5, sum6);
                            Console.WriteLine("Du valgte : {0} ", spiller1Scoreboard[11]);
                            break;*/





                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(terningerVærdi[i]);
                }



                Console.Write("Spillet er slut");
                gameProgress = false;



            }
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

        static void SumOf2Pair(int i, int[] spiller1Scoreboard, int sum1, int sum2, int sum3, int sum4, int sum5, int sum6)
        {
            if (sum6 > 1)
            {
                if (sum5 > 1)
                {
                    spiller1Scoreboard[i] = 6 * 2 + 5 * 2;
                }
                else if (sum4 > 1)
                {
                    spiller1Scoreboard[i] = 6 * 2 + (4 * 2);
                }
                else if (sum3 > 1)
                {
                    spiller1Scoreboard[i] = 6 * 2 + (3 * 2);
                }
                else if (sum2 > 1)
                {
                    spiller1Scoreboard[i] = 6 * 2 + (2 * 2);
                }
                else if (sum1 > 1)
                {
                    spiller1Scoreboard[i] = 6 * 2 + (1 * 2);
                }
                else
                {
                    spiller1Scoreboard[i] = 0;
                }

            }
            else if (sum5 > 1)
            {
                if (sum4 > 1)
                {
                    spiller1Scoreboard[i] = 5 * 2 + (4 * 2);
                }
                else if (sum3 > 1)
                {
                    spiller1Scoreboard[i] = 5 * 2 + (3 * 2);
                }
                else if (sum2 > 1)
                {
                    spiller1Scoreboard[i] = 5 * 2 + (2 * 2);
                }
                else if (sum1 > 1)
                {
                    spiller1Scoreboard[i] = 5 * 2 + (1 * 2);
                }
                else
                {
                    spiller1Scoreboard[i] = 0;
                }
            }
            else if (sum4 > 1)
            {
                if (sum3 > 1)
                {
                    spiller1Scoreboard[i] = 4 * 2 + (3 * 2);
                }
                else if (sum2 > 1)
                {
                    spiller1Scoreboard[i] = 4 * 2 + (2 * 2);
                }
                else if (sum1 > 1)
                {
                    spiller1Scoreboard[i] = 4 * 2 + (1 * 2);
                }
                else
                {
                    spiller1Scoreboard[i] = 0;
                }
            }
            else if (sum3 > 1)
            {
                if (sum2 > 1)
                {
                    spiller1Scoreboard[i] = 3 * 2 + (2 * 2);
                }
                else if (sum1 > 1)
                {
                    spiller1Scoreboard[i] = 3 * 2 + (1 * 2);
                }
                else
                {
                    spiller1Scoreboard[i] = 0;
                }
            }
            else if (sum2 > 1)
            {
                if (sum1 > 1)
                {
                    spiller1Scoreboard[i] = 2 * 2 + (1 * 2);
                }
                else
                {
                    spiller1Scoreboard[i] = 0;
                }
            }
            else
            {
                spiller1Scoreboard[i] = 0;
            }
        }

        /*static bool[] parCheck(int sum1, int sum2, int sum3, int sum4, int sum5, int sum6)
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
            Console.WriteLine(Convert.ToString(muligePar));
            return muligePar;
            }*/


    }

}

