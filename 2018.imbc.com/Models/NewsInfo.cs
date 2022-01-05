using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2018.imbc.com.Models
{
    public class NewsInfo
    {
        public string cur { get; set; }
        public int rownum { get; set; }
        public string artid { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string arttype { get; set; }
        public string imgurl { get; set; }
        public string vodurl { get; set; }
        public string artcont { get; set; }
        public string author { get; set; }
        public string pubDate { get; set; }
        public string type { get; set; }
        public string appwrite { get; set; }
        public string orgurl { get; set; }
    }

    public class NewsSimple
    {
        public string title { get; set; }
        public string imgurl { get; set; }
        public string NickName { get; set; }
        public string NewsImg { get; set; }
        public string pubDate { get; set; }
        public string content { get; set; }
        public string orgurl { get; set; }
        public string vodurl { get; set; }
        public string author { get; set; }
        public int IsVideo { get; set; }
    }

    public class NewsContent
    {
        public string title { get; set; }
        public string imgurl { get; set; }
        public string pubDate { get; set; }
        public string orgurl { get; set; }
        public string artcont { get; set; }

    }

    public class NewsList : List<NewsInfo>
    {
        public int LimitPage { get; set; }
        public int TotalCount { get; set; }
    }


    public class NewsLog
    {
        public string opt { get; set; }
        public string newsIdx { get; set; }
        public int hit { get; set; }
    }


    public class EnewsInfo
    {
        public int Idx { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string ImgUrlR { get; set; }
        public string Summary { get; set; }
        public string PublicationDate { get; set; }
        public string Nickname { get; set; }
        public string OrgUrl { get; set; }
    }

    public class EnewsList : List<EnewsInfo>
    {
        public int TotalCount { get; set; }
    }

    public class LNewsList
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Idx { get; set; }
        public string Opt { get; set; }
    }
}