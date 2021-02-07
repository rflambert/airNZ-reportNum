using System;
using System.IO;

namespace airNZ_reportNum
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.Write("Next report should be ");
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(new ReportNumber(Directory.GetCurrentDirectory()));
                Console.ForegroundColor = defaultColor;
                Console.WriteLine("!");
            } catch (System.Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
