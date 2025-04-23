using System;
using System.Media;
using System.Threading;

namespace PROG6221_ST10442146
{
    class Program
    {
        static void Main(string[] args)
        {
            // Voice Greeting
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync(); // Wait for audio to finish
            }
            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ Unable to play greeting audio: " + ex.Message);
                Console.ResetColor();
            }

            // ASCII Art Header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"

             .--------.
            / .------. \
           / /        \ \
           | |        | |
          _| |________| |_
        .' |_|        |_| '.
        '._____ ____ _____.'     
        |     .'____'.     |
        '.__.'.'    '.'.__.'
        '.__  |      |  __.'
        |   '.'.____.'.'   |
        '.____'.____.'____.'
        Stay Safe. Stay Smart.

");
            Console.ResetColor();

            // Get user's name
            Console.Write("Hello! What's your name? ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter a valid name: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome, {name}! I'm here to help you stay safe online.\n");

            // Main Chat Loop
            bool active = true;
            while (active)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ask me a question or type 'exit' to quit: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintBot("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                switch (input)
                {
                    case "how are you":
                        PrintBot("I'm great thank you! I hope you are too.");
                        break;
                    case "what's your purpose":
                    case "what is your purpose":
                        PrintBot("I educate people about cybersecurity and how to stay safe online.");
                        break;
                    case "what can i ask you about":
                        PrintBot("You can ask me about phishing, password safety, or safe browsing. Just start your question with 'what is' followed by one of the options you wish to know more about.");
                        break;
                    case "what's phishing":
                    case "what is phishing":
                        PrintBot("Phishing is when attackers trick you into giving away personal info through fake emails or websites.");
                        break;
                    case "what's password safety":
                    case "what is password safety":
                        PrintBot("Use long, unique passwords for each account. A password manager can help keep them secure.");
                        break;
                    case "what's safe browsing":
                    case "what is safe browsing":
                        PrintBot("Avoid suspicious links, use HTTPS websites, and keep your software up to date.");
                        break;
                    case "exit":
                        PrintBot($"Goodbye, {name}! Stay safe out there.");
                        active = false;
                        break;
                    default:
                        PrintBot("I didn't quite understand that. Could you rephrase?");
                        break;
                }

                Console.WriteLine();
            }
        }


        static void PrintBot(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Bot: ");
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20); // Typing effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

