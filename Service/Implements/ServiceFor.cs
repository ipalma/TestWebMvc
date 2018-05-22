using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class ServiceFor<T> : ServiceBase, IService<T> where T : class, new()
    {
        private readonly HttpClient _dataclient = new HttpClient();
        public ICollection<T> Get(string controllerName, string actionName)
        {
            WebRequest wr;

            string requestUrl = string.Concat(_url,controllerName, "/",actionName);
            List<T> data = new List<T>();

            wr = WebRequest.Create(requestUrl);

            wr.Method = "GET";

            WebResponse responser = wr.GetResponse();

            using(var stream = responser.GetResponseStream())
            {
                using(var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    data = JsonConvert.DeserializeObject<List<T>>(result);
                }
            }
            return data;
        }

        public T Get(string controllerName, string actionName, int id)
        {
            WebRequest wr;

            string requestUrl = string.Concat(_url, controllerName, "/", actionName,"?id=",id);
            T data = new T();

            wr = WebRequest.Create(requestUrl);

            wr.Method = "GET";

            WebResponse responser = wr.GetResponse();

            using (var stream = responser.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var jObjResult = JObject.Parse(result);
                    data = jObjResult.ToObject<T>();
                }
            }
            return data;
        }
        public virtual T Get(string controllerName, string actionName, Dictionary<string,string> queryParams)
        {
            WebRequest wr;

            string requestUrl = string.Concat(_url, controllerName, "/", actionName);
            T data = new T();
            wr = WebRequest.Create(requestUrl);
            wr.Method = "POST";
            WebResponse responser = wr.GetResponse();

            using(var stream = responser.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var jObjResult = JObject.Parse(result);
                    data = jObjResult.ToObject<T>();
                }
            }
            return data;

        }
    }
}
