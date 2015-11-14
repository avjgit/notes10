using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20151017
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemA();
            //ProblemI();
        }

        private static void ProblemA()
        {
            var addressCount = int.Parse(Console.ReadLine());

            var addresses = new Dictionary<string, List<string>>();

            for (int i = 0; i < addressCount; i++)
            {
                var email = Console.ReadLine();
                var canonicalEmail = GetCanonicalEmail(email);
                
                if (addresses.ContainsKey(canonicalEmail))
                    addresses[canonicalEmail].Add(email);
                else
                    addresses.Add(canonicalEmail, new List<string> { email });
            }

            Console.WriteLine(addresses.Count());

            foreach (var a in addresses)
            {
                Console.Write(a.Value.Count);
                Console.Write(' ');

                foreach (var item in a.Value)
                {
                    Console.Write(item + ' ');
                }
                Console.WriteLine();
            }
        }

        private static string GetCanonicalEmail(string email)
        {
            var splitted = email.Split('@');
            var login = splitted.First().ToUpper();
            var domain = splitted.Last().ToUpper();
            if (domain == "BMAIL.COM") {
                login = login.Replace(".", "");
                var plusIndex = login.IndexOf('+');
                if (plusIndex > 0)
                    login = login.Remove(plusIndex);
            }
               return login + '@' + domain;
        }

        private static void ProblemI()
        {
            var ballsNrAndParticipans = Console.ReadLine().Split();
            int ballsNr = int.Parse(ballsNrAndParticipans.First());
            int participants = int.Parse(ballsNrAndParticipans.Last());
            int ballsPerParticipant = ballsNr / participants;

            var balls = Console.ReadLine().Split().Select(int.Parse).ToList().GroupBy(x => x);
            var ballsCounted = new Dictionary<int, int>();
            foreach (var group in balls)
            {
                ballsCounted.Add(group.Key, group.Count());
            }
            
            Console.WriteLine(ballsCounted.Where(x => x.Value > ballsPerParticipant).Select(x => x.Value - ballsPerParticipant).Sum());
        }
    }
}
