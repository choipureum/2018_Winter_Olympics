using _2018.imbc.com.Models;
using _2018.imbc.com.Blls;
using System.Web.Mvc;
using System.Collections.Generic;
using IMBC.FW.Util;
using System;

namespace _2018.imbc.com.Controllers
{
    public class PCrhksflController : Controller
    {
        private readonly NoticeBiz _biz;
        private readonly ScheduleBiz _sbiz;
        

        public PCrhksflController()
        {
            //Util.CheckAdmin();
            _biz = new NoticeBiz();
            _sbiz = new ScheduleBiz();
        
        }


        // GET: PCrhksfl
        public ActionResult Index2()
        {
            return Redirect("/pcrhksfl/Notice");
        }


        public ActionResult Notice()
        {
            NoticeList list = _biz.RetrieveNoticeList("Y");

            ViewBag.list = list;

            return View();
        }

        public ActionResult NoticeProcess(int seq, string title, string isdel)
        {
            bool rtn = _biz.RegisterNotice(seq, title, isdel);

            string msg = "수정되었습니다.";

            if (!rtn)
            {
                msg = "수정에 실패했습니다.";
            }

            return Content("<script>alert('" + msg + "');location.href='Notice';</script>");
        }

        public ActionResult Medal()
        {
            List<MedalCount> list = _biz.RetrieveMedalCountList("A");

            ViewBag.list = list;
            ViewBag.time = _biz.RetrieveUpdateTime("C");

            return View();
        }
        [HttpPost]
        public ActionResult MedalProcess(FormCollection formCollection)
        {
            string msg = "수정되었습니다.";

            for (int i = 0; i < 250; i++)
            {
                string gold = WebUtil.GetRequestForm("Gold_" + i, "");

                if (gold != "")
                {
                    MedalCount data = new MedalCount();

                    data.NationalID = i;
                    data.Gold = int.Parse(gold);
                    data.Silver = int.Parse(WebUtil.GetRequestForm("Silver_" + i, ""));
                    data.Bronze = int.Parse(WebUtil.GetRequestForm("Bronze_" + i, ""));

                    _biz.RegisterMedalCount(data);
                }
            }

            return Content("<script>alert('" + msg + "');location.href='Medal';</script>");
        }


        public ActionResult Schedule(string dtDay = "")
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

            ViewBag.today = dt.ToString("yyyy-MM-dd");
            ViewBag.prevday = dt.AddDays(-1).ToString("yyyy-MM-dd");
            ViewBag.nextday = dt.AddDays(1).ToString("yyyy-MM-dd");

            ScheduleList list = _sbiz.RetrieveScheduleList(dt, "Y");
            List<SportsTypeInfo> selectList = _sbiz.RetrieveSportType();

            ViewBag.list = list;
            ViewBag.selectList = selectList;

            return View();
        }

        public ActionResult ScheduleProcess(ScheduleInfo info)
        {
            string msg = "";

            if (info.ResultDetail != null)
            {
                info.ResultDetail = info.ResultDetail.Replace("$br$", "\n");
            }

            if (_sbiz.RegisterScheduleInfo(info))
            {
                msg = "등록 되었습니다.";
            }
            else
            {
                msg = "등록에 실패하였습니다.";
            }

            return Content(msg);
        }

        public ActionResult ScheduleUpdateProcess(ScheduleInfo info)
        {
            string msg = "";

            if (info.ResultDetail != null)
            {
                info.ResultDetail = info.ResultDetail.Replace("$br$", "\n");
            }

            if (_sbiz.UpdateScheduleInfo(info))
            {
                msg = "수정 되었습니다.";
            }
            else
            {
                msg = "수정에 실패하였습니다.";
            }

            return Content(msg);
        }

        public ActionResult ScheduleDeleteProcess(int idx)
        {
            string msg = "";            

            if (_sbiz.DeleteScheduleInfo(idx))
            {
                msg = "삭제 되었습니다.";
            }
            else
            {
                msg = "삭제에 실패하였습니다.";
            }

            return Content(msg);
        }

    }
}