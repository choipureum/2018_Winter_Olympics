using _2018.imbc.com.Blls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2018.imbc.com.Models
{
    public class VODInfo
    {
        public string ItemID { get; set; }
        public string BroadcastID { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string SwfUrl { get; set; }
        public string ContentNumber { get; set; }
        public string BroadDate { get; set; }
        public string PreView { get; set; }
        public string ReadCount { get; set; }
    }

    public class VODList : List<VODInfo>
    {
        public int totalCnt { get; set; }
    }


    public class ContentInfo
    {
        public string BroadcastID { get; set; }
        public string ProgramBroadcastID { get; set; }
        public string ContentNumber { private get; set; }
        public string Preview { get; set; }
        public string BroadDate { get; set; }
        public string ProgramTitle { get; set; }
        public string ContentTitle { get; set; }
        public string ImgUrl_Big { get; set; }
        public string HomepageURL { get; set; }
        public string Duration { get; set; }
        public string Regdate { get; set; }
        public string BBSUrl { get; set; }
        public string HitCount { get; set; }
        public int itemid { get; set; }
        public string SubTitle { get; set; }

        public string ImgUrl_Normal
        {
            get
            {
                //return ImgUrl_Big;
                if (ImgUrl_Big != null)
                {
                    return Regex.Replace(ImgUrl_Big, "Big", "nomal", RegexOptions.IgnoreCase);
                }
                else
                {
                    return "";
                }
            }
        }

        public string ContentNumberString
        {
            get
            {
                return Util.DisplayContentNumber(ContentNumber);
            }
        }

    }

    public class ContentList
    {
        public int TotalCount { get; set; }
        public List<ContentInfo> List { get; set; }
    }
}