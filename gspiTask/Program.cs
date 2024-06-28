
namespace gspiTask
{
    public class Program
    {
        public static void Main()
        {

        }
        
        //1
        public static List<Person> GetPeopleList(List<Dictionary<string,string>> maps)
        {
            return maps
                .Where(m => m["Имя"].StartsWith('К') && int.Parse(m["Зарплата"]) >= 70000)
                .Select(m => new Person() { Name = m["Имя"], Surname = m["Фамилия"], Department = m["Отдел"], Salary = m["Зарплата"] })
                .ToList();
        }

        //2
        public static DTO GetData(List<Person> list)
        {
            return new DTO()
            {
                AverageSalary = list.Select(p => int.Parse(p.Salary)).Average().ToString(),
                MostFrequentLetter = string.Concat(list.Select(p => p.Name)).GroupBy(c => c).OrderByDescending(g => g.Count()).First().ToString(),
                PopularDepartment = list.Select(p => p.Department).GroupBy(d => d).OrderByDescending(d => d.Count()).First().ToString(),
                SimilarSurname = list.Where(p => IsSimilarName(p.Name)).First().Name
            };
        }

        private static bool IsSimilarName(string name)
        {
            throw new NotImplementedException();
        }
    }
}



