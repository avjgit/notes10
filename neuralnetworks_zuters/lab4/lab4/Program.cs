using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public Random Rnd = new Random();

        const string pointsFile = "..\\..\\..\\data\\examples.txt";

        static void Main(string[] args)
        {
            var points = new List<Point>();

            try
            {
                Console.WriteLine("Points: ");
                using (StreamReader sr = new StreamReader(pointsFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        points.Add(new Point(line));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error by reading dataFile: " + e);
                throw;
            }

            Console.WriteLine("Kmeans: ");
            var clusterKmeans = new Kmeans().Clusterize(points, 4);
            Console.WriteLine("Cluter points after clusterization:");
            clusterKmeans.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Total distance to clusterpoints:");
            Console.WriteLine(points.Sum(x => x.DistanceToCluster));


        }
    }
}
