using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class Program
    {
        static void PrintHelp()
        {
            //Print the help message to the user.
            Console.WriteLine("Usage for creating password values.");
            Console.WriteLine("===================================");
            Console.WriteLine("password.exe length [-n numPasswords] [-c]");
            Console.WriteLine("");
            Console.WriteLine("Length is the number of characters. MUST be used first.");
            Console.WriteLine("-? or -h\tDisplay this help documentation.");
            Console.WriteLine("-n\t\tSpecify the number of passwords you want to generate. Default: 1.");
            Console.WriteLine("-c\t\tSpecify that complexity should be used.");
            
        }

        static void Main(string[] args)
        {
            //Define some variables.
            bool isComplex = false;
            bool broken = false;
            int numPasswords = 1;
            int passLen = 0;

            if(args.Length < 1)
            {
                //Means nothing was passed.
                Console.WriteLine("\nFailure! No parameters provided!\n");
                PrintHelp();

            }
            else if(args.Length > 4)
            {
                Console.WriteLine("Too many arguments!");
                PrintHelp();
            }
            else
            {
                //Start parsing the parameters.
                if(args.Contains("-h") || args.Contains("-?"))
                {
                    //Always print help if these are included; ignore everything else.
                    PrintHelp();
                }
                else
                {
                    //First get the password length and validate it.
                    string passLenStr = args[0];
                    bool successfulLenParse = false;
                    successfulLenParse = int.TryParse(passLenStr, out passLen);

                    if (successfulLenParse)
                    {
                        if (args.Contains("-c"))
                        {
                            //The user wants complexity.
                            isComplex = true;
                        }

                        if (args.Contains("-n"))
                        {
                            //The user wants multiple passwords.
                            int countIndex = Array.IndexOf(args, "-n") + 1;
                            if(countIndex < args.Length)
                            {
                                string numPassStr = args[countIndex];

                                //Convert the value.
                                bool successfulNumParse = false;
                                successfulNumParse = int.TryParse(numPassStr, out numPasswords);

                                //Continue on only if we have joy in parsing.
                                if (!successfulNumParse)
                                {
                                    Console.WriteLine("\nCannot have \"{0}\" passwords!\n", passLenStr);
                                    PrintHelp();
                                    broken = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nOut of bounds! Check the order of your parameters.\n");
                                PrintHelp();
                                broken = true;
                                
                            }
                            
                        }

                        //Now actually calculate the password.
                        if(!broken)
                        {
                            if (isComplex)
                            {
                                Console.WriteLine("Calculating {0} complex passwords of length {1}.", numPasswords.ToString(), passLen.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Calculating {0} simple passwords of length {1}.", numPasswords.ToString(), passLen.ToString());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCannot have a password of length: {0}\n", passLenStr);
                        PrintHelp();
                    }
                }

                //Define the range of possible values.
                string[] passChars = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "{", "}", "[", "]", "|", ".", ",", "<", ">", ":", ";" };
            }

        }
    }
}
