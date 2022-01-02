using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KEService.Services;
using KEService.Models;
using System.Net;

namespace KEService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private APIResponce apiresponce;

        [HttpGet("getpersonlist")]
        public IActionResult GetPersonData()
        {
            apiresponce = new APIResponce();

            PersonService objPersonService = new PersonService();

            var response = objPersonService.GetPersonList();

            if (response == null)
            {
                apiresponce.StatusCode = (int)HttpStatusCode.BadRequest;
                apiresponce.Data = response;
            }
            else
            {
                apiresponce.StatusCode = (int)HttpStatusCode.OK;
                apiresponce.Data = response;
            }

            return new JsonResult(apiresponce);
        }

        [HttpPost("getpersondatabyid")]
        public IActionResult GetPersonById(PersonModel model)
        {
            PersonService objPersonService = new PersonService();

            var response = objPersonService.GetPersonDataById(model.Oid);

            if (response == null)
                return BadRequest(new { message = "No Record found" });

            int status = (int)HttpStatusCode.OK;
            return Ok(response);
        }
    }
}
