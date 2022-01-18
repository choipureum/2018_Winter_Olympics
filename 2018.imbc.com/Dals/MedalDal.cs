using _2018.imbc.com.Models;
using IMBC.FW.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace _2018.imbc.com.Dals
{
    public class MedalDal
    {
        private readonly string MedalConn = WebConfigurationManager.AppSettings["ConnectStringMedals"];

        /// <summary>
        /// 국가별 메달 순위
        /// </summary>
        /// <param name="opt"> A:관리자 / S:서비스 / P:미리보기</param>
        /// <param name="olympicCode"> 올림픽 코드(BJ2020) 베이징 동계올림픽 </param>
        /// <returns></returns>

        public List<OlpMedalCount> RetrieveMedalCountList(string opt, string olympicCode)
        {
            SqlConnection conn = DbConnection.DbConn(MedalConn);
            SQLHelper.OpenConnection(conn);

            List<OlpMedalCount> list = new List<OlpMedalCount>();

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Olympic@RetrieveMedalCountList",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@Opt", SqlDbType.Char).Value = opt;
            sqlCmd.Parameters.Add("@OlympicCode", SqlDbType.VarChar, 20).Value = olympicCode;
            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            while (reader.Read())
            {
                OlpMedalCount data = new OlpMedalCount
                {
                    CountID = (int)reader["CountID"],
                    Rank = int.Parse(reader["Rank"].ToString()),
                    NationalID = (int)reader["NationalID"],
                    NationalName = reader["NationalName"].ToString(),
                    NationalImg = reader["NationalImg"].ToString(),
                    Gold = (int)reader["Gold"],
                    Silver = (int)reader["Silver"],
                    Bronze = (int)reader["Bronze"],
                    Total = (int)reader["Total"],
                    OlympicCode = reader["OlympicCode"].ToString(),
                };
                list.Add(data);
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);
            return list;
        }

        /// <summary>
        /// 올림픽 리스트
        /// </summary>
        /// <returns></returns>
        public List<OlympicCodeInfo> RetrieveOlympicList()
        {
            SqlConnection conn = DbConnection.DbConn(MedalConn);
            SQLHelper.OpenConnection(conn);

            List<OlympicCodeInfo> list = new List<OlympicCodeInfo>();

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Olympic@RetrieveOlympicList",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            while (reader.Read())
            {
                OlympicCodeInfo data = new OlympicCodeInfo
                {
                    OlympicCode = reader["OlympicCode"].ToString(),
                    OlympicID = (int)reader["OlympicID"],
                    OlympicName = reader["OlympicName"].ToString(),
                    OlympicDate = (DateTime)reader["OlympicDate"],
                };
                list.Add(data);
            }
            reader.Close();
            SQLHelper.CloseConnection(conn);
            return list;
        }

        /// <summary>
        /// 국가별 메달 순위 등록
        /// </summary>
        /// <returns></returns>
        public bool RegisterMedalCount(OlpMedalCount data)
        {
            SqlConnection conn = DbConnection.DbConn(MedalConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Olympic@RegisterMedalCount",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add("@OlympicCode", SqlDbType.VarChar, 20).Value = data.OlympicCode;
            sqlCmd.Parameters.Add("@NationalID", SqlDbType.Int).Value = data.NationalID;
            sqlCmd.Parameters.Add("@Gold", SqlDbType.Int).Value = data.Gold;
            sqlCmd.Parameters.Add("@Silver", SqlDbType.Int).Value = data.Silver;
            sqlCmd.Parameters.Add("@Bronze", SqlDbType.Int).Value = data.Bronze;

            bool rtn = SQLHelper.ExecuteNonQuery(conn, sqlCmd);
            SQLHelper.CloseConnection(conn);
            return rtn;
        }

        public OlpMedalCount RetrieveMedalCountListForMainKorea()
        {
            SqlConnection conn = DbConnection.DbConn(MedalConn);
            SQLHelper.OpenConnection(conn);

            OlpMedalCount info = new OlpMedalCount();
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Olympic@RetrieveMedalCountListForMainKOREA",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            if (reader.Read())
            {
                info = new OlpMedalCount
                {
                    CountID = (int)reader["CountID"],
                    OlympicCode = reader["OlympicCode"].ToString(),
                    Rank = int.Parse(reader["Rank"].ToString()),
                    NationalID = (int)reader["NationalID"],
                    Gold = (int)reader["Gold"],
                    Silver = (int)reader["Silver"],
                    Bronze = (int)reader["Bronze"],
                    Total = (int)reader["Total"],
                    uptTime = ((DateTime)reader["uptTime"]).ToString("yyyy-MM-dd HH:mm")
                };
            }
            reader.Close();
            SQLHelper.CloseConnection(conn);

            return info;
        }

        public string RetrieveUpdateTime(string timeDept, string olympicCode)
        {
            SqlConnection conn = DbConnection.DbConn(MedalConn);
            SQLHelper.OpenConnection(conn);

            string updatTime = "";
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Olympic@RetrieveUpdateTime",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@TimeDept", SqlDbType.Char).Value = timeDept;
            sqlCmd.Parameters.Add("@OlympicCode", SqlDbType.VarChar, 20).Value = olympicCode;
            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);
            if (reader.Read())
            {
                updatTime = ((DateTime)reader["RegDate"]).ToString("yyyy-MM-dd HH:mm");
            }
            reader.Close();
            SQLHelper.CloseConnection(conn);
            return updatTime;
        }
    }
}