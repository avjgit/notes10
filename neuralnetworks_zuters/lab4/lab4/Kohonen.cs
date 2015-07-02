using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Kohonen
    {
        public List<Point> Clusterize(
            List<Point> points,
            int clustersCount,
            double neighborCoef1,
            double neighborCoef2,
            double learningCoef1,
            double learningCoef2,
            double changeCoef,
            int maxEpochs = 1000)
        {
            var r = new Random();

            List<Point> clusterPoints = new List<Point>();
            for (int i = 0; i < clustersCount; i++)
            {
                clusterPoints.Add(new Point(r, 0, 1));
            }

            Console.WriteLine("Random cluster points:");
            clusterPoints.ForEach(x => Console.WriteLine(x));

            var minX = points.Select(x => x.X).Min();
            var maxX = points.Select(x => x.X).Max();

            var minY = points.Select(x => x.Y).Min();
            var maxY = points.Select(x => x.Y).Max();
            
            points.ForEach(x => x.Normalize(minX, maxX, minY, maxY, 0, 1));

            var epoch = 0;
            var neighborCoef = neighborCoef1;
            var learningCoef = learningCoef1;
            while (epoch < maxEpochs)
            {
                epoch++;

                foreach (var p in points)
                {
                    p.SetCluster(clusterPoints);
                    var best = p.BelongsToCluster;

                    foreach (var c in clusterPoints)
                    {
                        var dist = TopologicDistance(c, best);
                        var nfactor = Math.Exp(-((dist*dist) / (2*neighborCoef*neighborCoef)));

                        p.Minus(c);
                        p.Resize(learningCoef);
                        p.Resize(nfactor);
                        c.Plus(p);
                    }               
                }

                neighborCoef += (neighborCoef2 - neighborCoef) * changeCoef;
                learningCoef += (learningCoef2 - learningCoef) * changeCoef;
            }
            //denormalize
            return clusterPoints;
        }

        private int TopologicDistance(Point p1, Point p2)
        {
            return
            Math.Abs(p1.X - p2.X) +
            Math.Abs(p1.Y - p2.Y);
        }
    }
}
