using _2018.imbc.com.Blls;
using _2018.imbc.com.Models;
using IMBC.FW.DB;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace _2018.imbc.com.Dals
{
    public class NewsDal
    {
        private readonly string ENewsConn = WebConfigurationManager.AppSettings["ConnectStringENews"];
        private readonly string NewsConn = WebConfigurationManager.AppSettings["ConnectStringNews"];

        //뉴스 등록
        public bool RegisterNews(NewsInfo o)
        {
            SqlConnection conn = DbConnection.DbConn(NewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "USP_ImnewsGate_Olympic",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add("@artid", SqlDbType.BigInt).Value = o.artid;
            sqlCmd.Parameters.Add("@title", SqlDbType.VarChar).Value = o.title;
            sqlCmd.Parameters.Add("@category", SqlDbType.VarChar).Value = o.category;
            sqlCmd.Parameters.Add("@arttype", SqlDbType.VarChar).Value = o.arttype;
            sqlCmd.Parameters.Add("@imgurl", SqlDbType.VarChar).Value = o.imgurl;
            sqlCmd.Parameters.Add("@vodurl", SqlDbType.VarChar).Value = o.vodurl;
            sqlCmd.Parameters.Add("@artcont", SqlDbType.Text).Value = o.artcont;
            sqlCmd.Parameters.Add("@author", SqlDbType.VarChar).Value = o.author;
            sqlCmd.Parameters.Add("@pubDate", SqlDbType.VarChar).Value = o.pubDate;
            sqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = o.type;
            sqlCmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = "pyeongchan";
            sqlCmd.Parameters.Add("@orgurl", SqlDbType.VarChar).Value = o.orgurl;

            bool b = SQLHelper.ExecuteNonQuery(conn, sqlCmd);
            SQLHelper.CloseConnection(conn);


            return b;
        }


        //뉴스 리스트 가져오기
        public NewsList RetrieveImnewsTypeList(string type, int page, int size, string keyword)
        {
            NewsList list = new NewsList();

            SqlConnection conn = DbConnection.DbConn(NewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "olympic@USP_News_Type_Select",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
            sqlCmd.Parameters.Add("@page", SqlDbType.Int).Value = page;
            sqlCmd.Parameters.Add("@size", SqlDbType.Int).Value = size;
            sqlCmd.Parameters.Add("@keyword", SqlDbType.VarChar).Value = keyword;
            sqlCmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = "pyeongchan";

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            while (reader.Read())
            {
                list.TotalCount = (int)reader["cou"];
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    NewsInfo data = new NewsInfo()
                    {
                        artid = reader["artid"].ToString(),
                        title = reader["title"].ToString(),
                        category = reader["category"].ToString(),
                        arttype = reader["arttype"].ToString(),
                        imgurl = reader["imgurl"].ToString(),
                        vodurl = reader["vodurl"].ToString(),
                        artcont = reader["artcont"].ToString(),
                        author = reader["author"].ToString(),
                        pubDate = reader["pubDate"].ToString(),
                        type = reader["type"].ToString(),
                        appwrite = reader["appwrite"].ToString(),
                        orgurl = reader["orgurl"].ToString()
                    };
                    list.Add(data);
                }
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);

            return list;
        }


        //뉴스로그 등록
        public bool RegisterNewsLog(string opt, int newsIdx)
        {
            SqlConnection conn = DbConnection.DbConn(ENewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand { CommandText = "RegisterNewsLog", CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.Add("@NewsIdx ", SqlDbType.Int).Value = newsIdx;
            sqlCmd.Parameters.Add("@Opt", SqlDbType.Char).Value = opt;

            bool rtn = SQLHelper.ExecuteNonQuery(conn, sqlCmd);

            SQLHelper.CloseConnection(conn);

            return rtn;
        }


        //많이본 뉴스 목록
        public List<NewsLog> RetrieveNewsLog(int top)
        {
            SqlConnection conn = DbConnection.DbConn(ENewsConn);
            SQLHelper.OpenConnection(conn);

            List<NewsLog> list = new List<NewsLog>();


            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "RetrieveNewsLog",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@top", SqlDbType.Int).Value = top;

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            while (reader.Read())
            {
                NewsLog data = new NewsLog
                {
                    opt = reader["opt"].ToString(),
                    newsIdx = reader["newsIdx"].ToString(),
                    hit = (int)reader["hit"]
                };

                list.Add(data);
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);

            return list;

        }


        //imnews 기사 정보 가져오기
        public NewsSimple RetrievImNewsIdx(int newsIdx)
        {

            NewsSimple data = new NewsSimple();

            SqlConnection conn =
                DbConnection.DbConn(NewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "olympic@USP_News_Artid_Select",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@artid", SqlDbType.Int).Value = newsIdx;
            sqlCmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = "PC2018";

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            if (reader.Read())
            {
                data.title = reader["title"].ToString();
                data.orgurl = reader["orgurl"].ToString();
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);

            return data;
        }

        //연예뉴스 기사 정보 가져오기
        public NewsSimple RetrievENewsIdx(int newsIdx)
        {
            NewsSimple data = new NewsSimple();
            SqlConnection conn = DbConnection.DbConn(ENewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Ens@RetrieveSearchNewsInfoForRio2016",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@newsIdx", SqlDbType.Int).Value = newsIdx;

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);



            if (reader.Read())
            {
                data.title = reader["title"].ToString();
                if (reader["NickName"].ToString() != "IMNEWS")
                {                    
                    data.orgurl = "";
                }
                else
                {
                    data.orgurl = reader["OrgUrl"].ToString();
                }

                string fContent = Util.ReplaceContent(reader["Content"].ToString(), reader["Writer"].ToString(),
                                                      reader["EtcInfo"].ToString(), reader["VideoWriter"].ToString(),
                                                      reader["PhotoWriter"].ToString(), reader["NickName"].ToString());
                data.content = fContent;
                data.pubDate = reader["PublicationDate"].ToString();
                data.vodurl = reader["vodurl"].ToString();
                data.author = reader["author"].ToString();
                data.IsVideo = int.Parse(reader["IsVideo"].ToString());
                data.NickName = reader["NickName"].ToString();
                data.NewsImg = reader["RectangleImg"].ToString();
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);


            return data;
        }


        /// <summary>
        /// 연예뉴스 리스트 가져오기
        /// </summary>
        /// <param name="page">페이지</param>
        /// <param name="pageSize">페이지 사이즈</param>
        /// <returns>연예뉴스 리스트</returns>
        public EnewsList RetrievENewsList(int page, int pageSize, int onlyEnews, int sort)
        {
            if (pageSize > 50) pageSize = 50;
            EnewsList list = new EnewsList();
            SqlConnection conn = DbConnection.DbConn(ENewsConn);
            SQLHelper.OpenConnection(conn);

            SqlCommand sqlCmd = new SqlCommand
            {
                CommandText = "Ens@RetrieveSearchNewsListForPC2018",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.Add("@page", SqlDbType.Int).Value = page;
            sqlCmd.Parameters.Add("@size", SqlDbType.Int).Value = pageSize;
            sqlCmd.Parameters.Add("@onlyEnews", SqlDbType.Int).Value = onlyEnews;
            sqlCmd.Parameters.Add("@sort", SqlDbType.Int).Value = sort;

            SqlDataReader reader = SQLHelper.ExecuteReader(conn, sqlCmd);

            while (reader.Read())
            {
                list.TotalCount = (int)reader["TotalCount"];
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    EnewsInfo info = new EnewsInfo
                    {
                        Idx = int.Parse(reader["NewsIdx"].ToString()),
                        Title = reader["Title"].ToString(),
                        ImgUrl = reader["SquareImg"].ToString(),
                        ImgUrlR = reader["RectangleImg"].ToString(),
                        Summary = reader["Summary"].ToString(),
                        PublicationDate = reader["PublicationDate"].ToString(),
                        Nickname = reader["NickName"].ToString(),
                        OrgUrl = reader["OrgUrl"].ToString()
                    };
                    list.Add(info);
                }
            }

            reader.Close();
            SQLHelper.CloseConnection(conn);

            return list;
        }
    }
}