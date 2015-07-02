using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point BelongsToCluster { get; set; }
        public int ClusteredCounted { get; set; }

        public double DistanceToCluster 
        { 
            get
            {
                return Distance(this, BelongsToCluster);
            }
        }

        public Point()
        {

        }

        public Point(Random r)
        {
            X = r.Next(2, 12);
            Y = r.Next(2, 12);
        }

        public Point(Random r, int from, int to)
        {
            X = r.Next(from, to + 1);
            Y = r.Next(from, to + 1);
        }

        public Point(string line)
        {
            var coordinates = line.Split('\t').Select(int.Parse).ToList();
            X = coordinates[0];
            Y = coordinates[1];
        }

        public override bool Equals(object obj)
        {
            var item = obj as Point;

            if (item == null)
            {
                return false;
            }

            return this.X.Equals(item.X) && this.Y.Equals(item.Y);
        }

        internal void SetCluster(List<Point> clusterPoints)
        {
            var minDistance = double.MaxValue;
            foreach (var p in clusterPoints)
            {
                var distance = Distance(this, p);

                if (distance < minDistance)
                {
                    BelongsToCluster = p;
                    minDistance = distance;
                }
            }
        }

        private double Distance(Point from, Point to)
        {
            return Math.Sqrt(
                Math.Pow(from.X - to.X, 2) +
                Math.Pow(from.Y - to.Y, 2));
        }

        public double Distance(Point to)
        {
            return Math.Sqrt(
                Math.Pow(X - to.X, 2) +
                Math.Pow(Y - to.Y, 2));
        }

        internal void Plus(Point x)
        {
            X += x.X;
            Y += x.Y;
        }

        internal void Minus(Point x)
        {
            X -= x.X;
            Y -= x.Y;
        }

        internal void Resize(double coef)
        {
            X = (int)(X * coef);
            Y = (int)(Y * coef);
        }
        
        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
            //return String.Concat(_name, _number, _date, _salary);
        }

        internal void Normalize(double minX, double maxX, double minY, double maxY, int from, int to)
        {
            X = Normalize(minX, maxX, X, from, to);
            Y = Normalize(minY, maxY, Y, from, to);
        }

        internal void Denormalize(double minX, double maxX, double minY, double maxY, int from, int to)
        {
            X = Denormalize(minX, maxX, X, from, to);
            Y = Denormalize(minY, maxY, Y, from, to);
        }

        private double Normalize(double minX, double maxX, double X, int from, int to)
        {
            var xRange = maxX - minX;
            var xPlace = X - minX;
            var xPercentage = xPlace / xRange;

            var normalRange = from - to;
            var normalPlace = xPercentage * normalRange;
            return to + normalPlace;
        }

        private double Denormalize(double minX, double maxX, double X, int from, int to)
        {
            var normalizedRange = from - to;
            var normalizedPlace = X / normalizedRange;

            var xRange = maxX - minX;
            var xPlace = xRange * normalizedPlace;
            return minX + xPlace;
        }
    }
}
