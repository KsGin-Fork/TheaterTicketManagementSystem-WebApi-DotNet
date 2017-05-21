using System;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 电影票操作API
    /// </summary>
    public class TicketController : Controller
    {
        /// <summary>
        /// 售票操作
        /// </summary>
        /// <param name="id">票ID</param>
        /// <returns>售票结果</returns>
        [HttpPost("{id}")]
        public object SellTicket(int id)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.SellTicket(id);

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
        /// 退票操作
        /// </summary>
        /// <param name="id">票ID</param>
        /// <returns>售票结果</returns>
        public object ReturnedTicket(int id)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.ReturnedTicket(id);

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