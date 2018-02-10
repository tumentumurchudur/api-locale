using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocaleApi.Dal;
using LocaleApi.Models;

namespace LocaleApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Localization")]
    public class LocalizationController : Controller
    {
        // GET api/localization
        [HttpGet]
        public IEnumerable<Localization> Get()
        {
            var dataAccess = new DataAccess();

            return dataAccess.ReadAll();
        }
    }
}