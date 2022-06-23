using System;
using System.Collections.Generic;

namespace DBFirstTrainAssignmentDATA.Models
{
    public partial class Train
    {
        public int TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
