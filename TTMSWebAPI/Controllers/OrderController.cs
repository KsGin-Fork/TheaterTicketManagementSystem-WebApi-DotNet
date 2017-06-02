using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 订单API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class OrderController : Controller
    {
        /// <summary>
        /// 获得所有订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetAllOrder()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401 ,
                        msg = "not login"
                    };
                }
                
                var re = OrderServer.GetAllOrder();

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult ,
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 筛选订单
        /// </summary>
        /// <param name="sm">选择订单模型</param>
        /// <returns>筛选结果</returns>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object SelectOrder([FromBody]SelectOrderModel sm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401 ,
                        msg = "not login"
                    };
                }
                
                var re = OrderServer.SelectOrder(sm);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult ,
                    msg = e.Message
                };
            }
        }
    }
}