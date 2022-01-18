using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2018.imbc.com.Models
{
    public class OlpMedalCount
    {
        public int CountID { get; set; }
        public int Rank { get; set; }
        public int NationalID { get; set; }
        public string NationalName { get; set; }
        public string NationalImg { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
        public int Total { get; set; }
        public string uptTime { get; set; }
        public string OlympicCode { get; set; }

    }

    public class OlympicCodeInfo
    {
        public int OlympicID { get; set; }
        public string OlympicCode { get; set; }
        public string OlympicName { get; set; }
        public DateTime OlympicDate { get; set; }
    }

    public class OlpMedalCountList : List<OlpMedalCount>
    {
        public string moddate { get; set; }
    }


    public class OlpNational
    {
        public int NationalID { get; set; }
        public string NationalName { get; set; }
        public string NationalImg { get; set; }
    }

    public class OlpMedalInfo
    {
        public int Idx { get; set; }
        public int MedalScore { get; set; }
        public string GameName { get; set; }
        public string PlayerName { get; set; }
        public string ImgUrl { get; set; }
        public int SprotType { get; set; }
        public string SportName { get; set; }
        public int OrderNumber { get; set; }
        public string BroadcastId { get; set; }
        public int ItemId { get; set; }
    }
    public class OlpMedalList : List<OlpMedalInfo>
    {
        public int TotalCount { get; set; }
        public string moddate { get; set; }
    }
}