using Newtonsoft.Json;
using SuperFastBlog.Data;
using SuperFastBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SuperFastBlog.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {

            var response = new ApiStatus();
            string url = "https://localhost:44390/api/";

            try
            {
                ApiStatus EmpInfo = new ApiStatus();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("article/GetAllArticles");
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<ApiStatus>(EmpResponse);
                    }

                    List<Article> listOfArticles = new List<Article>();
                    if (EmpInfo.Code == (int)Status.Complete)
                    {
                        listOfArticles = JsonConvert.DeserializeObject<List<Article>>(EmpInfo.Message);
                    }
                    ViewBag.ListOfArticles = listOfArticles;

                    var ddd = Convert.ToBase64String(listOfArticles.FirstOrDefault().Image);
                    //returning the employee list to view
                    return View(listOfArticles);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}