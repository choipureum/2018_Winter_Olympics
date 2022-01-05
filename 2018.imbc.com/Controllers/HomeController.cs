using _2018.imbc.com.Models;
using _2018.imbc.com.Blls;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace _2018.imbc.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsBiz _nbiz;
        private readonly VodBiz _vbiz;
        private readonly NoticeBiz _tbiz;
        private readonly ScheduleBiz _sbiz;

        public HomeController()
        {
            _nbiz = new NewsBiz();
            _vbiz = new VodBiz();
            _tbiz = new NoticeBiz();
            _sbiz = new ScheduleBiz();
        }

        public ActionResult Index()
        {
            ContentList vodList = _vbiz.RetrieveContentList(1, 3, 1, 0, "", "", "", "");
            EnewsList rNewsList = _nbiz.RetrievENewsList(1, 3, 1, 0);
            List<LNewsList> lNewsList = _nbiz.RetrivePupularNewsList(7);
            ViewBag.vodlist = vodList;
            ViewBag.rnewslist = rNewsList;
            ViewBag.lnewslist = lNewsList;

            return View();
        }

        public ActionResult Index2()
        {

            EnewsList rNewsList = _nbiz.RetrievENewsList(1, 3, 1, 0);
            List<LNewsList> lNewsList = _nbiz.RetrivePupularNewsList(7);
            NoticeList tlist = _tbiz.RetrieveNoticeList("N");
            List<MedalCount> medalList = _tbiz.RetrieveMedalCountList("S");

            MedalCount kcount = _tbiz.RetrieveMedalCountListForMainKorea();

            DateTime dt = new DateTime();
            dt = DateTime.Today;

            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            ScheduleList slist = _sbiz.RetrieveScheduleList(dt, "N");



            ViewBag.rnewslist = rNewsList;
            ViewBag.lnewslist = lNewsList;

            ViewBag.tlist = tlist;

            ViewBag.medalList = medalList;

            ViewBag.kcount = kcount;

            ViewBag.slist = slist;
            ViewBag.dt = dt.ToString("yyyy.MM.dd");

            IndexVod(1);

            return View();
        }

        public PartialViewResult IndexVod(int order = 1)
        {
            ContentList vodList = _vbiz.RetrieveContentList(1, 3, order, 0, "", "", "", "");
            ViewBag.vodlist = vodList;

            return PartialView();
        }


        public ActionResult mIndex()
        {
            ContentList vodList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "", "");
            EnewsList rNewsList = _nbiz.RetrievENewsList(1, 4, 0, 0);
            ViewBag.vodlist = vodList;
            ViewBag.rnewslist = rNewsList;

            return View();
        }

        public ActionResult mIndex2()
        {
            ContentList vodList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "", "");
            EnewsList rNewsList = _nbiz.RetrievENewsList(1, 4, 0, 0);
            ViewBag.vodlist = vodList;
            ViewBag.rnewslist = rNewsList;

            NoticeList tlist = _tbiz.RetrieveNoticeList("N");

            DateTime dt = new DateTime();
            dt = DateTime.Today;

            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            ScheduleList slist = _sbiz.RetrieveScheduleList(dt, "N");

            MedalCount kcount = _tbiz.RetrieveMedalCountListForMainKorea();

            ViewBag.tlist = tlist;
            ViewBag.slist = slist;
            ViewBag.dt = dt.ToString("MM월 dd일 dddd");
            ViewBag.kcount = kcount;



            return View();
        }

        public ActionResult Vod(string bid = "", int itemid = 0)
        {
            //ContentList hotList = _vbiz.RetrieveContentList(1, 8, 1, 0, "", "", "HOT", "");
            ContentList hotList = _vbiz.RetrieveContentList(1, 8, 1, 0, "", "", "", "");

            if (string.IsNullOrEmpty(bid) || itemid == 0)
            {
                ContentList vodList = _vbiz.RetrieveContentList(1, 9, 1, 0, "", "", "", "");
                ViewBag.bid = vodList.List[0].BroadcastID;
                ViewBag.itemid = vodList.List[0].itemid;
                VodList(1, 9, vodList.List[0].itemid);
            }
            else
            {
                ViewBag.bid = bid;
                ViewBag.itemid = itemid;
                VodList(1, 9, itemid);
            }

            ViewBag.hotlist = hotList;

            return View();
        }

        public ActionResult Vod2(string bid = "", int itemid = 0, int glory=0)
        {
            //ContentList hotList = _vbiz.RetrieveContentList(1, 8, 1, 0, "", "", "HOT", "");
            ContentList hotList = _vbiz.RetrieveContentList(1, 8, 1, 0, "", "", "", "");

            int gubun = 0;

            if (glory == 1) gubun = 7;

            if (string.IsNullOrEmpty(bid) || itemid == 0)
            {
                ContentList vodList = _vbiz.RetrieveContentList(1, 9, 1, gubun, "", "", "", "");
                ViewBag.bid = vodList.List[0].BroadcastID;
                ViewBag.itemid = vodList.List[0].itemid;                

                VodList2(1, 9, vodList.List[0].itemid, 1,  gubun, "");
            }
            else
            {
                ViewBag.bid = bid;
                ViewBag.itemid = itemid;
                VodList2(1, 9, itemid, 1, gubun, "");
            }

            ViewBag.hotlist = hotList;
            ViewBag.glory = glory;

            return View();
        }

        public ActionResult mVod()
        {
            //ContentList hotList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "HOT", "");
            ContentList hotList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "", "");
            ViewBag.hotlist = hotList;

            mVodList(1, 6);

            return View();
        }

        public ActionResult mVod2()
        {
            //ContentList hotList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "HOT", "");
            ContentList hotList = _vbiz.RetrieveContentList(1, 4, 1, 0, "", "", "", "");
            ViewBag.hotlist = hotList;

            mVodList2(1, 6, 1, 0, "");

            return View();
        }

        public PartialViewResult VodList(int page = 1, int size = 9, int itemid = 0)
        {
            ContentList vodList = _vbiz.RetrieveContentList(page, size, 1, 0, "", "", "", "");
            ViewBag.vodList = vodList;
            ViewBag.itemid = itemid;

            string pageHtml = "";
            int pb = 5;
            double d = 1.0;
            int navCount = int.Parse(System.Math.Ceiling(vodList.TotalCount * d / size).ToString());

            int blockPage = ((page - 1) / pb) * pb + 1;
            int endPage = navCount >= blockPage + pb ? blockPage + pb : navCount + 1;
            int prevPage = ((blockPage - pb) / pb) * pb + 1;
            int nextPage = ((blockPage + pb) / pb) * pb + 1;

            if (nextPage > navCount) nextPage = navCount;

            pageHtml += "<a class=\"btn first-prev\" href=\"javascript:goPage(1);\">맨처음</a>";
            pageHtml += "<a class=\"btn prev\" href=\"javascript:goPage(" + prevPage + ");\">이전</a>";

            for (int i = blockPage; i < endPage; i++)
            {
                if (page == i)
                {
                    pageHtml += "<a class=\"on\"  href=\"javascript:goPage(" + i + ");\">" + i + "</a>";
                }
                else
                {
                    pageHtml += "<a href=\"javascript:goPage(" + i + ");\">" + i + "</a>";
                }
            }

            pageHtml += "<a class=\"btn next\" href=\"javascript:goPage(" + nextPage + ");\">다음</a>";
            pageHtml += "<a class=\"btn last-next\" href=\"javascript:goPage(" + navCount + ");\">마지막</a>";

            ViewBag.pageHtml = pageHtml;


            return PartialView();
        }

        public PartialViewResult VodList2(int page = 1, int size = 9, int itemid = 0, int order=1, int gubun=0, string type="")
        {
            ContentList vodList = _vbiz.RetrieveContentList(page, size, order, gubun, "", type, "", "");
            ViewBag.vodList = vodList;
            ViewBag.itemid = itemid;

            string pageHtml = "";
            int pb = 5;
            double d = 1.0;
            int navCount = int.Parse(System.Math.Ceiling(vodList.TotalCount * d / size).ToString());

            int blockPage = ((page - 1) / pb) * pb + 1;
            int endPage = navCount >= blockPage + pb ? blockPage + pb : navCount + 1;
            int prevPage = ((blockPage - pb) / pb) * pb + 1;
            int nextPage = ((blockPage + pb) / pb) * pb + 1;

            if (nextPage > navCount) nextPage = navCount;

            pageHtml += "<a class=\"btn first-prev\" href=\"javascript:goPage(1);\">맨처음</a>";
            pageHtml += "<a class=\"btn prev\" href=\"javascript:goPage(" + prevPage + ");\">이전</a>";

            for (int i = blockPage; i < endPage; i++)
            {
                if (page == i)
                {
                    pageHtml += "<a class=\"on\"  href=\"javascript:goPage(" + i + ");\">" + i + "</a>";
                }
                else
                {
                    pageHtml += "<a href=\"javascript:goPage(" + i + ");\">" + i + "</a>";
                }
            }

            pageHtml += "<a class=\"btn next\" href=\"javascript:goPage(" + nextPage + ");\">다음</a>";
            pageHtml += "<a class=\"btn last-next\" href=\"javascript:goPage(" + navCount + ");\">마지막</a>";

            ViewBag.pageHtml = pageHtml;


            return PartialView();
        }

        public PartialViewResult mVodList(int page = 1, int size = 6)
        {
            ContentList vodList = _vbiz.RetrieveContentList(page, size, 1, 0, "", "", "", "");
            ViewBag.vodList = vodList;

            return PartialView();
        }

        public PartialViewResult mVodList2(int page = 1, int size = 6, int order = 1, int gubun = 0, string type = "")
        {
            ContentList vodList = _vbiz.RetrieveContentList(page, size, order, gubun, "", type, "", "");
            ViewBag.vodList = vodList;

            return PartialView();
        }


        public ActionResult News(int page = 1, int sort = 0)
        {
            int size = 5;
            EnewsList list = _nbiz.RetrievENewsList(page, size, 0, sort);

            ViewBag.list = list;

            string pageHtml = "";
            int pb = 5;
            double d = 1.0;
            int navCount = int.Parse(System.Math.Ceiling(list.TotalCount * d / size).ToString());
            int blockPage = ((page - 1) / pb) * pb + 1;
            int endPage = navCount >= blockPage + pb ? blockPage + pb : navCount + 1;
            int prevPage = ((blockPage - pb) / pb) * pb + 1;
            int nextPage = ((blockPage + pb) / pb) * pb + 1;

            if (nextPage > navCount) nextPage = navCount;

            pageHtml += "<a class=\"btn first-prev\" href=\"javascript:goPage(1, " + sort + ");\">맨처음</a>";
            pageHtml += "<a class=\"btn prev\" href=\"javascript:goPage(" + prevPage + ", " + sort + ");\">이전</a>";

            for (int i = blockPage; i < endPage; i++)
            {
                if (page == i)
                {
                    pageHtml += "<a class=\"on\"  href=\"javascript:goPage(" + i + ", " + sort + ");\">" + i + "</a>";
                }
                else
                {
                    pageHtml += "<a href=\"javascript:goPage(" + i + ", " + sort + ");\">" + i + "</a>";
                }
            }

            pageHtml += "<a class=\"btn next\" href=\"javascript:goPage(" + nextPage + ", " + sort + ");\">다음</a>";
            pageHtml += "<a class=\"btn last-next\" href=\"javascript:goPage(" + navCount + ", " + sort + ");\">마지막</a>";

            ViewBag.pageHtml = pageHtml;

            string ordercls1 = "";
            string ordercls2 = "";

            if (sort == 0) ordercls1 = "class=\"on\"";
            else ordercls2 = "class=\"on\"";

            ViewBag.ordercls1 = ordercls1;
            ViewBag.ordercls2 = ordercls2;

            ViewBag.sort = sort;
            ViewBag.pagenum = page;

            return View();
        }

        public ActionResult NewsView(int idx = 0, int page = 1, int sort = 0, string opt = "")
        {
            if (page == 0)
            {
                page = 1;
            }

            _nbiz.RegisterNewsLog(opt, idx);

            ViewBag.info = _nbiz.RetrievENewsIdx(idx);
            ViewBag.sort = sort;
            ViewBag.pagenum = page;

            return View();
        }


        public ActionResult mNews(int page = 1, int sort = 0)
        {
            ViewBag.curpage = page;
            ViewBag.cursort = sort;

            mNewsList(1, page * 5, sort);

            return View();
        }

        public ActionResult mNewsView(int idx, string opt, int page = 1, int sort = 0)
        {
            _nbiz.RegisterNewsLog(opt, idx);

            ViewBag.info = _nbiz.RetrievENewsIdx(idx);

            ViewBag.curpage = page;
            ViewBag.cursort = sort;

            return View();
        }

        public PartialViewResult mNewsList(int page = 1, int size = 5, int sort = 0)
        {
            EnewsList list = _nbiz.RetrievENewsList(page, size, 0, sort);
            ViewBag.list = list;
            ViewBag.totalcnt = list.TotalCount;

            return PartialView();
        }



        public RedirectResult NewsLink(int idx, string opt, string u)
        {
            _nbiz.RegisterNewsLog(opt, idx);

            if (u == "")
            {
                string link = "http://enews.imbc.com/News/RetrieveNewsInfo/" + idx;
                return Redirect(link);
            }
            else
            {
                return Redirect(u);
            }

        }

        public JsonResult ContentInfo(string bid)
        {
            ContentInfo info = _vbiz.RetrieveContentInfo(bid);

            return Json(info, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MedalRank()
        {
            ContentList vodList = _vbiz.RetrieveContentList(1, 9, 1, 7, "", "", "", "");

            List<MedalCount> medalList = _tbiz.RetrieveMedalCountList("S");
            MedalCount kcount = _tbiz.RetrieveMedalCountListForMainKorea();

            ViewBag.vodList = vodList;
            ViewBag.medalList = medalList;
            ViewBag.kcount = kcount;


            return View();
        }

        public ActionResult mMedalRank()
        {
            List<MedalCount> medalList = _tbiz.RetrieveMedalCountList("S");
            MedalCount kcount = _tbiz.RetrieveMedalCountListForMainKorea();
         
            ViewBag.medalList = medalList;
            ViewBag.kcount = kcount;

            return View();
        }

        public ActionResult ScheduleList()
        {
            DateTime dt = new DateTime();

            dt = DateTime.Today;
            //dt = DateTime.Today.AddDays(15);


            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            string dtDay = dt.ToString("yyyy-MM-dd");

            ScheduleListPage(dtDay);

            ViewBag.dtDay = dtDay;

            return View();
        }

        public ActionResult mScheduleList()
        {
            DateTime dt = new DateTime();

            dt = DateTime.Today;
            //dt = DateTime.Today.AddDays(15);


            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            string dtDay = dt.ToString("yyyy-MM-dd");

            mScheduleListPage(dtDay);

            ViewBag.dtDay = dtDay;

            return View();
        }

        public PartialViewResult ScheduleListPage(string dtDay)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.Parse(dtDay);
            }
            catch
            {
                dt = DateTime.Today;
            }

            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            ScheduleList list = _sbiz.RetrieveScheduleList(dt, "N");
            ViewBag.list = list;

            return PartialView();
        }

        public PartialViewResult mScheduleListPage(string dtDay)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.Parse(dtDay);
            }
            catch
            {
                dt = DateTime.Today;
            }

            DateTime minDt = DateTime.Parse("2018-02-08");
            DateTime maxDt = DateTime.Parse("2018-02-25");

            if (dt <= minDt) dt = minDt;
            if (dt >= maxDt) dt = maxDt;

            ScheduleList list = _sbiz.RetrieveScheduleList(dt, "N");
            ViewBag.list = list;

            return PartialView();
        }

        public ActionResult test()
        {
            return View();
        }




    }
}