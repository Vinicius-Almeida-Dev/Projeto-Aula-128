using Projeto_Aula_128.Entities;
using Projeto_Aula_128.Entities.Enums;
using System;
using System.Globalization;

namespace Projeto_Aula_128
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string Name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");

            WorkerLevel Lvl = (WorkerLevel)Enum.Parse(typeof(WorkerLevel),Console.ReadLine());

            Console.Write("Base salary: ");
            double Salary =  double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department Dept = new Department(deptName);
            Worker worker = new Worker(Name, Lvl, Salary, Dept);

            Console.Write("How many contracts to this worker?");
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double VlueHour  = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int Hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(Date, VlueHour, Hours);
                worker.AddContract(contract);

            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY):");
            string MonthAndYear = Console.ReadLine();
            int Month = int.Parse(MonthAndYear.Substring(0, 2));
            int Year = int.Parse(MonthAndYear.Substring(3, 4));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + MonthAndYear + ": " + worker.Income(Year, Month).ToString("F2", CultureInfo.InvariantCulture));


        }
    }
}
