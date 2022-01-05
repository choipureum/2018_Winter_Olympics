using System.Collections.Generic;

namespace _2018.imbc.com.Models
{
    public class ScheduleInfo
    {
        public int SchedulePK { get; set; }
        public string DateString { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string SportName { get; set; }
        public string SportType { get; set; }
        public string DetailSportName { get; set; }
        public string PlayerName { get; set; }        
        public string ResultInfo { get; set; }
        public string ResultDetail { get; set; }
        public string VodUrl { get; set; }
        public string NewsUrl { get; set; }
        public string NowState { get; set; }
    }

    public class ScheduleList : List<ScheduleInfo>
    {
        public int TotalCount { get; set; }
        public string update { get; set; }
    }

    public class SportsTypeInfo
    {
        public int SportType { get; set; }
        public string SportName { get; set; }
    }
}