using System;
using System.Collections;
using System.Collections.Generic;

namespace CyberAiOpenChat
{
    public class QuestionAndIgnore // Start of QuestionAndIgnore class
    {
        private ArrayList replies;
        private ArrayList ignore;

        public QuestionAndIgnore() // Start of constructor
        {
            replies = new ArrayList();
            ignore = new ArrayList();
            StoreIgnore();
            StoreReplies();
        } // End of constructor

        private void StoreReplies() // Start of StoreReplies method
        {
            replies.Add("Here's what I found about 'password' -> Always use strong passwords with a mix of letters, numbers, and symbols.");
            replies.Add("Here's what I found about 'phishing' -> Be cautious of emails or messages asking for personal details; verify the sender.");
            replies.Add("Here's what I found about 'malware' -> Avoid downloading files from unknown sources to prevent malware infections.");
            replies.Add("Here's what I found about 'firewall' -> Firewalls help block unauthorized access to your network.");
            replies.Add("Here's what I found about 'vpn' -> A VPN encrypts your internet traffic, keeping your online activity private.");
            replies.Add("Here's what I found about 'encryption' -> Encryption helps protect your sensitive data from unauthorized access.");
            replies.Add("Here's what I found about '2fa' -> Two-Factor Authentication adds an extra layer of security to your accounts.");
            replies.Add("Here's what I found about 'ransomware' -> Never open suspicious attachments, and always back up your important files.");
            replies.Add("Here's what I found about 'antivirus' -> Keep your antivirus software updated to protect against threats.");
            replies.Add("Here's what I found about 'social engineering' -> Cybercriminals use manipulation to steal confidential information, stay alert.");
            replies.Add("Here's what I found about 'cybersecurity' -> Cybersecurity is the practice of protecting systems and data from digital attacks.");
            replies.Add("Here's what I found about 'hacking' -> Ethical hackers help organizations secure their systems, but illegal hacking is a crime.");
            replies.Add("Here's what I found about 'backups' -> Regularly backup your data to a secure location to prevent data loss.");
            replies.Add("Here's what I found about 'spyware' -> Spyware secretly collects user information, often without consent.");
            replies.Add("Here's what I found about 'trojan' -> A Trojan horse is malware disguised as legitimate software.");
            replies.Add("Here's what I found about 'patching' -> Regular software updates fix security vulnerabilities and bugs.");
            replies.Add("Here's what I found about 'network security' -> Protecting networks involves firewalls, secure configurations, and monitoring.");
            replies.Add("Here's what I found about 'identity theft' -> Always safeguard your personal info to avoid being impersonated.");
            replies.Add("Here's what I found about 'botnet' -> A botnet is a group of infected devices used to perform coordinated cyberattacks.");
            replies.Add("Here's what I found about 'zero-day' -> A zero-day exploit takes advantage of a security flaw before it's patched.");
        } // End of StoreReplies method

        private void StoreIgnore() // Start of StoreIgnore method
        {
            string[] words = {
                "is", "the", "a", "an", "what", "how", "there", "why", "when", "where", "does", "do",
                "are", "can", "could", "should", "would", "i", "me", "my", "you", "your", "we", "our",
                "in", "on", "of", "to", "with", "about", "for", "tell", "explain", "give", "show",
                "say", "and", "or", "if", "at", "from", "that", "this", "those", "these", "any", "be",
                "by", "as", "it", "its"
            };

            foreach (string word in words)
            {
                ignore.Add(word);
            }
        } // End of StoreIgnore method

        public void HandleQuestions(string userName) // Start of HandleQuestions method
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CSB AI: Enter your question(s) (or type 'exit' to return to main menu):");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + " -> ");
                string question = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (question?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! " + userName);
                    return;
                }

                string[] words = question.Split(new char[] { ' ', '.', '?', ',', ';', ':', '!', '-' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> filteredWords = new HashSet<string>();

                foreach (string word in words)
                {
                    string lowerWord = word.ToLower();
                    if (!ignore.Contains(lowerWord))
                    {
                        filteredWords.Add(lowerWord);
                    }
                }

                string message = "";
                HashSet<string> matchedReplies = new HashSet<string>();

                foreach (string word in filteredWords)
                {
                    foreach (string replyObj in replies)
                    {
                        string reply = replyObj.ToString();
                        if (reply.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0 && !matchedReplies.Contains(reply))
                        {
                            matchedReplies.Add(reply);
                            Console.ForegroundColor = ConsoleColor.Green;
                            message += reply + "\n";
                        }
                    }
                }

                if (matchedReplies.Count > 0)
                {
                    Console.WriteLine("Chat AI -> \n" + message.Trim());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chat AI -> I couldn't find an answer. Try rephrasing your question.");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        } // End of HandleQuestions method
    } // End of QuestionAndIgnore class
}