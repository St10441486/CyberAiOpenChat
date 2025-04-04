using System;
using System.Threading;

namespace CyberAiOpenChat
{
    public class ChatBotMenu // Start of ChatBotMenu class
    {
        private string name; // Variable to store user name
        private AudioAndImage mediaHandler; // Handles audio and image-related functionalities
        private QuestionAndIgnore questionHandler; // Handles question processing

        public ChatBotMenu() // Start of Constructor
        {
            mediaHandler = new AudioAndImage(); // Initialize AudioAndImage class
            questionHandler = new QuestionAndIgnore(); // Initialize QuestionAndIgnore class
        } // End of Constructor

        public void Run() // Start of Run method
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLoading(); // Call loading animation
            mediaHandler.DisplayLogo(); // Display chatbot logo
            mediaHandler.PlayWelcomeAudio(); // Play welcome audio message
            ChatMenu(); // Navigate to chatbot menu
        } // End of Run method

        private void ShowLoading(int seconds = 3) // Start of ShowLoading method
        {
            Console.Write("\n The CSB (CyberAiOpenChat) is getting ready to help...");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000); // Pause execution for 1 second per dot
            }
            Console.WriteLine();
        } // End of ShowLoading method

        private void DelayText(string text, int delay = 50) // Start of DelayText method
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Delay character output for effect
            }
            Console.WriteLine();
        } // End of DelayText method

        private void ChatMenu() // Start of ChatMenu method
        {
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("CSB AI: Please enter your full name (letters only):");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            name = ValidateName(Console.ReadLine()); // Validate user input name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===================================================================================================");
            Console.WriteLine("CSB AI: Your full name is: " + name);
            Console.WriteLine("===================================================================================================");

            bool run = true;

            while (run) // Loop until user chooses to exit
            {
                DelayText($"\nWelcome {name}! How can I assist you today?", 40);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DelayText("Would you like to ask me questions (yes|no) or type 'exit' to close:", 30);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User: ");
                string reply = Console.ReadLine()?.ToLower(); // Convert input to lowercase
                Console.WriteLine("|===========================================================================================================|");

                switch (reply) // Handle user response
                {
                    case "yes":
                        Console.WriteLine("\n|===========================================================================================================|");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DelayText("You selected yes", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        questionHandler.HandleQuestions(name);
                        break;
                    case "no":
                    case "exit":
                        Console.WriteLine("\n|===========================================================================================================|");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DelayText("Goodbye, see you again soon!", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        run = false; // Exit loop
                        break;
                    default:
                        Console.WriteLine("\n|===========================================================================================================|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        DelayText("Invalid option, please try again.", 30);
                        Console.WriteLine("|===========================================================================================================|");
                        break;
                }
            }
        } // End of ChatMenu method

        private string ValidateName(string input) // Start of ValidateName method
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
        } // End of ValidateName method
    } // End of ChatBotMenu class
}
