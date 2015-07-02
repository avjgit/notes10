using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Kmeans
    {
        public List<Point> Clusterize(
            List<Point> points, 
            int clustersCount, 
            int maxEpochs = 500)
        {
            var r = new Random();
            
            List<Point> clusterPoints = new List<Point>();
            for (int i = 0; i < clustersCount; i++){
                clusterPoints.Add(new Point(r));
			}

            Console.WriteLine("Random cluster points:");
            clusterPoints.ForEach(x => Console.WriteLine(x));

            List<Point> assistancePoints = new List<Point>();
            clusterPoints.ForEach(x => assistancePoints.Add(new Point() { X = 0, Y = 0 }));

            var epoch = 0;
            while (epoch < maxEpochs && !Equal(clusterPoints, assistancePoints))
            {
                epoch++;
                assistancePoints = clusterPoints.ToList();

                foreach (var p in points)
                {
                    p.SetCluster(clusterPoints);
                }

                clusterPoints.ForEach(x => { x.X = 0; x.Y = 0; });

                foreach (var c in clusterPoints)
                {
                    var belongingToThisCluster = points.Where(x => x.BelongsToCluster == c).ToList();
                    belongingToThisCluster.ForEach(x => c.Plus(x));
                    if (belongingToThisCluster.Any())
                    {
                        c.X = c.X / belongingToThisCluster.Count();
                        c.Y = c.Y / belongingToThisCluster.Count();
                    }
                }
            }

            return clusterPoints;
        }

        private bool Equal(List<Point> list1, List<Point> list2)
        {
            return !list1.Except(list2).Any() && !list2.Except(list1).Any();
        }
    }
}
