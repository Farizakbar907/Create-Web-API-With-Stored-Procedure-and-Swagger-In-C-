using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using System.Net.Http;

namespace WebApplication7.Controllers
{
    public class Case1GetController : Controller
    {
        // POST: Case1Get
        [HttpPost]
        public ActionResult Index(string umur, int? lifeboat, int? size = 8)
        {
            IEnumerable<Case1> case1obj = null;
            HttpClient hc = new HttpClient();
            // Alamat Web Api 
            hc.BaseAddress = new Uri("https://localhost:44399/api/");

            // Consume API dengan ketentuan parameter
            var consumeApi = hc.GetAsync("Case1Search?age=" + umur + "&&pageno=" + lifeboat + "&&pagesize=" + size);
            consumeApi.Wait();

            var readdata = consumeApi.Result;
            // cek ketika read data apakah sukses atay tidak
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<Case1>>();
                displaydata.Wait();
                case1obj = displaydata.Result;
                //return RedirectToAction("Index");
            }
            return View(case1obj);
        }

        //[HttpPost]
        //public ActionResult Case2(string umur, int? lifeboat, int? size = 8)
        //{
        //    IEnumerable<Case2> case1obj = null;
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new Uri("https://localhost:44399/api/");

        //    var consumeApi = hc.GetAsync("Case1Search?age=" + umur + "&&pageno=" + lifeboat + "&&pagesize=" + size);
        //    consumeApi.Wait();

        //    var readdata = consumeApi.Result;
        //    if (readdata.IsSuccessStatusCode)
        //    {
        //        var displaydata = readdata.Content.ReadAsAsync<IList<Case2>>();
        //        displaydata.Wait();
        //        case1obj = displaydata.Result;
        //        //return RedirectToAction("Index");
        //    }
        //    return View(case1obj);
        //}

        // [HttpPost]
        //public ActionResult Case3(string umur, int? lifeboat, int? size = 8)
        //{
        //    IEnumerable<Case1> case1obj = null;
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new Uri("https://localhost:44399/api/");

        //    var consumeApi = hc.GetAsync("Case1Search?age=" + umur + "&&pageno=" + lifeboat + "&&pagesize=" + size);
        //    consumeApi.Wait();

        //    var readdata = consumeApi.Result;
        //    if (readdata.IsSuccessStatusCode)
        //    {
        //        var displaydata = readdata.Content.ReadAsAsync<IList<Case1>>();
        //        displaydata.Wait();
        //        case1obj = displaydata.Result;
        //        //return RedirectToAction("Index");
        //    }
        //    return View(case1obj);
        //}
    }
}