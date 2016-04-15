using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace VisionDemo.Controllers
{
    public class RestCalls
    {
        public string HostAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public enum ObjectTypes { Cubes, Dimensions }

        public RestCalls(string hostAddress, string username, string password)
        {
            HostAddress = hostAddress;
            Username = username;
            Password = password;
        }

        public List<string> GetObjectNames(ObjectTypes objectName)
        {
            List<string> Names = new List<string>();

            using (var client = new System.Net.Http.HttpClient())
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Username, Password)));

                client.BaseAddress = new Uri(HostAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Basic", "Realm=\"TM1\"");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string query = objectName.ToString() + "?$select=Name";

                HttpResponseMessage response = client.GetAsync(query).Result;

                string json = response.Content.ReadAsStringAsync().Result;

                dynamic cubes = JObject.Parse(json);

                JArray cubeList = cubes.value;

                return cubeList.Select(x => x.SelectToken("Name").ToString()).ToList();
            }

            return Names;
        }

        public List<string> GetViewNamesForCube(string CubeName)
        {
            List<string> Names = new List<string>();

            using (var client = new System.Net.Http.HttpClient())
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Username, Password)));

                client.BaseAddress = new Uri(HostAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Basic", "Realm=\"TM1\"");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string query = "Cubes('" + CubeName + "')/Views?$select=Name";

                HttpResponseMessage response = client.GetAsync(query).Result;

                string json = response.Content.ReadAsStringAsync().Result;

                dynamic views = JObject.Parse(json);

                JArray viewList = views.value;

                return viewList.Select(x => x.SelectToken("Name").ToString()).ToList();
            }

            return Names;
        }
    }
}