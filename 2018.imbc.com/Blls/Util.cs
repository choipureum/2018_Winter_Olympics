using IMBC.FW.Util;
using System;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class Util
    {
        public static string defaultImg = "http://hdmall.imbc.com/images/default_imges_big.jpg"; //디폴트이미지

        public static string GetImgUrl(string imgUrl)
        {
            return (imgUrl == "") ? defaultImg : imgUrl;
        }


        public static string DisplayContentNumber(string contentNubmer)
        {
            if (contentNubmer == "")
                return "0회";

            try
            {
                if (contentNubmer.Substring(0, 1) != "0")
                    return contentNubmer + "회";
                else
                    return DisplayContentNumber(contentNubmer.Substring(1));
            }
            catch
            {
                return "특집 회";
            }
        }



        public static string DisplayDuration(string duration)
        {
            string playTime = duration;

            string[] arrTime = playTime.Split(':');

            if (playTime.Length == 8 && arrTime.Length == 3)
            {
                int hour = 0;
                int minute = 0;

                if (int.TryParse(arrTime[0], out hour) && int.TryParse(arrTime[1], out minute))
                {
                    playTime = (hour * 60 + minute).ToString();
                }
            }

            return playTime;
        }

        public static int MakeTimeToSecond(string sTime)
        {
            int nSec = 0;
            if (sTime.Length < 6)
                return nSec;

            try
            {
                TimeSpan tsStart = new TimeSpan(Convert.ToInt32(sTime.Substring(0, 2)),
                        Convert.ToInt32(sTime.Substring(2, 2)),
                        Convert.ToInt32(sTime.Substring(4, 2)));
                nSec = (int)tsStart.TotalSeconds;
            }
            catch { }

            return nSec;
        }

        public static string ReplaceContent(string szContent, string szNewsWriter, string szNewsEtcInfo, string szVideoWriter, string szPhotoWriter, string NickName)
        {

            szContent = IMBC.FW.Util.WebUtil.DecodeHTML(szContent.Replace("\r\n", "<br>").Replace("\n", "<br>"));

            //작성자 정보 보임
            string szWriter = "";
            if (szNewsWriter.IndexOf("MBC") < 0 && szNewsWriter.Length > 0)
            {
                szWriter += "iMBC " + szNewsWriter.Replace("iMBC 편집팀", " 편집팀");
            }
            else
            {
                szWriter += szNewsWriter;
            }

            if (szNewsEtcInfo.IndexOf("|") >= 0)
            {
                string[] azEtcInfo = szNewsEtcInfo.Split('|');

                if (azEtcInfo.Length == 4)
                {
                    if (azEtcInfo[1].Length > 0)
                    {
                        szWriter += " | " + azEtcInfo[0] + " : " + azEtcInfo[1];
                    }

                    if (azEtcInfo[2].Length > 0)
                    {
                        szWriter += "<br> 내용 : " + azEtcInfo[2] + " <a href='" + azEtcInfo[3] + "'>" + azEtcInfo[3] + "</a> ";
                    }
                }
            }
            else
            {

                if (szVideoWriter.Length > 0)
                {
                    szWriter += (szWriter.Length > 3 ? " | " : "") + "영상 " + szVideoWriter;
                }
                if (szPhotoWriter.Length > 0)
                {
                    szWriter += (szWriter.Length > 3 ? " | " : "") + "사진 " + szPhotoWriter;
                }
                if (szNewsEtcInfo.Length > 0)
                {
                    szWriter += (szWriter.Length > 3 ? " | " : "") + szNewsEtcInfo;
                }
            }

            if(NickName != "IMNEWS")
            {
                return szContent + "<br /><br /><p class=\"copy\">" + szWriter + "</p><br /><p class=\"copy\">※ 이 콘텐츠는 저작권법에 의하여 보호를 받는바, 무단 전재 복제, 배포 등을 금합니다. </p>";
            }

            return szContent;

        }

        public static void CheckAdmin()
        {
            UserInfo uInfo = new UserInfo();
            
            if (!uInfo.IsLogin)
            {
                uInfo.RedirectLoginPage();
                HttpContext.Current.Response.End();
            }
            else
            {
                if (!(uInfo.UserID == "sports06" || uInfo.UserID == "gkstkddms1" || uInfo.UserID == "sdocgu" || uInfo.UserID == "punklamb" || uInfo.UserID == "poo1994" || uInfo.UserID == "anna"))
                {                    
                    HttpContext.Current.Response.Redirect("/");
                    HttpContext.Current.Response.End();
                }
            }
            
        }
    }
}