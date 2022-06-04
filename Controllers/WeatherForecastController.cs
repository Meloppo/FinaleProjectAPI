using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinaleProject.Data;

namespace FinaleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public DataBContext Context;

        public WeatherForecastController(DataBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var cars = Context.Cars.ToList();
            return Ok(cars);
        }
    }
}
