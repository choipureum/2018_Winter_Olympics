using System.Collections.Generic;

namespace _2018.imbc.com.Models
{
    public class NoticeInfo
    {
        public int Seq { get; set; }
        public string Title { get; set; }

        public string IsDel { get; set; }
    }

    public class NoticeList
    {
        public string OnAir { get; set; }
        public List<NoticeInfo> List { get; set; }
    }

    public class MedalCount
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
        
    }

    public class MedalCountList : List<MedalCount>
    {
        public string moddate { get; set; }
    }


    public class National
    {
        public int NationalID { get; set; }
        public string NationalName { get; set; }
        public string NationalImg { get; set; }
    }

    public class MedalInfo
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
    public class MedalList : List<MedalInfo>
    {
        public int TotalCount { get; set; }
        public string moddate { get; set; }
    }

}