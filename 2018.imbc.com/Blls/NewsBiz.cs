using _2018.imbc.com.Dals;
using _2018.imbc.com.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class NewsBiz
    {
        private readonly NewsDal _dal;

        public NewsBiz()
        {
            _dal = new NewsDal();
        }

        public EnewsList RetrievENewsList(int page, int pageSize, int onlyenews, int sort)
        {
            string cachenm = "RetrievENewsList_" + page + "_" + pageSize + "_" + onlyenews + "_" + sort;
            EnewsList list = (EnewsList)HttpContext.Current.Cache[cachenm];

            if(list == null)
            {
                list = _dal.RetrievENewsList(page, pageSize, onlyenews, sort);

                HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero);
            }

            return list;
        }


        public List<LNewsList> RetrivePupularNewsList(int cnt)
        {
            string cachenm = "RetrivePupularNewsList_" + cnt;

            List<LNewsList> llist = (List<LNewsList>)HttpContext.Current.Cache[cachenm];

            if(llist == null)
            {
                llist = new List<LNewsList>();

                List<NewsLog> ll = _dal.RetrieveNewsLog(cnt * 2);

                foreach (NewsLog o in ll)
                {

                    NewsSimple oo;

                    oo = _dal.RetrievENewsIdx(int.Parse(o.newsIdx));

                    LNewsList linfo = new LNewsList { Title = oo.title, Link = oo.orgurl, Idx = o.newsIdx, Opt = o.opt };
                    if (!string.IsNullOrEmpty(oo.title))
                    {
                        llist.Add(linfo);
                    }

                    if (llist.Count >= cnt) break;
                }

                HttpContext.Current.Cache.Insert(cachenm, llist, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }

            return llist;
        }

        public bool RegisterNewsLog(string opt, int idx)
        {
            return _dal.RegisterNewsLog(opt, idx);
        }


        public NewsSimple RetrievENewsIdx(int newsIdx)
        {
            string cachenm = "RetrievENewsIdx_" + newsIdx;
            NewsSimple info = (NewsSimple)HttpContext.Current.Cache[cachenm];

            if(info == null)
            {
                info = _dal.RetrievENewsIdx(newsIdx);

                HttpContext.Current.Cache.Insert(cachenm, info, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
            }

            return info;
        }

    }
}