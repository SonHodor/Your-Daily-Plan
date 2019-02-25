using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // Для Thread
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datePr = new DateTime();
            datePr = DateTime.Today;
            Console.Write("Write num of days to randomize: ");
            int k = Convert.ToInt32(Console.ReadLine());
            StreamWriter fileWrite = new StreamWriter("what to do.txt");
            
            Random rnd = new Random();

            while (k >= 0)
            {
                int g = rnd.Next(/*datePr.Day*/);

                if (g % 2 == 1)
                    g = 1;
                else
                    g = 0;

                fileWrite.WriteLine("{0} {1}",datePr, g);
                datePr = datePr.AddDays(1);
                k--;
            }
            fileWrite.Close();

            
            StreamReader fileRead = new StreamReader("what to do.txt");
            DateTime tTime = Convert.ToDateTime(fileRead.ReadLine().Substring(0, 18));

            int week = Convert.ToInt32(tTime.DayOfWeek);

            string todayTask;
            if (fileRead.ReadLine().Substring(19, 1) == "1")
                todayTask = "NET";
            else
                todayTask = "</>";

            fileRead.Close();
            fileRead = new StreamReader("what to do.txt");
            StreamReader fileRead1 = new StreamReader("what to do.txt");
            DateTime thatTime;


            StreamWriter planWriter = new StreamWriter("YourPlan.txt");
            planWriter.WriteLine("|      Mon      |      Tue      |      Wed      |      Thu      |      Fri      |      Sat      |      Sun      |");
            if (week > 1)
                planWriter.Write("|");

            for (int i = 0; i < week-1; i++)
                planWriter.Write("---------------|");

            while (!fileRead1.EndOfStream)
            {
                if (week == 1)
                    planWriter.Write("|");
                if (fileRead.ReadLine().Substring(19, 1) == "1")
                    todayTask = "NET";
                else
                    todayTask = "</>";

                thatTime = Convert.ToDateTime(fileRead1.ReadLine().Substring(0, 18));

                planWriter.Write(" {0}.{1}-{2}\t|", thatTime.Day, thatTime.Month, todayTask);

                if (week == 7)
                {
                    week = 1;
                    planWriter.WriteLine("");
                }
                else
                    week++;
            }
            planWriter.Close();
            Console.ReadKey();
        }
    }
}
