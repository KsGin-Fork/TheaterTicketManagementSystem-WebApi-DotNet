using System;
using System.Collections;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("mCors")]
        public byte[] VerCode()
        {
            try
            {
                return Server.VerCode();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    
}
