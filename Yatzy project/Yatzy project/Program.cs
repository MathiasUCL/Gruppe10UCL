using System.Security.Cryptography.X509Certificates;

namespace Yatzy_project
{

    internal class Program
    {

        static void Main(string[] args)
        {

            int[] terninger = terningKast();
            bool kasterTerninger = true;
            int tilbageVærendeTerninger = 5;
            int kastNummer = 0;
            while(kasterTerninger == true)
            {

                kastNummer++;
                if(kastNummer == 3 || tilbageVærendeTerninger == 0) kasterTerninger = false;
            }



            for(int i = 0; i < tilbageVærendeTerninger; i++) 
            {
                Console.WriteLine(terninger[i]);
            }



            //Array1 længde varierer afhænging af terninger taget fra/tilgængelige?
                //Eller kun lav udtræk af nødvendigt antal?
                //terningekast kunne køre enkelte terningekast, som blev lageret i et seperat array
            //Array2 til gemte terninger?
            //Lagering i Array2 afhænger af bruger input 1-5 for at lave udtræk fra Array1






        }
        private static int[] terningKast()
        {
            Random r = new Random();
            
            int[] terninger = new int[5] { r.Next(1, 7), r.Next(1, 7), r.Next(1, 7), r.Next(1, 7), r.Next(1, 7) };
            return terninger;


        }

        /*private static int[] terningKast(int)
        {
            Random r = new Random(1,7);
            int[] terninger = new int[terningKast];
            for(int i = 0; i < terningKast; i++)
        {
        terninger[i] = r;*/
       
            
        }
            


        
    }
}
