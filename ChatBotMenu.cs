using System;
using System.Threading;

namespace CyberAiOpenChat
{
    public class ChatBotMenu
    {
        private string name;
        private AudioAndImage mediaHandler;
        private QuestionAndIgnore questionHandler;

        public ChatBotMenu()
        {
            mediaHandler = new AudioAndImage();
            questionHandler = new QuestionAndIgnore();
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLoading();
            mediaHandler.DisplayLogo();
            mediaHandler.PlayWelcomeAudio();
            ChatMenu();
        }

        private void ShowLoading(int seconds = 3)
        {
            Console.Write("\n The CSB (CyberSecurity Bot) is getting ready to help...");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        private void DelayText(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        private void ChatMenu()
        {
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("CSB AI: Please enter your full name (letters only):");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            name = ValidateName(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===================================================================================================");
            Console.WriteLine("CSB AI: Your full name is: " + name);
            Console.WriteLine("===================================================================================================");

            bool run = true;

            while (run)
            {
                DelayText($"\nWelcome {name}! How can I assist you today?", 40);
                DelayText("Would you like to ask me questions (yes|no) or type 'exit' to close:", 30);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User: ");
                string reply = Console.ReadLine()?.ToLower();
                Console.WriteLine("|===========================================================================================================|");

                switch (reply)
                {
                    case "yes":
                        Console.WriteLine("\n|===========================================================================================================|");
                        DelayText("You selected yes", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        questionHandler.HandleQuestions(name);
                        break;
                    case "no":
                    case "exit":
                        Console.WriteLine("\n|===========================================================================================================|");
                        DelayText("Goodbye, see you again soon!", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("\n|===========================================================================================================|");
                        DelayText("Invalid option, please try again.", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        break;
                }
            }
        }

        private string ValidateName(string input)
        {
            while (string.IsNullOrWhiteSpace(input) || !System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z ]+$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name! Please enter a name with letters only.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User: ");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
