using System;
using System.Diagnostics;
using System.Threading;

namespace Scanner
{
    internal class Program
    {
        // The Scanner function
        static void Scanner()
        {
            Console.Write("What is the ip/url that you want to scan?: ");
            string IP = Console.ReadLine();

            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "nmap",
                    Arguments = $"-Pn -vv {IP}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }

        }

        // The WebScanner function
        static void WebScanner()
        {
            Console.Write("What is the ip/url of the web-server you want to scan?: ");
            string scan = Console.ReadLine();

            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "gobuster",
                    Arguments = $" dir -u {scan} -w /usr/share/SecLists/Discovery/Web-Content/common.txt",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }
        }

        static void encryption()
        {

        }

        // The Main function
        static void Main(string[] args)
        {

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(@"
                ██╗  ██╗███████╗███╗   ██╗██████╗ ██████╗ ██╗██╗  ██╗
                ██║  ██║██╔════╝████╗  ██║██╔══██╗██╔══██╗██║╚██╗██╔╝
                ███████║█████╗  ██╔██╗ ██║██║  ██║██████╔╝██║ ╚███╔╝ 
                ██╔══██║██╔══╝  ██║╚██╗██║██║  ██║██╔══██╗██║ ██╔██╗ 
                ██║  ██║███████╗██║ ╚████║██████╔╝██║  ██║██║██╔╝ ██╗
                ╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝  
                ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                        V1");
                Console.WriteLine("                              *********************");
                Console.WriteLine("                              **Coded by SnipeAE!**");
                Console.WriteLine("                              *********************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                TypewriterEffect("\nWelcome to Hendrix");
                TypewriterEffect("1. Scanner");
                TypewriterEffect("2. Web-Scanner");
                TypewriterEffect("3. Exit");
                Console.Write(": ");

                if (int.TryParse(Console.ReadLine(), out int menu))
                {
                    switch (menu)
                    {
                        case 1:
                            Scanner();
                            TypewriterEffect("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            WebScanner();
                            TypewriterEffect("\nPress any key to return to the main menu...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            TypewriterEffect("Exiting the program......");
                            Thread.Sleep(1000);
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option! Please enter 1 or 2.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
        // The function to make the text type out in the console
        static void TypewriterEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(100); 
            }
            Console.WriteLine();
        }
    }
}
