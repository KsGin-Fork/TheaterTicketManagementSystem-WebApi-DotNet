using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")] 
    public class HomeController : Controller
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns>返回页面</returns>
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }
    }
}
