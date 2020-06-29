using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace rainfalls.DataSource.Remote
{
    public delegate void OnComplete(string id,string data);
    public delegate void OnTaskCancel();
    public delegate void OnRequest();
    public delegate void OnException();
    public class HttpAsyncAliyun
    {
        private static HttpAsyncAliyun uniqueInstance;
        private static readonly object padlock = new object();
        HttpClient m_pHttpClient;
        public event OnComplete onCompleteEvent;
        public event OnTaskCancel onTaskCancelEvent;
        public event OnRequest onRequestExceptionEvent;
        public event OnException onExceptionEvent;
        public HttpAsyncAliyun()
        {

            m_pHttpClient = new HttpClient();
            //m_pHttpClient.Timeout = new TimeSpan(30 * 1000);           //m_pHttpClient.Timeout.
        }
        //public static HttpAsyncAliyun getInstance()
        //{
        //    if (uniqueInstance == null)
        //    {
        //        lock (padlock)
        //        {
        //            if (uniqueInstance == null)
        //            {
        //                uniqueInstance = new HttpAsyncAliyun();
        //            }
        //        }
        //    }
        //    return uniqueInstance;
        //}
        public async void PostAsync(string id, string lasttime)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                   
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("tm", lasttime)

                });
                HttpResponseMessage response = await m_pHttpClient.PostAsync("http://139.129.8.107/api/api.aspx", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                if (onCompleteEvent != null)
                {
                    onCompleteEvent(id, responseBody);
                }
            }
            //catch (HttpRequestException he)
            //{
            //    if (onRequestExceptionEvent != null)
            //        onRequestExceptionEvent();
            //}
            //catch (TaskCanceledException te)
            //{
            //    if (onTaskCancelEvent != null)
            //        onTaskCancelEvent();
            //}
            catch (Exception e)
            {
                if (onExceptionEvent != null)
                {
                    onExceptionEvent();
                }
            }
            // ShowResult(JsonConvert.DeserializeObject<List<Product>>(responseBody));
        }
        //public async Task<string> PostAsync()
        //{
        //    //var response = await m_pHttpClient.PostAsync("/", new FormUrlEncodedContent(parameters));

        //    //return await response.Content.ReadAsStringAsync();

        //}
    }
}
