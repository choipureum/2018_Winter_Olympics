using _2018.imbc.com.Blls;
using _2018.imbc.com.Models;
using IMBC.FW.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace _2018.imbc.com.Dals
{
    public class VodDal
    {
        private readonly string AdamConn = WebConfigurationManager.AppSettings["ConnectStringAdams"];

        public ContentInfo RetrieveContentInfo(string broadCastId)
        {

            ContentInfo cInfo = new ContentInfo();
            SqlConnection conn = DbConnection.DbConn(AdamConn);

            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "vod@USP_ContentInfo_ForSepcailProgram",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@broadcastid", SqlDbType.BigInt).Value = broadCastId;            

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            if (reader.Read())
            {
                cInfo.ContentTitle = reader["Title"].ToString();
                cInfo.HitCount = int.Parse(reader["HITCOUNT"].ToString()).ToString("#,##0");
                cInfo.BroadDate = reader["BroadDate"].ToString();

            }
            reader.Close();
            SQLHelper.CloseConnection(conn);

            return cInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="order"></param>
        /// <param name="gubun">1:하이라이트 2:다시보기 3:스페셜 4:어록 5:예고 6:홍보영상 7:영광의 순간</param>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="opt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ContentList RetrieveContentList(int curPage, int pageSize, int order, int gubun, string keyword, string type, string opt, string date)
        {

            ContentList list = list = new ContentList { List = new List<ContentInfo>() };

            SqlConnection conn = DbConnection.DbConn(AdamConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "vod@USP_ContentList_ForSepcailProgram",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@broadcastid", SqlDbType.BigInt).Value = 1003608100000100000;  //평창
            sqlCmd.Parameters.Add("@curPage", SqlDbType.Int).Value = curPage;
            sqlCmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
            sqlCmd.Parameters.Add("@order", SqlDbType.Int).Value = order;
            sqlCmd.Parameters.Add("@gubun", SqlDbType.Int).Value = gubun;
            sqlCmd.Parameters.Add("@keyword", SqlDbType.VarChar).Value = keyword;
            sqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
            sqlCmd.Parameters.Add("@opt", SqlDbType.VarChar).Value = opt;
            sqlCmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            if (reader.Read())
                list.TotalCount = (int)reader[0];

            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    ContentInfo info = new ContentInfo
                    {
                        ProgramTitle = reader["PROGRAMTITLE"].ToString(),
                        ContentTitle = reader["TITLE"].ToString(),
                        BroadcastID = reader["BROADCASTID"].ToString(),
                        ProgramBroadcastID = reader["ProgramBroadcastID"].ToString(),
                        ContentNumber = reader["ContentNumber"].ToString(),
                        BroadDate = ((DateTime)reader["BroadDate"]).ToString("yyyy-MM-dd"),
                        ImgUrl_Big = Util.GetImgUrl(reader["PICTURE"].ToString()),
                        HitCount = int.Parse(reader["HITCOUNT"].ToString()).ToString("#,##0"),
                        itemid = int.Parse(reader["itemid"].ToString()),
                        SubTitle = reader["SUBTITLE"].ToString()
                    };
                    list.List.Add(info);
                }
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);

            return list;
        }


    }
}