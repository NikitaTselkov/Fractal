using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Fractal.Models
{
    public class FractalProcessing
    {
        private readonly MainFigure mainFigure = new MainFigure();

        public IEnumerable<Point> FindFractal()
        {
            var random = new Random(Guid.NewGuid().ToByteArray().Sum(s => s)); // Генератор псевдослучайных чисел

            var pointsA = mainFigure.Points; // Основные точки

            var resultPoints = new List<Point>(pointsA);

            Point firstPoint;

            Point secondPoint;

            Point newPoint;


            resultPoints.Add(mainFigure.PointB);


            for (int i = 4; i < 5000; i++)
            {
                firstPoint = resultPoints.Last();
                secondPoint = pointsA[random.Next(0, pointsA.Length)];

                newPoint = new Point((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2);

                resultPoints.Add(newPoint);
            }

            return resultPoints;
        }

    }
}
