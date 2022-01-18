using _2018.imbc.com.Blls;
using _2018.imbc.com.Models;
using IMBC.FW.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018.imbc.com.Controllers
{
    public class MedalController : Controller
    {
        private readonly MedalBiz _biz;

        public MedalController()
        {
            _biz = new MedalBiz();
        }

        [HttpGet]
        public ActionResult Index(string olympicCode = "")
        {
            List<OlpMedalCount> list = _biz.RetrieveMedalCountList("A", olympicCode);
            List<OlympicCodeInfo> olympicList = _biz.RetrieveOlympicList();

            ViewBag.list = list;

            ViewBag.olympicList = olympicList;
            ViewBag.OlympicCode = olympicCode;
            ViewBag.OlympicName = (olympicCode != "") ? olympicList.Where(x => x.OlympicCode == olympicCode).FirstOrDefault().OlympicName : "";
            ViewBag.time = _biz.RetrieveUpdateTime("C", olympicCode);

            return View();
        }

        [HttpPost]
        public ActionResult MedalProcess(FormCollection formCollection)
        {
            string msg = "수정되었습니다.";
            string olympicCode = "";

            for (int i = 0; i < 250; i++)
            {
                string gold = WebUtil.GetRequestForm("Gold_" + i, "");

                if (gold != "")
                {
                    if (olympicCode == "")
                    {
                        olympicCode = WebUtil.GetRequestForm("OlympicCode", "");
                    }
                    OlpMedalCount data = new OlpMedalCount();
                    data.OlympicCode = olympicCode;
                    data.NationalID = i;
                    data.Gold = int.Parse(gold);
                    data.Silver = int.Parse(WebUtil.GetRequestForm("Silver_" + i, ""));
                    data.Bronze = int.Parse(WebUtil.GetRequestForm("Bronze_" + i, ""));

                    _biz.RegisterMedalCount(data);
                }
            }

            return Content("<script>alert('" + msg + "');location.href='/Medal/Index?OlympicCode=" + olympicCode + "';</script>");
        }
    }
}