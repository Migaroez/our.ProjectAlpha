using ProjectAlpha.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ProjectAlpha.App_Code.Controllers
{
    public class StravaController : SurfaceController
    {
        public ActionResult Index()
        {

            IEnumerable<StravaModel> activities = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.strava.com/api/v3/athlete/");
                //HTTP Get
                var responseTask = client.GetAsync("activites");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<StravaModel>>(); // Changed to IEnumerable since your return type is a Ienumerable anyway (if you are going to run over the collection multiple times, use a List instead)
                    readTask.Wait(); // this is blocking code https://msdn.microsoft.com/en-us/library/dd235635(v=vs.110).aspx See below for a working async copy

                    activities = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    activities = Enumerable.Empty<StravaModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(activities);
        }

        public async Task<ActionResult> IndexAsync()
        {

            IEnumerable<StravaModel> activities = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.strava.com/api/v3/athlete/");
                //HTTP Get
                var responseTask = client.GetAsync("activites");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    activities = await result.Content.ReadAsAsync<IEnumerable<StravaModel>>(); 
                }
                else //web api sent error response 
                {
                    //log response status here..

                    activities = Enumerable.Empty<StravaModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View("Index", activities);
        }

        public ActionResult IndexTest()
        {

            var activities = new List<StravaModel>
            {
                new StravaModel
                {
                    athlete = new Athlete
                    {
                        id = 1
                    },
                    average_heartrate = 0.1f
                },
                new StravaModel
                {
                    athlete = new Athlete
                    {
                        id = 2
                    },
                    average_heartrate = 0.2f
                }
            };


            return View("Index",activities);
        }
    }

}