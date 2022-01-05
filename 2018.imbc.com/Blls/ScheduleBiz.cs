using _2018.imbc.com.Dals;
using _2018.imbc.com.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace _2018.imbc.com.Blls
{
    public class ScheduleBiz
    {
        private readonly ScheduleDal _dal;

        public ScheduleBiz()
        {
            _dal = new ScheduleDal();
        }


        public ScheduleList RetrieveScheduleList(DateTime dtDay, string isAdmin)
        {
            ScheduleList list = new ScheduleList();

            if (isAdmin == "N")
            {
                string cachenm = "RetrieveScheduleListForAdminPC2018_"+dtDay;
                list = (ScheduleList)HttpContext.Current.Cache[cachenm];

                if (list == null)
                {
                    list = _dal.RetrieveScheduleListForAdmin(dtDay);
                    HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
                }
            }
            else
            {
                list = _dal.RetrieveScheduleListForAdmin(dtDay);
            }

            return list;
        }


        public bool RegisterScheduleInfo(ScheduleInfo sc)
        {
            return _dal.RegisterScheduleInfo(sc);
        }

        public bool DeleteScheduleInfo(int scPk)
        {
            return _dal.DeleteScheduleInfo(scPk);
        }

        public bool UpdateScheduleInfo(ScheduleInfo scInfo)
        {
            return _dal.UpdateScheduleInfo(scInfo);
        }

        public List<SportsTypeInfo> RetrieveSportType()
        {
            string cachenm = "RetrieveSportTypePC2018";
            List<SportsTypeInfo> list = (List<SportsTypeInfo>)HttpContext.Current.Cache[cachenm];

            if (list == null)
            {
                list = _dal.RetrieveSportType();
                HttpContext.Current.Cache.Insert(cachenm, list, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }

            return list;
        }



    }
}