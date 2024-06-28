
namespace gspiTask
{
    public class Program
    {
        public static void Main()
        {
            var num = GetNum(new[] { 3, 4, 5, 6, 6, 7, 8, 9 }, 9, 3);

            var q = Convert.ToChar(1040);

            var peopleMap = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>
                {
                    ["Имя"] = "Андрей",
                    ["Фамилия"] = "Чипичапыч",
                    ["Отдел"] = "Продаж",
                    ["Зарплата"] = "60000"
                },
                new Dictionary<string, string>
                {
                    ["Имя"] = "Карим",
                    ["Фамилия"] = "Ли",
                    ["Отдел"] = "Разработки",
                    ["Зарплата"] = "100000"
                },
                new Dictionary<string, string>
                {
                    ["Имя"] = "Антон",
                    ["Фамилия"] = "Уик",
                    ["Отдел"] = "Разработки",
                    ["Зарплата"] = "120000"
                }
            };

            var peopleList = GetPeopleList(peopleMap);

            var data = GetData(new List<Person>()
            {
                new Person()
                {
                    Name = "Андрей",
                    Surname = "Чипичапыч",
                    Department = "Продаж",
                    Salary = "60000"
                },
                new Person()
                {
                    Name = "Карим",
                    Surname = "Ли",
                    Department = "Разработки",
                    Salary = "100000"
                },
                new Person()
                {
                    Name = "Антон",
                    Surname = "Уик",
                    Department = "Разработки",
                    Salary = "120000"
                }
            });

            var test = IsSimilarSurname("Тузин", "Кузина");
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
                MostFrequentLetter = string.Concat(list.Select(p => p.Name)).GroupBy(c => c).OrderByDescending(g => g.Count()).First().First().ToString(),
                PopularDepartment = list.Select(p => p.Department).GroupBy(d => d).OrderByDescending(d => d.Count()).First().First(),
                SimilarSurname = list.Where(p => IsSimilarSurname(p.Name, "Кузин"))?.First().Name ?? "null"
            };
        }

        //3
        public static int GetNum(int[] nums, int max, int min)
        {
            return nums.GroupBy(n => n).OrderByDescending(n => n.Count()).First().First();
        }

        private static bool IsSimilarSurname(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            if (s1.Contains(s2) || s2.Contains(s1))
                return true;

            var s1variants = new List<string>();
            var s2variants = new List<string>();
            foreach (var c in Enumerable.Range(1072, 1103).Concat(Enumerable.Range(224, 239)))
            {
                for (int i = 0; i < s1.Length - 1; i++)
                {
                    s1variants.Add(s1.Substring(0, i) + Convert.ToChar(i) + s1.Substring(i + 1, s1.Length - i - 1));
                }
                for (int i = 0; i < s2.Length - 1; i++)
                {
                    s2variants.Add(s2.Substring(0, i) + (char)i + s2.Substring(i+1, s2.Length - i - 1));
                }
            }

            if (s1variants.Where(v => v.Contains(s2) || s2.Contains(v)).Any())
                return true;

            if (s2variants.Where(v => v.Contains(s1) || s1.Contains(v)).Any())
                return true;

            return false;
        }
    }
}



