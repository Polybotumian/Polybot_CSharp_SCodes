using System;

namespace konsolDeneme
{
    class Program
    {
        static void Main()
        {   //Our first input            
            string str0 = Console.ReadLine();
            //Our second input for compare to first input to check if they are same or not
            string str1 = Console.ReadLine();
            //This is our char counter
            int i = 0;

            //These two are trims our inputs if there are unnecessary white spaces (doesn't trim if there is a white space between words)
            str0 = str0.Trim();
            str1 = str1.Trim();

            //This one is the solution for recursive return problem. It will feed back about our inputs with some kind of a string pseudo code
            string fin = null;

            //Calling for recursive method
            fin = compareTo(str0, str1, i, fin);

            if (fin.Contains("False"))
            {
                Console.WriteLine("\n" + str0 + " and " + str1 + " are not same!");
            }
            else
            {
                Console.WriteLine("\n" + str0 + " and " + str1 + " are same!");
            }
            //You can see pseudo code with this
            Console.WriteLine("\n" + fin);
        }

        //Our recursive method
        public static string compareTo(string str0, string str1, int i, string fin)
        {
            //Checks if the inputs are have different length already
            if (str0.Length != str1.Length)
            {
                //Inputs are not same so it adds "False" string to fin variable
                fin += "False";
                return fin;
            }
            //Starts to count chars in first input
            else if (i < str0.Length)
            {
                if (str0[i] == str1[i])
                {
                    i++;
                    //Recursive method calls itself at here!
                    fin = compareTo(str0, str1, i, fin);
                }
                else if (str0[i] != str1[i])
                {
                    //Inputs are not same so it adds "False" string to fin variable
                    fin += "False";
                    return fin;
                }
            }
            //End of recursive method
            return fin;
        }

    }

}
