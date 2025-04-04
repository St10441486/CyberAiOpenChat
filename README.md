
============================================================
                 CyberAiOpenChat - README
============================================================

PROJECT NAME: CyberAiOpenChat
AUTHOR: [Your Name Here]
VERSION: 1.0
DESCRIPTION:
------------
CyberAiOpenChat is a simple AI-driven console chatbot designed
to educate users about cybersecurity concepts. It includes a 
friendly interface with audio and ASCII image display, and 
provides helpful answers to basic cybersecurity questions.

FEATURES:
---------
- Interactive chatbot experience.
- Welcome audio playback.
- ASCII art logo from an image.
- Custom greeting with validated user name.
- Responds to cybersecurity-related questions.
- Filters out common filler words to identify keywords.
- Exit or return to main menu at any time.

FILES INCLUDED:
---------------
1. Program.cs               --> Entry point for the chatbot.
2. ChatBotMenu.cs          --> Manages the chatbot menu and flow.
3. AudioAndImage.cs        --> Handles image-to-ASCII display and audio playback.
4. QuestionAndIgnore.cs    --> Stores replies and processes user questions.
5. Ai.jpg                  --> Logo image displayed as ASCII art.
6. greeting.wav            --> Welcome audio played at startup.

REQUIREMENTS:
-------------
- .NET Framework (or .NET Core)
- Console application environment
- Ensure `Ai.jpg` and `greeting.wav` are located in the project root folder
  (NOT inside bin\Debug, but the actual root directory).

HOW TO RUN:
-----------
1. Open the project in Visual Studio or your preferred C# IDE.
2. Build the solution to restore dependencies.
3. Run the application.
4. Follow on-screen instructions:
   - Enter your name (letters only).
   - Choose to ask questions or exit.
   - Ask cybersecurity questions like:
     - "What is a firewall?"
     - "Tell me about phishing."
   - Type 'exit' anytime to return to the menu or quit the program.

EXAMPLES OF SUPPORTED KEYWORDS:
-------------------------------
password, phishing, malware, firewall, vpn, encryption,
2fa, ransomware, antivirus, social engineering,
cybersecurity, hacking, backups, spyware, trojan,
patching, network security, identity theft, botnet,
zero-day

TROUBLESHOOTING:
----------------
- If you don't hear audio: Make sure `greeting.wav` is in the correct path.
- If image doesn't display: Ensure `Ai.jpg` is present and a valid image.
- If unexpected errors appear: Check the console for exception details.

LICENSE:
--------
This project is for educational purposes. Feel free to modify and enhance it!

CONTACT:
--------
For questions, reach out to [your_email@example.com].

============================================================
