using Client.Module;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BLL.Common
{
    public class clsFunction
    {
        #region Connection
        /// <summary>
        /// Check connect to server
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static bool CheckConnect(String Url)
        {
            try
            {
                IRestClient client = new RestClient(String.Join("/", Url + "Module/TimeServer"));
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;

                IRestResponse response = client.Execute(request);
                DateTime Item = response.Content.DeserializeJsonToObject<DateTime>();
                return Item != null && Item != DateTime.MinValue;
            }
            catch { return false; }

        }
        #endregion

        #region Login
        /// <summary>
        /// Check login
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static Tuple<bool, T> Login<T>(String api, string Username, string Password)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Username", Username);
                request.AddHeader("Password", Password);
                IRestResponse response = client.Execute(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                T Item = response.Content.DeserializeJsonToObject<T>();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Tuple.Create(Status, Item);
            }
            catch { return Tuple.Create(false, ReflectionPopulator.CreateObject<T>()); }
        }
        #endregion

        #region Base Method Async
        /// <summary>
        /// Get code by prefix
        /// </summary>
        /// <returns></returns>
        public async static Task<String> GetCodeAsync(String api, String Prefix)
        {
            try
            {
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}?Prefix={Prefix}";

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = await client.ExecuteTaskAsync(request);

                String Item = response.Content.DeserializeJsonToObject<String>();
                return String.IsNullOrWhiteSpace(Item) ? string.Empty : Item;
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Get item by KeyID
        /// </summary>
        /// <returns></returns>
        public async static Task<T> GetByIDAsync<T>(String api, Object KeyID)
        {
            try
            {
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}?KeyID={KeyID}";

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = await client.ExecuteTaskAsync(request);

                T Item = response.Content.DeserializeJsonToObject<T>();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Item;
            }
            catch { return ReflectionPopulator.CreateObject<T>(); }
        }

        /// <summary>
        /// Get items by paramaters
        /// </summary>
        /// <returns></returns>
        public async static Task<List<T>> GetItemsAsync<T>(String api, params object[] Objs)
        {
            try
            {
                Objs = Objs ?? new object[] { };
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}";
                foreach (Object obj in Objs) { Url += $"/{obj}"; }

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = await client.ExecuteTaskAsync(request);

                List<T> lstResult = response.Content.DeserializeJsonToListObject<T>();
                return lstResult ?? new List<T>();
            }
            catch { return new List<T>(); }
        }

        /// <summary>
        /// Search item by paramaters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="KeyID"></param>
        /// <returns></returns>
        public static async Task<T> GetItemAsync<T>(String api, params object[] Objs)
        {
            try
            {
                Objs = Objs ?? new object[] { };
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}";
                foreach (Object obj in Objs) { Url += $"/{obj}"; }

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = await client.ExecuteTaskAsync(request);

                T Item = response.Content.DeserializeJsonToObject<T>();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Item;
            }
            catch { return ReflectionPopulator.CreateObject<T>(); }
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<Tuple<bool, T>> PostAsync<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                T Item = response.Content.DeserializeJsonToListObject<T>().FirstOrDefault();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Tuple.Create(Status, Item);
            }
            catch { return Tuple.Create(false, ReflectionPopulator.CreateObject<T>()); }
        }

        /// <summary>
        /// Insert items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static async Task<Tuple<bool, List<T>>> PostAsync<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                List<T> Items = response.Content.DeserializeJsonToListObject<T>() ?? new List<T>();

                return Tuple.Create(Status, Items);
            }
            catch { return Tuple.Create(false, new List<T>()); }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<Tuple<bool, T>> PutAsync<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.PUT;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                T Item = response.Content.DeserializeJsonToListObject<T>().FirstOrDefault();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>(); ;

                return Tuple.Create(Status, Item);
            }
            catch { return Tuple.Create(false, ReflectionPopulator.CreateObject<T>()); }
        }

        /// <summary>
        /// Update items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static async Task<Tuple<bool, List<T>>> PutAsync<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.PUT;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                List<T> Items = response.Content.DeserializeJsonToListObject<T>() ?? new List<T>();

                return Tuple.Create(Status, Items);
            }
            catch { return Tuple.Create(false, new List<T>()); }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAsync<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.DELETE;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch { return false; }
        }

        /// <summary>
        /// Delete items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAsync<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.DELETE;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteTaskAsync(request);

                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch { return false; }
        }
        #endregion

        #region Base Method
        /// <summary>
        /// Get code by prefix
        /// </summary>
        /// <returns></returns>
        public static String GetCode(String api, String Prefix)
        {
            try
            {
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}?Prefix={Prefix}";

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = client.Execute(request);

                String Item = response.Content.DeserializeJsonToObject<String>();
                return String.IsNullOrWhiteSpace(Item) ? string.Empty : Item;
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Get item by KeyID
        /// </summary>
        /// <returns></returns>
        public static T GetByID<T>(String api, Object KeyID)
        {
            try
            {
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}?KeyID={KeyID}";

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = client.Execute(request);

                T Item = response.Content.DeserializeJsonToObject<T>();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Item;
            }
            catch { return ReflectionPopulator.CreateObject<T>(); }
        }

        /// <summary>
        /// Get item by paramaters
        /// </summary>
        /// <returns></returns>
        public static List<T> GetItems<T>(String api, params object[] Objs)
        {
            try
            {
                Objs = Objs ?? new object[] { };
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}";
                foreach (Object obj in Objs) { Url += $"/{obj}"; }

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = client.Execute(request);

                List<T> lstResult = response.Content.DeserializeJsonToListObject<T>();
                return lstResult ?? new List<T>();
            }
            catch { return new List<T>(); }
        }

        /// <summary>
        /// Search item by paramaters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="KeyID"></param>
        /// <returns></returns>
        public static T GetItem<T>(String api, params object[] Objs)
        {
            try
            {
                Objs = Objs ?? new object[] { };
                String Url = ModuleHelper.Url + $"{(api.TrimStart('/'))}";
                foreach (Object obj in Objs) { Url += $"/{obj}"; }

                IRestClient client = new RestClient(Url);
                IRestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());

                IRestResponse response = client.Execute(request);

                T Item = response.Content.DeserializeJsonToObject<T>();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Item;
            }
            catch { return ReflectionPopulator.CreateObject<T>(); }
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Tuple<bool, T> Post<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                T Item = response.Content.DeserializeJsonToListObject<T>().FirstOrDefault();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Tuple.Create(Status, Item);
            }
            catch { return Tuple.Create(false, ReflectionPopulator.CreateObject<T>()); }
        }

        /// <summary>
        /// Insert items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static Tuple<bool, List<T>> Post<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                List<T> Items = response.Content.DeserializeJsonToListObject<T>() ?? new List<T>();

                return Tuple.Create(Status, Items);
            }
            catch { return Tuple.Create(false, new List<T>()); }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Tuple<bool, T> Put<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.PUT;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                T Item = response.Content.DeserializeJsonToListObject<T>().FirstOrDefault();

                if (Item == null)
                    Item = ReflectionPopulator.CreateObject<T>();

                return Tuple.Create(Status, Item);
            }
            catch { return Tuple.Create(false, ReflectionPopulator.CreateObject<T>()); }
        }

        /// <summary>
        /// Update items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static Tuple<bool, List<T>> Put<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.PUT;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                bool Status = response.StatusCode == System.Net.HttpStatusCode.OK;
                List<T> Items = response.Content.DeserializeJsonToListObject<T>() ?? new List<T>();

                return Tuple.Create(Status, Items);
            }
            catch { return Tuple.Create(false, new List<T>()); }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Delete<T>(String api, T entity)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.DELETE;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", (new List<T>() { entity }).SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch { return false; }
        }

        /// <summary>
        /// Delete items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static bool Delete<T>(String api, List<T> entries)
        {
            try
            {
                IRestClient client = new RestClient(ModuleHelper.Url + $"{(api.TrimStart('/'))}");
                IRestRequest request = new RestRequest();
                request.Method = Method.DELETE;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("IDAccount", clsGeneral.xTaiKhoan.KeyID.ToString());
                request.AddParameter("application/json", entries.SerializeListObjectToJson(), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch { return false; }
        }
        #endregion
    }
}