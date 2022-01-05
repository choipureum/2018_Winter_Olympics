using _2018.imbc.com.Dals;
using _2018.imbc.com.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class NoticeBiz
    {
        private readonly NoticeDal _dal;

        public NoticeBiz()
        {
            _dal = new NoticeDal();
        }

        public NoticeList RetrieveNoticeList(string isAdmin)
        {
            NoticeList list = new NoticeList();

            if (isAdmin == "N")
            {
                string cachenm = "RetrieveNoticeListPC2018_N";
                list = (NoticeList)HttpContext.Current.Cache[cachenm];

                if (list == null)
                {
                    list = _dal.RetrieveNoticeList(isAdmin);
                    HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
                }
            }
            else
            {
                list = _dal.RetrieveNoticeList(isAdmin);
            }

            return list;
        }

        public bool RegisterNotice(int Seq, string Title, string IsDel)
        {
            bool rtn = _dal.RegisterNotice(Seq, Title, IsDel);

            return rtn;
        }


        public List<MedalCount> RetrieveMedalCountList(string opt)
        {
            List<MedalCount> list = new List<MedalCount>();

            if (opt == "S")
            {
                string cachenm = "RetrieveMedalCountList_PC2018_S";
                list = (List<MedalCount>)HttpContext.Current.Cache[cachenm];

                if (list == null)
                {
                    list = _dal.RetrieveMedalCountList(opt);
                    HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
                }
            }
            else
            {
                list = _dal.RetrieveMedalCountList(opt);
            }

            return list;
        }


        public bool RegisterMedalCount(MedalCount data)
        {
            bool rtn = _dal.RegisterMedalCount(data);

            return rtn;
        }

        public MedalCount RetrieveMedalCountListForMainKorea()
        {
            string cachenm = "RetrieveMedalCountListForMainKorea_PC2018";

            MedalCount info = (MedalCount)HttpContext.Current.Cache[cachenm];

            if(info == null)
            {
                info = _dal.RetrieveMedalCountListForMainKorea();
                HttpContext.Current.Cache.Insert(cachenm, info, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
            }           

            return info;
        }

        public string RetrieveUpdateTime(string timeDept)
        {
            return _dal.RetrieveUpdateTime(timeDept);
        }
    }
}