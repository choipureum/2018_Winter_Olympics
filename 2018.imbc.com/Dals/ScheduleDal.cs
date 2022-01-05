using _2018.imbc.com.Models;
using IMBC.FW.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _2018.imbc.com.Dals
{
    public class ScheduleDal
    {
        public ScheduleList RetrieveScheduleListForAdmin(DateTime dtDay)
        {
            ScheduleList scList = new ScheduleList();
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetieveScheduleList",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dtDay;

            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);
            if (reader.Read())
            {
                scList.TotalCount = (int)reader["count"];
                scList.update = reader[1].ToString();
            }

            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    ScheduleInfo scInfo = new ScheduleInfo
                    {
                        SchedulePK = (int)reader["ScheduleIdx"],
                        DateString = reader["DateString"].ToString(),
                        StartTime = reader["StartTime"].ToString(),
                        EndTime = reader["EndTime"].ToString(),
                        SportType = reader["SportType"].ToString(),
                        DetailSportName = reader["DetailSportType"].ToString(),
                        PlayerName = reader["PlayerName"].ToString(),
                        ResultInfo = reader["ResultInfo"].ToString(),
                        ResultDetail = reader["ResultDetail"].ToString(),
                        VodUrl = reader["VodUrl"].ToString(),
                        NewsUrl = reader["NewsUrl"].ToString(),
                        SportName = reader["SportName"].ToString()
                    };

                    try
                    {
                        DateTime sdt = DateTime.Parse(scInfo.DateString + " " + scInfo.StartTime);
                        DateTime edt = DateTime.Parse(scInfo.DateString + " " + scInfo.EndTime);

                        
                        if (DateTime.Now < sdt) scInfo.NowState = "1"; //경기 예정
                        else if (DateTime.Now >= sdt && DateTime.Now <= edt) scInfo.NowState = "2";  //경기중
                        else if (DateTime.Now > edt) scInfo.NowState = "3";  //지난 경기
                        
                        /*
                        if (DateTime.Now.AddDays(15) < sdt) scInfo.NowState = "1"; //경기 예정
                        else if (DateTime.Now.AddDays(15) >= sdt && DateTime.Now.AddDays(15) <= edt) scInfo.NowState = "2";  //경기중
                        else if (DateTime.Now.AddDays(15) > edt) scInfo.NowState = "3";  //지난 경기
                        */
                    }
                    catch
                    {
                        scInfo.NowState = "1";
                    }

                    scList.Add(scInfo);
                }
            }

            reader.Close();

            return scList;
        }

        /// <summary>
        /// 편성 등록
        /// </summary>
        /// <param name="sc"></param>
        public bool RegisterScheduleInfo(ScheduleInfo sc)
        {
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RegisterScheduleInfo",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@datestring", SqlDbType.VarChar).Value = sc.DateString;
            sqlCmd.Parameters.Add("@starttime", SqlDbType.VarChar).Value = sc.StartTime;
            sqlCmd.Parameters.Add("@endtime", SqlDbType.VarChar).Value = sc.EndTime;
            sqlCmd.Parameters.Add("@sporttype", SqlDbType.Int).Value = sc.SportType;
            sqlCmd.Parameters.Add("@DetailSportType", SqlDbType.NVarChar).Value = sc.DetailSportName;
            sqlCmd.Parameters.Add("@playername", SqlDbType.NVarChar).Value = sc.PlayerName;
            sqlCmd.Parameters.Add("@ResultInfo", SqlDbType.NVarChar).Value = sc.ResultInfo;
            sqlCmd.Parameters.Add("@ResultDetail", SqlDbType.NVarChar).Value = sc.ResultDetail;
            sqlCmd.Parameters.Add("@VodUrl", SqlDbType.VarChar).Value = sc.VodUrl;
            sqlCmd.Parameters.Add("@NewsUrl", SqlDbType.VarChar).Value = sc.NewsUrl;

            return SQLHelper.ExecuteNonQuery(sqlCmd);
        }

        /// <summary>
        /// 편성 삭제
        /// </summary>
        /// <param name="scPk"></param>
        /// <returns></returns>
        public bool DeleteScheduleInfo(int scPk)
        {
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "DeleteScheduleInfo",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@PkIdx", SqlDbType.Int).Value = scPk;

            return SQLHelper.ExecuteNonQuery(sqlCmd);
        }

        /// <summary>
        /// 편성 정보 수정
        /// </summary>
        /// <param name="scInfo"></param>
        public bool UpdateScheduleInfo(ScheduleInfo scInfo)
        {
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "UpdateScheduleInfo",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@pkidx", SqlDbType.Int).Value = scInfo.SchedulePK;
            sqlCmd.Parameters.Add("@starttime", SqlDbType.VarChar).Value = scInfo.StartTime;
            sqlCmd.Parameters.Add("@endtime", SqlDbType.VarChar).Value = scInfo.EndTime;
            sqlCmd.Parameters.Add("@sporttype", SqlDbType.Int).Value = scInfo.SportType;
            sqlCmd.Parameters.Add("@DetailSportType", SqlDbType.NVarChar).Value = scInfo.DetailSportName;
            sqlCmd.Parameters.Add("@playername", SqlDbType.NVarChar).Value = scInfo.PlayerName;
            sqlCmd.Parameters.Add("@ResultInfo", SqlDbType.NVarChar).Value = scInfo.ResultInfo;
            sqlCmd.Parameters.Add("@ResultDetail", SqlDbType.NVarChar).Value = scInfo.ResultDetail;
            sqlCmd.Parameters.Add("@VodUrl", SqlDbType.VarChar).Value = scInfo.VodUrl;
            sqlCmd.Parameters.Add("@NewsUrl", SqlDbType.VarChar).Value = scInfo.NewsUrl;

            return SQLHelper.ExecuteNonQuery(sqlCmd);
        }

        public List<SportsTypeInfo> RetrieveSportType()
        {
            List<SportsTypeInfo> list = new List<SportsTypeInfo>();

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveSportTypeInfo",
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);

            while (reader.Read())
            {
                SportsTypeInfo info = new SportsTypeInfo
                {
                    SportType = (int)reader["SportType"],
                    SportName = reader["SportName"].ToString()
                };

                list.Add(info);
            }
            return list;
        }
    }
}