using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class Case2SearchController : ApiController
    {
        // Mengambil query, mengambil data tabel, serta mengambil logic backend dari stored procedure menggunakan fitur ADO.NET 
        DbCrudEntities1 ds = new DbCrudEntities1();
        public IHttpActionResult getCase2(string age, int? pageno, int? pagesize = 8)
        {
            // Call Nama Stored Procedure dengan ketentuan 3 parameter yaitu age, pageno(Lifeboat), size(Array)
            var Readresults = ds.SP_GetCase2(age, pageno, pagesize).ToList();
            return Ok(Readresults);
        }
    }
}
