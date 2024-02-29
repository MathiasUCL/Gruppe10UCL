using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lommeregner
{
    internal class Calculator
    {
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
        public static double Divide(int num1, int num2)
        {
            return Convert.ToDouble(num1) / Convert.ToDouble(num2);// vi kan regne med double, hvis vi laver dem til double, hvis de er int.
            
        }
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;

        }

 

    }

}
//private inden for sit eget program
//public uden for sit eget program


//Benyt boksen i toppen af side 4 i opgaven!! 

