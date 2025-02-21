using System;
using System.Diagnostics;
using System.Threading;

namespace Hendrix
{
    internal class Program
    {
        // The typing effect and colors
        private const int TypewriterDelay = 50;
        private static readonly ConsoleColor HeaderColor = ConsoleColor.DarkMagenta;
        private static readonly ConsoleColor VersionColor = ConsoleColor.DarkRed;
        private static readonly ConsoleColor DefaultColor = ConsoleColor.Gray;

        // The main function that holds the Title the RunMainMenu function
        static void Main(string[] args)
        {
            Console.Title = "Hendrix Security Toolkit";
            Console.CursorVisible = true;
            RunMainMenu();
        }

        // The RunMainMenu function
        static void RunMainMenu()
        {
            while (true)
            {
                Console.Clear();
                ShowBanner();

                TypewriterEffect("Main Menu:", HeaderColor);
                Console.WriteLine("\n1. Surveillance Tools");
                Console.WriteLine("2. SSH Password Cracker");
                Console.WriteLine("3. Exit");

                switch (GetMenuChoice(3))
                {
                    case 1:
                        SurveillanceMenu();
                        break;
                    case 2:
                        PasswordCrackerMenu();
                        break;
                    case 3:
                        TypewriterEffect("Exiting the program...", HeaderColor);
                        Thread.Sleep(1000);
                        return;
                }
            }
        }

        static void SurveillanceMenu()
        {
            while (true)
            {
                Console.Clear();
                ShowBanner();

                TypewriterEffect("Surveillance Tools:", HeaderColor);
                Console.WriteLine("\n1. Network Scanner");
                Console.WriteLine("2. Web Directory Scanner");
                Console.WriteLine("3. Return to Main Menu");

                switch (GetMenuChoice(3))
                {
                    case 1:
                        RunTool("Network Scan", Scanner);
                        break;
                    case 2:
                        RunTool("Web Directory Scan", WebScanner);
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void PasswordCrackerMenu()
        {
            while (true)
            {
                Console.Clear();
                ShowBanner();

                TypewriterEffect("Password Cracker:", HeaderColor);
                Console.WriteLine("\n1. SSH Password Cracker");
                Console.WriteLine("2. Return to Main Menu");

                switch (GetMenuChoice(2))
                {
                    case 1:
                        RunTool("SSH Password Cracker", PasswordCracker);
                        break;
                    case 2:
                        return;
                }
            }
        }

        static void PasswordCracker()
        {
            string username = GetInput("Enter username: ");
            string ip = GetInput("Enter SSH IP: ");
            ExecuteCommand("hydra", $"-l {username} -P /usr/share/wordlists/rockyou.txt {ip} ssh");
        }

        static void Scanner()
        {
            string target = GetInput("Enter IP/URL to scan: ");
            ExecuteCommand("nmap", $"-Pn -vv {target}");
        }

        static void WebScanner()
        {
            string target = GetInput("Enter web server IP/URL: ");
            ExecuteCommand("gobuster", $"dir -u {target} -w /usr/share/SecLists/Discovery/Web-Content/common.txt");
        }

        static void ExecuteCommand(string command, string arguments)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = command,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n" + output);

                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR:\n" + error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError executing command: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
                PromptToContinue();
            }
        }

        static void ShowBanner()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(@"
                ██╗  ██╗███████╗███╗   ██╗██████╗ ██████╗ ██╗██╗  ██╗
                ██║  ██║██╔════╝████╗  ██║██╔══██╗██╔══██╗██║╚██╗██╔╝
                ███████║█████╗  ██╔██╗ ██║██║  ██║██████╔╝██║ ╚███╔╝ 
                ██╔══██║██╔══╝  ██║╚██╗██║██║  ██║██╔══██╗██║ ██╔██╗ 
                ██║  ██║███████╗██║ ╚████║██████╔╝██║  ██║██║██╔╝ ██╗
                ╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝");

            Console.ForegroundColor = VersionColor;
            Console.WriteLine("                                        V1");
            Console.WriteLine("                              *********************");
            Console.WriteLine("                              **Coded by SnipeAE!**");
            Console.WriteLine("                              *********************");
            Console.WriteLine();
            Console.ResetColor();
        }

        static string GetInput(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        static void TypewriterEffect(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(TypewriterDelay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static int GetMenuChoice(int maxOption)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= maxOption)
                    return choice;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input! Please enter a number between 1 and {maxOption}.");
                Console.ResetColor();
            }
        }

        static void RunTool(string toolName, Action toolAction)
        {
            Console.Clear();
            ShowBanner();
            TypewriterEffect($"Starting {toolName}...", ConsoleColor.Cyan);
            toolAction.Invoke();
        }

        static void PromptToContinue()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}