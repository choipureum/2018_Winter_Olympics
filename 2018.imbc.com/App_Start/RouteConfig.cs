using System.Web.Mvc;
using System.Web.Routing;

namespace _2018.imbc.com
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "mMedalRank",
                url: "m/MedalRank",
                defaults: new { controller = "Home", action = "mMedalRank" }
            );

            routes.MapRoute(
                name: "mScheduleList",
                url: "m/ScheduleList",
                defaults: new { controller = "Home", action = "mScheduleList" }
            );

            routes.MapRoute(
                name: "mnewsview",
                url: "m/News/View",
                defaults: new { controller = "Home", action = "mNewsView" }
            );

            routes.MapRoute(
                name: "mnews",
                url: "m/News/{page}/{sort}",
                defaults: new { controller = "Home", action = "mNews", page = UrlParameter.Optional, sort = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "mvod",
                url: "m/Vod",
                defaults: new { controller = "Home", action = "mVod2" }
            );

            routes.MapRoute(
                name: "mMain",
                url: "m/Main",
                defaults: new { controller = "Home", action = "mIndex2"}
            );

            routes.MapRoute(
                name: "MedalRank",
                url: "MedalRank",
                defaults: new { controller = "Home", action = "MedalRank" }
            );

            routes.MapRoute(
                name: "ScheduleList",
                url: "ScheduleList",
                defaults: new { controller = "Home", action = "ScheduleList" }
            );

            routes.MapRoute(
                name: "NewsView",
                url: "News/View",
                defaults: new { controller = "Home", action = "NewsView"}
            );

            routes.MapRoute(
                name: "News",
                url: "News/{id}",
                defaults: new { controller = "Home", action = "News", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Vod",
                url: "Vod",
                defaults: new { controller = "Home", action = "Vod2" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index2"}
            );

            
        }
    }
}
