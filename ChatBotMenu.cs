using System;
using System.Linq;
using System.Threading;



namespace CyberAiOpenChat
{
    public class ChatBotMenu
    {
        private string name; // Variable to store user name
        private AudioAndImage mediaHandler; // Handles audio and image-related functionalities
        private QuestionAndIgnore questionHandler; // Handles question processing
        private MemoryManager memoryManager; // Handles memory storage and retrieval
        private string userName; // Store validated username
        private bool exit; // Control chatbot exit

        public ChatBotMenu()
        {
            mediaHandler = new AudioAndImage();
            questionHandler = new QuestionAndIgnore();
            memoryManager = new MemoryManager(); // Initialize MemoryManager
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
            Console.Write("\nThe CSB (CyberAiOpenChat) is getting ready to help");
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
            Console.WriteLine("CSB AI: Please enter your full name (letters and spaces only):");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            name = ValidateName(Console.ReadLine());
            userName = name; // Assign validated name to userName
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===================================================================================================");
            Console.WriteLine("CSB AI: Your full name is: " + name);
            Console.WriteLine("===================================================================================================");

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║     CYBERSECURITY AWARENESS CHAT    ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nHello, {userName}! What would you like to do?\n");

                Console.WriteLine("1. Ask a cybersecurity question");
                Console.WriteLine("2. View past conversations");
                Console.WriteLine("3. Exit");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter your choice (1-3): ");
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                switch (choice)
                {
                    case "1":
                        questionHandler.HandleQuestions(userName);
                        break;

                    case "2":
                        DisplayPastConversations();
                        break;

                    case "3":
                        Console.WriteLine("\nThank you for chatting. Stay safe online!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private string ValidateName(string input)
        {
            while (string.IsNullOrWhiteSpace(input) || !input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name. Please use letters and spaces only.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User: ");
                input = Console.ReadLine();
            }
            return input.Trim();
        }

        private void DisplayPastConversations()
        {
            Console.Clear();
            Console.WriteLine("📜 Past Conversations:");

            var history = memoryManager.LoadConversation();

            if (history == null || !history.Any())
            {
                Console.WriteLine("No past conversations found.");
            }
            else
            {
                foreach (var entry in history)
                {
                    Console.WriteLine(entry);
                }
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}