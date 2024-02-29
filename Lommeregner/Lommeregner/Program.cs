namespace Lommeregner
{


    internal class Program
    {


        static void Main(string[] args)
        {
            bool køerneKommerHjem = false;
            while (køerneKommerHjem == false)
            {
                Console.Clear();
                int num3;
                double num4;
                string stop;

                Console.WriteLine("Når du vil stoppe, skriv stop");
                Console.Write("Indtast et nummer: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Indtast et regnetegn: ");
                string symbol = Console.ReadLine();

                Console.Write("Indtast et nummer: ");
                int num2 = int.Parse(Console.ReadLine());



                if (symbol == "+")
                {

                    num3 = Calculator.Add(num1, num2);

                    Console.Write("Dit Resultat er: " + num3);

                }
                else if (symbol == "-")
                {
                    num3 = Calculator.Subtract(num1, num2);

                    Console.WriteLine("Dit Resultat er: " + num3);

                }
                else if (symbol == "/")
                {

                    num4 = Calculator.Divide(num1, num2);

                    Console.WriteLine("Dit Resultat er: " + num4);

                }
                else if (symbol == "*")

                {
                    num3 = Calculator.Multiply(num1, num2);

                    Console.WriteLine("Dit Resultat er: " + num3);

                }
                else
                {
                    Console.WriteLine("Din indtastning er forkert");
                }

                Console.WriteLine("\nReset point");
                stop = Console.ReadLine();

                if (stop == "stop")
                {
                    Console.WriteLine("Tak for denne gang");
                    køerneKommerHjem = true;

                }
                    

            }
        }

    }
}
//
//Udfyld med jeres egne værdier/navne
//ClassNavn.MetodeNavn()        //eksempel!!!

  /*class Car
    {
        public int Speed(int engineRevolutions, int engineGear)
        {
            return (engineRevolutions / 100) * (engineGear ^ 1.08);
        }
        public string model = "Mustang";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myObj = new Car();
            Console.WriteLine(myObj.model);
        }
    }*/
