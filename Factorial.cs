using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Factorial
{
    static void Main()
    {
        //This is a training exercise. 

        //Our task is to create a program that prints out on the console the factorial N! for any N = [1…100]
        //Info: http://en.wikipedia.org/wiki/Factorial - a.k.a N! = 1*2*3*4 ... (N-1)*N


        Console.WriteLine("Please choose N:");
        int n = int.Parse(Console.ReadLine());

        //The factorial grows exponentially  - 13! Is out of Int range, 25! out of Long range 
        //We can use BigInteger but this will slow us down at some point might prove ineffective
        //What I use is numbers represented as strings (which is char[])

        string factorial = CalculateFactorial(n);

        Console.WriteLine("{0}! is {1}", n, factorial);
        //Factorial 100! = 9.3326215444×10^157 as per wiki
    }

    static string CalculateFactorial(int n)
    {
        string finalResult = "1";

        for (int i = 2; i <= n; i++)
        {
            finalResult = Multiply(finalResult, i);
        }

        return finalResult;
    }

    static string Multiply(string numberOne, int numberTwo)
    {
        //We always represent the bigger number as an array of digits
        //this way at any given time we operate with 3 digit output - 9 * N = 9 * 100 max
        List<int> digits = GetDigits(numberOne);

        //To avoid using  Console.Write() too often we optimize by pre-building the string 
        StringBuilder result = new StringBuilder();
        int carry = 0;

        //We multiply digit by digit and mind the carry - just like we would do on paper
        for (int index = 0; index < digits.Count; index++)
        {
            int digitResult = digits[index] * numberTwo;
            digitResult += carry;

            if (digitResult < 10)
            {
                result.Insert(0, digitResult);
                carry = 0;
            }
            else if (digitResult >= 10)
            {
                result.Insert(0, digitResult % 10);
                carry = digitResult / 10;
            }

        }

        if (carry > 0)
        {
            result.Insert(0, carry);
        }

        string endResult = Convert.ToString(result);

        return endResult;
    }

    static List<int> GetDigits(string number)
    {
        List<int> digits = new List<int>();

        for (int i = number.Length - 1; i >= 0; i--)
        {
            digits.Add(int.Parse(Convert.ToString(number[i])));
        }

        return digits;
    }
}

