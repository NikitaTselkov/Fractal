using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fractal.Models
{
    public class MainFigure
    {
        public Point[] Points { get; private set; }

        public Point PointB { get; private set; }

        public MainFigure()
        {
            var random = new Random(Guid.NewGuid().ToByteArray().Sum(s => s));

            Points = new Point[] { new Point(400, 60), new Point(150, 500), new Point(650, 500) };

            PointB = new Point(random.Next(1, 800), random.Next(1, 800));
        }
    }
}
