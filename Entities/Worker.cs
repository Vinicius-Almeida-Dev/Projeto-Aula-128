using Projeto_Aula_128.Entities.Enums;
using System.Collections.Generic;

namespace Projeto_Aula_128.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Composicao de objetos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract obj in Contracts)
            {
                if (obj.Date.Month == month && obj.Date.Year == year)
                {
                    sum += obj.TotalHours();
                }
            }
            return sum;
        }
    }
}
