using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace NormalizerInBulk
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting console title
            Console.Title = "Bulk Phone Number Normalizer";

            Console.WriteLine("US Phone Number Normalizer");
            Console.WriteLine("");
            Console.WriteLine("Put your phone numbers in numbers.txt");
            Console.WriteLine("Check example.txt to see the format.");

            for (int i = 2; i > 1; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("[WARNING!] This will delete all your previous normalized phone numbers in normalized.txt");
                Console.Write("Output each normalized phone number into a file? (normalized.txt) [Y/N]: ");

                // Letting the user select whether they want to output phone numbers or not
                string choice2 = Console.ReadLine();

                // Letting the user select whether they want to start normalizing numbers or not
                Console.Write("Start? [Y/N]: ");
                string choice1 = Console.ReadLine();

                if (choice1 == "Y")
                {
                    // User has selected yes, so we are now starting to normalize phone numbers from numbers.txt
                    // Reaading all lines from numbers.txt
                    string[] lines = System.IO.File.ReadAllLines(@"numbers.txt");
                    
                    if (choice2 == "Y")
                    {
                        string delete_command = "/C del normalized.txt";
                        // Deleting old normalized.txt before starting process
                        Process.Start("CMD.exe", delete_command);

                        // Normalizing each phone number with outputting into normalized.txt
                        foreach (string line in lines)
                        {
                            string check = line.Substring(0, 1);

                            if (check != "1")         {
                                // If the first letter in a phone number equals 1, the program will exit
                                Console.WriteLine("Invalid phone number.");
                                Console.WriteLine("Exiting in 2 seconds.");
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }

                            // Extracting certain letters from the phone number
                            string first3 = line.Substring(1, 3);
                            string second3 = line.Substring(4, 3);
                            string second4 = line.Substring(7, 4);

                            string normalized;
                            normalized = "+1 " + "(" + first3 + ")" + " " + second3 + "-" + second4;

                            // Outputting normalized phone number in normalized.txt
                            string output_command;

                            output_command = "/C echo " + normalized + ">> normalized.txt";
                            // Finally outputting phone numbers into the new normalized.txt
                            Process.Start("CMD.exe", output_command);

                            // Printing normalized phone number
                            Console.WriteLine("Normalized phone number: " + normalized);
                            Console.WriteLine("");
                        }
                    }
                    else if (choice2 == "N")
                    {
                        // Normalizing each phone number without outputting any phone number into a file
                        foreach (string line in lines)
                        {
                            string check = line.Substring(0, 1);

                            if (check != "1")
                            {
                                // If the first letter in a phone number equals 1, the program will exit
                                Console.WriteLine("Invalid phone number.");
                                Console.WriteLine("Exiting in 2 seconds.");
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }

                            // Extracting certain letters from the phone number
                            string first3 = line.Substring(1, 3);
                            string second3 = line.Substring(4, 3);
                            string second4 = line.Substring(7, 4);

                            // Setting the normalized phone number as the value of the string named normalized
                            string normalized;
                            normalized = "+1 " + "(" + first3 + ")" + " " + second3 + "-" + second4;

                            // Printing normalized phone number
                            Console.WriteLine("Normalized phone number: " + normalized);
                            Console.WriteLine("");
                        }
                    }
                }                        

                // Exiting if a user doesn't want to start normalizing phone numbers
                else if (choice1 == "N")
                {
                    Console.WriteLine("Exiting in 2 seconds.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }

                // If a user enters something else than "Y" or "N", the program will exit in 2000ms
                else 
                {
                    Console.WriteLine("Exiting in 2 seconds.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
    }
}
