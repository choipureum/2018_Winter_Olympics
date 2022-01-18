using _2018.imbc.com.Dals;
using _2018.imbc.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class MedalBiz
    {
        private readonly MedalDal _dal;

        public MedalBiz()
        {
            _dal = new MedalDal();
        }
        public List<OlpMedalCount> RetrieveMedalCountList(string opt, string olympicCode)
        {
            List<OlpMedalCount> list = new List<OlpMedalCount>();

            if (opt == "S")
            {
                string cachenm = "RetrieveMedalCountList" + olympicCode;
                list = (List<OlpMedalCount>)HttpContext.Current.Cache[cachenm];

                if (list == null)
                {
                    list = _dal.RetrieveMedalCountList(opt, olympicCode);
                    HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
                }
            }
            else
            {
                list = _dal.RetrieveMedalCountList(opt, olympicCode);
            }

            return list;
        }
        public bool RegisterMedalCount(OlpMedalCount data)
        {
            bool rtn = _dal.RegisterMedalCount(data);

            return rtn;
        }

        public List<OlympicCodeInfo> RetrieveOlympicList()
        {
            return _dal.RetrieveOlympicList();
        }

        public OlpMedalCount RetrieveMedalCountListForMainKorea()
        {
            string cachenm = "RetrieveMedalCountListForMainKorea";

            OlpMedalCount info = (OlpMedalCount)HttpContext.Current.Cache[cachenm];

            if (info == null)
            {
                info = _dal.RetrieveMedalCountListForMainKorea();
                HttpContext.Current.Cache.Insert(cachenm, info, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
            }

            return info;
        }

        public string RetrieveUpdateTime(string timeDept, string olympicCode)
        {
            return _dal.RetrieveUpdateTime(timeDept, olympicCode);
        }
    }
}