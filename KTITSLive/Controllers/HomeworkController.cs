using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KTITSLive.Controllers
{
    [Route("[controller]")]
    [ApiController]
 
    public class HomeworkController : ControllerBase
    {
        private readonly ILogger<HomeworkController> _logger;

        public HomeworkController(ILogger<HomeworkController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "GetHomework")]
        public string[] Get(DateTime date)
        {
            return Program.HWController.Get(date);
        }
        [HttpPost(Name ="PostNewHomework")]
        public void Post(DateTime date, int lessonIndex, string hw)
        {
            Program.HWController.Set(date, lessonIndex, hw);
        }
    }
}
