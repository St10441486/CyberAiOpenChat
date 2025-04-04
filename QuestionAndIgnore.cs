using System;
using System.Collections.Generic;

namespace CyberAiOpenChat
{
    public class QuestionAndIgnore
    {
        private List<string> replies;
        private List<string> ignore;

        public QuestionAndIgnore()
        {
            StoreIgnore();
            StoreReplies();
        }

        private void StoreReplies()
        {
            replies = new List<string>
            {
                "Here's what I found about 'password' -> Always use strong passwords with a mix of letters, numbers, and symbols.",
                "Here's what I found about 'phishing' -> Be cautious of emails or messages asking for personal details; verify the sender.",
                "Here's what I found about 'malware' -> Avoid downloading files from unknown sources to prevent malware infections.",
                "Here's what I found about 'firewall' -> Firewalls help block unauthorized access to your network.",
                "Here's what I found about a 'vpn' -> A VPN encrypts your internet traffic, keeping your online activity private.",
                "Here's what I found about 'encryption' -> Encryption helps protect your sensitive data from unauthorized access.",
                "Here's what I found about a '2fa' -> Two-Factor Authentication adds an extra layer of security to your accounts.",
                "Here's what I found about 'ransomware' -> Never open suspicious attachments, and always back up your important files.",
                "Here's what I found about 'antivirus' -> Keep your antivirus software updated to protect against threats.",
                "Here's what I found about 'social engineering' -> Cybercriminals use manipulation to steal confidential information, stay alert.",
                "Here's what I found about 'cybersecurity' -> Cybersecurity is the practice of protecting systems and data from digital attacks.",
                "Here's what I found about 'hacking' -> Ethical hackers help organizations secure their systems, but illegal hacking is a crime."
            };
        }

        private void StoreIgnore()
        {
            ignore = new List<string>
            {
                "is", "the", "a", "an", "what", "how", "there", "why", "when", "where", "does", "do",
                "are", "can", "could", "should", "would", "i", "me", "my", "you", "your", "we", "our"
            };
        }

        public void HandleQuestions(string userName)
        {
            while (true)
            {
                Console.WriteLine("CSB AI: Enter your question (or 'exit' to go back to the main menu):");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + " -> ");

                string question = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (question?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! " + userName);
                    return;
                }

                string[] words = question.Split(' ');
                List<string> filteredWords = new List<string>();

                foreach (string word in words)
                {
                    if (!ignore.Contains(word.ToLower()))
                    {
                        filteredWords.Add(word.ToLower());
                    }
                }

                string message = "";
                bool found = false;

                foreach (string reply in replies)
                {
                    foreach (string word in filteredWords)
                    {
                        if (reply.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            message += reply + "\n";
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    Console.WriteLine("Chat AI -> " + message.Trim());
                }
                else
                {
                    Console.WriteLine("Chat AI -> I couldn't find an answer. Try rephrasing your question.");
                }
            }
        }
    }
}
