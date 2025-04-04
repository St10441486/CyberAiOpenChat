using System;
using System.IO;
using System.Media;
using System.Drawing;

namespace CyberAiOpenChat
{
    public class AudioAndImage // Start of AudioAndImage class
    {
        public void PlayWelcomeAudio() // Start of PlayWelcomeAudio method
        {
            string fullLocation = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = fullLocation.Replace("bin\\Debug\\", "");

            try
            {
                string fullPath = Path.Combine(newPath, "greeting.wav");
                using (SoundPlayer play = new SoundPlayer(fullPath))
                {
                    play.PlaySync(); // Play the welcome audio synchronously
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error playing audio: " + error.Message); // Handle exceptions
            }
        } // End of PlayWelcomeAudio method

        public void DisplayLogo() // Start of DisplayLogo method
        {
            string paths = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = paths.Replace("bin\\Debug\\", "");
            string fullPath = Path.Combine(newPath, "Ai.jpg");

            try
            {
                Bitmap logo = new Bitmap(fullPath);
                logo = new Bitmap(logo, new Size(120, 170)); // Resize the logo for display
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int height = 0; height < logo.Height; height++)
                {
                    for (int width = 0; width < logo.Width; width++)
                    {
                        Color pixelColor = logo.GetPixel(width, height);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; // Convert to grayscale
                        char asciiChar = gray > 250 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                        Console.Write(asciiChar); // Display ASCII representation of the image
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error displaying image: " + error.Message); // Handle exceptions
            }
        } // End of DisplayLogo method
    } // End of AudioAndImage class
}
