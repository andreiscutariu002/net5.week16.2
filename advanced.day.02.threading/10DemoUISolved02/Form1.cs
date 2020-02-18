namespace _10DemoUISolved02
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using _10DemoUI.Core;

    public partial class Form1 : Form
    {
        private const string Path =
            @"d:\projects\wantsome\wantsome-dotnet-public\advanced.day.02.threading\cars.csv";

        public Form1()
        {
            this.InitializeComponent();
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            this.AppendToLog("start to process file");

            try
            {
                var task = new Task<IList<Car>>(() =>
                {
                    var cars = this.ReadCarsFromFile(Path).ToList();

                    return cars;
                });

                var context = TaskScheduler.FromCurrentSynchronizationContext();

                task.ContinueWith(prev =>
                    {
                        var cars = prev.Result;

                        this.DisplayCarsToContentBox(cars);

                        this.AppendToLog($"finish to process file. {cars.Count()} cars downloaded");
                    }, new CancellationToken(), TaskContinuationOptions.NotOnFaulted, context);

                task.ContinueWith(prev =>
                    {
                        var error = prev.Exception;

                        this.AppendToLog($"ERROR: {error?.InnerException?.Message}");
                    }, new CancellationToken(), TaskContinuationOptions.OnlyOnFaulted, context);

                task.Start();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IEnumerable<Car> ReadCarsFromFile(string filePath)
        {
            var cars = new List<Car>(600);

            var lines = File.ReadAllLines(filePath).Skip(2);

            foreach (var line in lines)
            {
                cars.Add(Car.Parse(line));

                Thread.Sleep(TimeSpan.FromMilliseconds(10)); // simulate some work
            }

            return cars;
        }

        private void AppendToLog(string s)
        {
            this.logTbx.AppendText($"{DateTime.Now} - {s}{Environment.NewLine}");
        }

        private void AppendToContent(string s)
        {
            this.contentTxb.AppendText($"{s}{Environment.NewLine}");
        }

        private void DisplayCarsToContentBox(IList<Car> cars)
        {
            foreach (var car in cars) this.AppendToContent(car.ToString());
        }
    }
}
