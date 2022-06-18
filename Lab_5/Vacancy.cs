using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Vacancy
    {
        public Vacancy() { }

        public Vacancy(string organization, string position, string qualification, double experience, decimal salary, bool insurance, int vacation)
        {
            Organization = organization;
            Position = position;
            Qualification = qualification;
            Experience = experience;
            Salary = salary;
            Insurance = insurance;
            Vacation = vacation;
        }

        public string Organization { get;  set; }
        public string Position { get; set; }
        public string Qualification { get; set; } 
        
        public double Experience { get;  set; }
        public decimal Salary { get;  set; }
        public bool Insurance { get;  set; }
        public int Vacation { get;  set; }


    }
}
