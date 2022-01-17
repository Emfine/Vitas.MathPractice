using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vitas.FirstGrade.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new MathHelper();
            DateTime now = DateTime.Now;
            int row = 100;
            int num = 3;
            int column = 4;
            using (var sw = new StreamWriter($"{now.ToString("yyyy-MM-dd")}.txt"))
            {
                Console.SetOut(sw);

                for (int ridx = 0; ridx < row / column; ridx++)
                {
                    for (int cidx = 0; cidx < column; cidx++)
                    {
                        var cell = new StringBuilder();
                        string sort = $"{cidx * row / column + ridx + 1}. ";
                        cell.Append(sort.PadLeft(5));
                        var expression = helper.TwoDigitMix(num);
                        cell.Append(expression);
                        Console.Write(cell.ToString().PadRight(cell.Length + 6));
                    }
                    Console.WriteLine();
                }

                sw.Flush();
            }
            Console.ReadLine();
        }
    }
}