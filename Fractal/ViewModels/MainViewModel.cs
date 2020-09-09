using Fractal.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Fractal.ViewModels
{
    public class MainViewModel : Navigation.NavigateViewModel
    {
        public RelayCommand StartFindFractal { get; set; }

        public ObservableCollection<Point> Points { get; set; }

        public int Delay { get; set; } = 120;


        public MainViewModel()
        {
            StartFindFractal = new RelayCommand(StartFindFractalMethod);

            Points = new ObservableCollection<Point>();
        }


        public void StartFindFractalMethod(object param)
        {
            FractalProcessing fractalProcessing = new FractalProcessing();

            var points = new List<Point>(fractalProcessing.FindFractal());

            ThreadPool.QueueUserWorkItem((o) =>
            {
                foreach (var item in points)
                {
                    if (App.Current != null)
                    {
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            Points.Add(item);
                        });
                    }
                    
                    Thread.Sleep(Delay);
                }
            });

        }

    }
}
