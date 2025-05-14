================================================================================
                          CYBERSECURITY AWARENESS CHATBOT
================================================================================

Project Title: CSB - CyberSecurity Bot (POE Assignment)
Language: C#
Author: [Richard Sebola ST10441486]
Date: [Date]

--------------------------------------------------------------------------------
DESCRIPTION:
--------------------------------------------------------------------------------
The CyberSecurity Bot (CSB) is a console-based AI chatbot designed to promote 
cybersecurity awareness. It interacts with users through typed questions and 
provides helpful cybersecurity advice. The chatbot includes features such as:

- Audio greeting
- ASCII logo display
- Keyword-based response system
- Sentiment detection
- Chat history logging and retrieval
- Name validation
- Randomized dynamic responses
- Input filtering and error handling

--------------------------------------------------------------------------------
PROJECT STRUCTURE:
--------------------------------------------------------------------------------

1. Program.cs
   - Entry point of the application.
   - Instantiates the CyberBot class and runs it.

2. CyberBot.cs
   - Main chatbot controller.
   - Greets the user, validates the name, and shows a menu.
   - Connects all the core components (media handler, memory manager, question handler).

3. AudioImageHandler.cs
   - Plays an audio greeting (Greeting_audio.wav).
   - Displays an ASCII-style logo generated from an image (Image to ASCII.jpg).

4. MemoryManager.cs
   - Handles saving and retrieving chat history.
   - Ensures `chat_history.txt` file exists and is updated.

5. QuestionHandler.cs
   - Manages user input, matches cybersecurity-related keywords.
   - Ignores common stopwords (like "what", "is", etc.).
   - Detects user sentiment (e.g., nervous, scared) and responds accordingly.
   - Provides predefined answers to common cybersecurity topics like phishing, passwords, malware, etc.

--------------------------------------------------------------------------------
HOW TO USE:
--------------------------------------------------------------------------------

1. Run the program.
2. Enter your full name (letters only).
3. Choose from the following options:
   - 'y' to ask a cybersecurity-related question.
   - 'n' to exit the program.
   - 'p' to view the chat history stored in 'chat_history.txt'.

4. While asking questions:
   - Type questions like "What is phishing?" or "How can I protect my password?".
   - Type "exit" to return to the main menu.
   - Sentiment words like "worried" or "anxious" will trigger supportive responses.

--------------------------------------------------------------------------------
FILES NEEDED:
--------------------------------------------------------------------------------

- Greeting_audio.wav        : Audio file played at startup
- Image to ASCII.jpg        : Image used to display an ASCII logo
- chat_history.txt          : Automatically created file that stores past chat logs

--------------------------------------------------------------------------------
FEATURE HIGHLIGHTS:
--------------------------------------------------------------------------------

✔ Keyword Recognition  
✔ Randomized and grouped responses  
✔ Sentiment Detection  
✔ Chat History and Memory Recall  
✔ Audio and Image Media Support  
✔ Robust Input Validation and Error Handling  
✔ Use of Delegates and Collections (List, Dictionary, HashSet)

--------------------------------------------------------------------------------
REQUIREMENTS:
--------------------------------------------------------------------------------

- .NET Framework or .NET Core (for C# Console Apps)
- Image and Audio files placed in the project root directory (not in /bin/Debug)

--------------------------------------------------------------------------------
NOTES:
--------------------------------------------------------------------------------

- Only cybersecurity-related topics are supported.
- The bot ignores generic or unsupported questions.
- The chatbot is designed to educate and support, not provide technical troubleshooting.

--------------------------------------------------------------------------------
