using _2018.imbc.com.Models;
using IMBC.FW.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _2018.imbc.com.Dals
{
    public class NoticeDal
    {
        public bool RegisterNotice(int Seq, string Title, string IsDel)
        {
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RegisterNotice",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add("@seq", SqlDbType.Int).Value = Seq;
            sqlCmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = Title;
            sqlCmd.Parameters.Add("@isdel", SqlDbType.Char).Value = IsDel;

            return SQLHelper.ExecuteNonQuery(sqlCmd);
        }

        public NoticeList RetrieveNoticeList(string isAdmin)
        {
            NoticeList list = list = new NoticeList { List = new List<NoticeInfo>() };

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveNoticeList",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add("@isadmin", SqlDbType.Char, 1).Value = isAdmin;

            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);

            while (reader.Read())
            {
                list.OnAir = reader["OnAir"].ToString();
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    NoticeInfo data = new NoticeInfo()
                    {
                        Seq = int.Parse(reader["Seq"].ToString()),
                        Title = reader["Title"].ToString(),
                        IsDel = reader["IsDel"].ToString()
                    };
                    list.List.Add(data);
                }
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 국가별 메달 순위
        /// </summary>
        /// <param name="opt"> A:관리자 / S:서비스 / P:미리보기 </param>
        /// <returns></returns>

        public List<MedalCount> RetrieveMedalCountList(string opt)
        {
            List<MedalCount> list = new List<MedalCount>();

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveMedalCountList",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@Opt", SqlDbType.Char).Value = opt;
            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);

            while (reader.Read())
            {
                MedalCount data = new MedalCount
                {
                    CountID = (int)reader["CountID"],
                    Rank = int.Parse(reader["Rank"].ToString()),
                    NationalID = (int)reader["NationalID"],
                    NationalName = reader["NationalName"].ToString(),
                    NationalImg = reader["NationalImg"].ToString(),
                    Gold = (int)reader["Gold"],
                    Silver = (int)reader["Silver"],
                    Bronze = (int)reader["Bronze"],
                    Total = (int)reader["Total"]
                };
                //data.RegDate = reader["RegDate"].ToString();
                //data.ModDate = ((DateTime)reader["ModDate"]).ToString("yyyyMMddHHmmss");

                list.Add(data);
            }

            reader.Close();
            return list;
        }

        /// <summary>
        /// 국가별 메달 순위 등록
        /// </summary>
        /// <returns></returns>
        public bool RegisterMedalCount(MedalCount data)
        {
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RegisterMedalCount",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add("@NationalID", SqlDbType.Int).Value = data.NationalID;
            sqlCmd.Parameters.Add("@Gold", SqlDbType.Int).Value = data.Gold;
            sqlCmd.Parameters.Add("@Silver", SqlDbType.Int).Value = data.Silver;
            sqlCmd.Parameters.Add("@Bronze", SqlDbType.Int).Value = data.Bronze;

            return SQLHelper.ExecuteNonQuery(sqlCmd);
        }

        public MedalCount RetrieveMedalCountListForMainKorea()
        {
            MedalCount info = new MedalCount();
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveMedalCountListForMainKOREA",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);

            if (reader.Read())
            {
                info = new MedalCount
                {
                    CountID = (int)reader["CountID"],
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

            return info;
        }

        public string RetrieveUpdateTime(string timeDept)
        {
            string updatTime = "";
            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveUpdateTime",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@TimeDept", SqlDbType.Char).Value = timeDept;
            SqlDataReader reader = SQLHelper.ExecuteReader(sqlCmd);
            if (reader.Read())
            {
                updatTime = ((DateTime)reader["RegDate"]).ToString("yyyy-MM-dd HH:mm");
            }
            reader.Close();
            return updatTime;
        }
    }
}