using System;

namespace testINAMI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //C=M-(N%M)

            Random aleatoire = new Random();
            int inami = aleatoire.Next(1000000);

            //int inami2 = 99999999;

            Console.WriteLine(inami);

            int m = 97;

            int checkDigit1 = 83 - (inami % 83);
            int checkDigit2 = 97 - (inami % 97);
            int checkDigit3 = 89 - (inami % 89);
            int checkDigit4 = 79 - (inami % 79);



            Console.WriteLine($"checkDigit1 mod 83 : {checkDigit1}");
            Console.WriteLine($"checkDigit2 mod 97 : {checkDigit2}");
            Console.WriteLine($"checkDigit3 mod 89 : {checkDigit3}");
            Console.WriteLine($"checkDigit4 mod 79 : {checkDigit3}");

            //code inami : 1(type de médecin) + 1(Province) + 4(num Inscription)+2(checkDigit)+3(qualif médicale)

        }
    }
}
