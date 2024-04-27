using System;
using System.Threading;

namespace Bulong
{
    public static class Bulong
    {
        static (int, string, double)[] lyricsWithCustomDelays = new (int, string, double)[]
        {
            (0, "Ako'y alipin ng pag-ibig mo", 4.1),
            (4, "Handang ibigin ang 'sang tulad mo", 4.5),
            (9, "Hangga't ang puso mo'y sa akin lang", 2),
            (14, "Hindi ka na malilinlang", 1.5),
            (20, "Ikaw ang ilaw sa dilim", 1.5),
            (24, "At ang liwanag ng mga bituin", 5),
        };

        public static void Main()
        {
            PrintLyrics();
        }

        static void PrintLyrics()
        {
            DateTime startTime = DateTime.Now;
            foreach ((int timestamp, string line, double customDelay) in lyricsWithCustomDelays)
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                double currentTime = elapsedTime.TotalSeconds;

                if (currentTime < timestamp)
                {
                    Thread.Sleep((int)((timestamp - currentTime) * 1000));
                }

                foreach (string word in line.Split())
                {
                    foreach (char letter in word)
                    {
                        Console.Write(letter);
                        Thread.Sleep(90);
                    }

                    Console.Write(" ");
                }

                Console.WriteLine();
                Thread.Sleep((int)(customDelay * 1000));
            }
        }
    }
}


