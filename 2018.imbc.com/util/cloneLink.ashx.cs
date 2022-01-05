using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
namespace _2018.imbc.com.util
{
    /// <summary>
    /// cloneLink의 요약 설명입니다.
    /// </summary>
    public class cloneLink : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool bSucess = true;
            string szDummyUrl = "";
            try
            {
                String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(ip))
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }


                //gep ip 체크
                DataSet ds = new DataSet();
                ds.ReadXml("http://ipcheck.imbc.com/api/geoip.aspx?IP=" + ip);
                DataView dv = ds.Tables["Data"].DefaultView;
                if (dv[0]["Country"].ToString() != "KR")
                {
                    string u = context.Request.ServerVariables["HTTP_USER_AGENT"];
                    Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
                    {
                        context.Response.Write("http://img.imbc.com/player/onair/images/onair_notice.jpg");
                    }
                    else
                    {
                        context.Response.ContentType = "text/xml";
                        context.Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?> ");
                        context.Response.Write("<imgurl>http://img.imbc.com/player/onair/images/onair_notice.jpg</imgurl>");
                    }
                }
                else
                {
                    string szUrl = (context.Request["dest_url"] != null ? context.Request["dest_url"].ToString() : "");

                    if (szUrl.Length == 0)
                    {
                        bSucess = false;
                    }
                    else
                    {
                        if (szUrl.ToLower().IndexOf("http://vodmall.imbc.com") != 0 && szUrl.ToLower().IndexOf("http://adcounter.imbc.com") != 0)
                        {
                            bSucess = false;
                        }
                        else
                        {
                            szDummyUrl = "dest_url=" + context.Server.UrlEncode(szUrl) + "&";

                            string szPostData = new System.IO.StreamReader(context.Request.InputStream).ReadToEnd();

                            if (szPostData.Length > 0)
                            {
                                szPostData = szPostData.Replace(szDummyUrl, "");

                                byte[] sendData = UTF8Encoding.UTF8.GetBytes(szPostData);

                                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(szUrl);
                                request.Credentials = CredentialCache.DefaultCredentials;
                                request.Method = "POST";
                                request.ContentLength = sendData.Length;
                                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                request.KeepAlive = true;
                                request.UserAgent = context.Request.UserAgent;
                                //request.Headers.Add("ip", context.Request.UserHostAddress);

                                Stream requestStream = request.GetRequestStream();
                                requestStream.Write(sendData, 0, sendData.Length);
                                requestStream.Close();

                                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
                                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));    // Encoding.GetEncoding("EUC-KR")    
                                string szXml = streamReader.ReadToEnd();
                                streamReader.Close();
                                httpWebResponse.Close();
                                context.Response.Write(szXml);
                            }
                            else
                            {
                                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(szUrl + "?" + context.Request.QueryString.ToString().Replace(szDummyUrl, ""));
                                request.Credentials = CredentialCache.DefaultCredentials;
                                request.UserAgent = context.Request.UserAgent;
                                //request.Headers.Add("ip", context.Request.UserHostAddress);

                                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                Stream stream = response.GetResponseStream();

                                if (response.ContentLength > 0)
                                {
                                    StreamReader reader = new StreamReader(stream);
                                    string szXml = reader.ReadToEnd();
                                    context.Response.Write(szXml);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/xml";
                context.Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?> ");
                context.Response.Write("<Msg>" + ex.Message + "</Msg> ");
            }

            if (!bSucess)
            {
                context.Response.ContentType = "text/xml";
                context.Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?> ");
                context.Response.Write("<Msg>error</Msg> ");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}