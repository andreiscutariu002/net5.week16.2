namespace _10DemoUISolved03
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
            @"c:\Users\ascutariu\Projects\wantsome\net5.week16.2\advanced.day.02.threading\cars.csv";

        private const string Path2 =
            @"c:\Users\ascutariu\Projects\wantsome\net5.week16.2\advanced.day.02.threading\cars.csv";

        public Form1()
        {
            this.InitializeComponent();
        }

        private async void GetDataBtn_Click(object sender, EventArgs e)
        {
            this.AppendToLog("start to process file");

            var task = Task.Factory.StartNew(
                () => {
                    return this.ReadCarsFromFile(Path2).ToList();
                });

            try
            {
                var carsResult = await task;

                this.DisplayCarsToContentBox(carsResult);

                this.AppendToLog($"finish to process file. {carsResult.Count()} cars downloaded");
            }
            catch (Exception exception)
            {
                this.AppendToLog($"ERROR: {exception?.Message}");
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
