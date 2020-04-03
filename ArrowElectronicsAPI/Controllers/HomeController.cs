using ArrowElectronicsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArrowElectronicsAPI.Controllers
{
 
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://api.arrow.com";

        public async Task<ActionResult> Index()
        {

            ArrowElectronics ArrowElectronicsObj = new ArrowElectronics();
            

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/itemservice/v3/en/search/list?req={\"request\":{\"login\":\"supremecomponents\",\"apikey\":\"07b23129ead7328ca4f14a9c08fa89f333e30d08042a5ec4d211e7b66851825d\",\"useExact\":true,\"parts\":[{\"partNum\":\"bav99\",\"mfr\":\"NXP\"},{\"partNum\":\"MT47H128M8HQ - 3:E\"},{\"partNum\":\"TMP275AIDGKT\"}]}}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var definition = new { itemserviceresult ="" };

                    //Deserializing the response recieved from web api and storing into the Employee list 
              ArrowElectronicsObj =  JsonConvert.DeserializeObject<ArrowElectronics>(EmpResponse);


                }
                //returning the employee list to view  
                return View(ArrowElectronicsObj);
            }
        }
    }
}