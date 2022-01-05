using _2018.imbc.com.Dals;
using _2018.imbc.com.Models;
using System;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class VodBiz
    {
        private readonly VodDal _dal;

        public VodBiz()
        {
            _dal = new VodDal();
        }


        public ContentList RetrieveContentList(int curPage, int pageSize, int order, int gubun, string keyword, string type, string opt, string date)
        {

            string cachenm = "RetrieveContentList_" + curPage + "_" + pageSize + "_" + order + "_" + gubun + "_" + keyword + "_" + type + "_" + opt + "_" + date;

            ContentList list = (ContentList)HttpContext.Current.Cache[cachenm];

            if(list == null)
            {
                list = _dal.RetrieveContentList(curPage, pageSize, order, gubun, keyword, type, opt, date);

                HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero);
            }


            return list;

        }


        public ContentInfo RetrieveContentInfo(string broadcastid)
        {
            string cachenm = "RetrieveContentInfo_" + broadcastid;

            ContentInfo info = (ContentInfo)HttpContext.Current.Cache[cachenm];

            if(info == null)
            {
                info = _dal.RetrieveContentInfo(broadcastid);

                HttpContext.Current.Cache.Insert(cachenm, info, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }

            return info;
        }
    }
}