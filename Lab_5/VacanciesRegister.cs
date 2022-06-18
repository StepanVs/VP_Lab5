using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equin.ApplicationFramework;
namespace Lab_5
{
    internal class VacanciesRegister : IEnumerable<Vacancy>
    {
        public VacanciesRegister() { }
        public VacanciesRegister(IEnumerable<Vacancy> vacancies)
        {
            foreach (var item in vacancies)
            {
                Vacancies.Add(item);
            }
        }
        public List<Vacancy> Vacancies { get;private set; } = new List<Vacancy>();

        public void Add(Vacancy vacancy)
        {
            Vacancies.Add(vacancy);
        }
        public void Remove(Vacancy vacancy)
        {
            Vacancies.Remove(vacancy);
        }
        public IEnumerator<Vacancy> GetEnumerator()
        {
            return Vacancies.GetEnumerator(); ;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)Vacancies).GetEnumerator();
        }
       
    }
}
