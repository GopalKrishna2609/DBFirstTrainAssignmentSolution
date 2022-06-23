using DBFirstTrainAssignmentDATA.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBFirstTrainAssignmentDATA
{
    public class CURDManager
    {
        TrainAssignmentContext trainAssignmentContext = new TrainAssignmentContext();
        public Train GetTrainByTrainNo(int trainNo)
        {
            // Tracking not required
            var TrainNO = trainAssignmentContext.Trains.Where(x => x.TrainNo == trainNo).
                AsNoTracking().OrderBy(s => s.TrainName)
                            .Last();


            if (TrainNO == null)
            {
                throw new Exception($"Employee with ID:{trainNo} Not Found");
            }

            return TrainNO;
        }

        public void GetTrainByStation(string from , string to)
        {
            var trn = trainAssignmentContext.Trains.Where(tr => tr.FromStation == from && tr.ToStation == to).ToList();
            if (trn != null)
            {
                foreach (var tr in trn)
                {
                    Console.WriteLine("Train Number             :" + tr.TrainNo);
                    Console.WriteLine("Train Name               :" + tr.TrainName);
                    Console.WriteLine("Train  From Station      :" + tr.FromStation);
                    Console.WriteLine("Train To Station         :" + tr.ToStation);
                    Console.WriteLine("Train Journey Start Time :" + tr.StartTime);
                    Console.WriteLine("Train Journey End Time   :" + tr.EndTime);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No tarins Available... from " + from + " station to " + to + " station");
            }
        }
        public List<Train> GetAllTrains()
        {
            var trainlist = trainAssignmentContext.Trains.ToList();
            return trainlist;
        }

        public void Insert(Train train)
        {
            trainAssignmentContext.Trains.Add(train);
            trainAssignmentContext.SaveChanges();
        }

        public void Update(int trainNo, Train modifiedTrain)
        {
            var train = trainAssignmentContext.Trains.Where(x => x.TrainNo == trainNo).FirstOrDefault();
            if (train == null)
            {
                Console.WriteLine($"Employee with ID:{trainNo} Not Found");
            }

            train.TrainName = modifiedTrain.TrainName;
            train.ToStation = modifiedTrain.ToStation;
            train.FromStation = modifiedTrain.FromStation;
            train.StartTime = modifiedTrain.StartTime;
            train.EndTime = modifiedTrain.EndTime;

            // Entity state : Modified
            trainAssignmentContext.Trains.Update(train);

            // This issues insert statement
            trainAssignmentContext.SaveChanges();
        }

        public void Delete(int trainNo)
        {
            var train = trainAssignmentContext.Trains.Where(x => x.TrainNo == trainNo).FirstOrDefault();
            if (train == null)
            {
                throw new Exception($"Employee with ID:{trainNo} Not Found");
            }

            // Entity state : Deleted
            trainAssignmentContext.Trains.Remove(train);

            // This issues insert statement
            trainAssignmentContext.SaveChanges();
        }
    }
}
