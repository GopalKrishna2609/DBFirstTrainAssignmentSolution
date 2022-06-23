using DBFirstTrainAssignmentDATA.Models;
using DBFirstTrainAssignmentDATA;

namespace ConsoleApp1
{
    public class program
    {
        public static void Main()
        {
            CURDManager obj = new CURDManager();

            //Console.WriteLine("Adding Train Details");
            //obj.Insert(new Train { TrainNo = 1234, TrainName = "Local", FromStation = "Durg", ToStation = "Bhilai", StartTime = new TimeSpan(01, 30, 00), EndTime = new TimeSpan(3, 00, 00) });
            //obj.Insert(new Train { TrainNo = 2341, TrainName = "Hawda", FromStation = "Rajnndgao", ToStation = "Bhilai", StartTime = new TimeSpan(11, 00, 00), EndTime = new TimeSpan(6, 10, 00) });
            //obj.Insert(new Train { TrainNo = 5545, TrainName = "Rajdhani", FromStation = "Raipur", ToStation = "Bhilai", StartTime = new TimeSpan(12, 50, 00), EndTime = new TimeSpan(7, 00, 00) });
            //obj.Insert(new Train { TrainNo = 1111, TrainName = "Express", FromStation = "Delhi", ToStation = "Bhilai", StartTime = new TimeSpan(9, 40, 00), EndTime = new TimeSpan(8, 50, 00) });
            //Console.WriteLine("Trains Added");
            //PrintAllTrains();
            //Console.ReadLine();

            //Console.WriteLine("Updating Tain for Train No 1111");
            //obj.Update(1111, new Train { TrainName = "Channai Express", FromStation = "Chennai", ToStation = "Goa", StartTime = new TimeSpan(01, 30, 00), EndTime = new TimeSpan(23, 10, 00) });
            //Console.WriteLine("Trains Updated");
            //PrintAllTrains();
            //Console.ReadLine();

            //Console.WriteLine("Delting Train For Train No 1111");
            //obj.Delete(1111);
            //Console.WriteLine("Trains Deleted");
            //PrintAllTrains();
            //Console.ReadLine();

            Console.WriteLine("Getting Train details by Train No For 1234");
            var train = obj.GetTrainByTrainNo(1234);
            Console.WriteLine($"Train Number is {train.TrainNo} Name is {train.TrainName} it travels from {train.FromStation} at {train.StartTime} and reaches {train.ToStation} at {train.EndTime}");
            Console.ReadLine();

            Console.WriteLine("Getting Train Details by from station to to station");

        }
        private static void PrintAllTrains()
        {
            Console.WriteLine("Printing all Employees");
            CURDManager obj = new CURDManager();
            foreach (Train train in obj.GetAllTrains())
            {
                Console.WriteLine($"Train Number is {train.TrainNo} Name is {train.TrainName} it travels from {train.FromStation} at {train.StartTime} and reaches {train.ToStation} at {train.EndTime}");
            }
        }
    }
}

