using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Servers;

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

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns>验证码</returns>
        [HttpGet("[action]")]
        public object VerCode()
        {
            try
            {
                var verCode = Server.VerCode();

                HttpContext.Session.SetString("user_verCode" , verCode.code);

                return Server.VerCode();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    
}
