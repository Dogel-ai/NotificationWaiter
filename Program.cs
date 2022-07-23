//! In order to stop the shutdown countdown you need to use CTRL + C;
using System;
using System.Diagnostics;
using System.Media;

public class Program
{
    public static void Main(string[] args)
    {
        Console.SetWindowSize(34,9);
        Console.Clear();
        // Time in minutes
        infLoop(inputConverter());
        
    }
    
    //*Tries to convert user's input and validates it
    public static int inputConverter() {
        Console.WriteLine("Insert time to wait in minutes");
        bool success = int.TryParse(Console.ReadLine(), out int time);
        if(success) {
            Console.Clear();
            Console.WriteLine($"Time waiting: {time} minute(s)");
            return time;
        } else {
            Console.Clear();
            Console.WriteLine("Input should be a valid integer!\n");
            return inputConverter();
        }
    }

    public static void infLoop(int time) {
        //* Waiting till next shutdown attempt
        System.Threading.Thread.Sleep(time * 60000);

        //* Shutdown initalization
        var psi = new ProcessStartInfo("shutdown","/s /t 0");
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;

        //* Shutdown countdown
        for(int i = 0; i <= 120; i++) {
            SystemSounds.Beep.Play();
            Console.Clear();
            Console.WriteLine("Countdown complete.\nAre you still here?");
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
        Process.Start(psi);
    }
}
