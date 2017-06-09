using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 电影票操作API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class TicketController : Controller
    {
        /// <summary>
        /// 查询票信息
        /// </summary>
        /// <param name="id">票Id</param>
        /// <returns></returns>
        [HttpGet("[action]/{Id}")]
        public object QueryTicket(int id)
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
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = TicketServer.QueryTicket(id);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult,
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 筛选票
        /// </summary>
        /// <param name="goodId">节目ID</param>
        /// <returns></returns>
        [HttpGet("[action]/{goodId}")]
        public object SelectTicket(int goodId)
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
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = TicketServer.SelectTicket(goodId);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult,
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 订票
        /// </summary>
        /// <param name="ticketId">票ID</param>
        /// <returns>售票结果</returns>
        [HttpPost("[action]/{ticketId}")]
        public object SellTicket(int ticketId)
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
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = TicketServer.SellTicket(ticketId);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult,
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="ticketId">票Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpPost("[action]/{ticketId}&{userId}")]
        public object PayTicket(int ticketId, int userId)
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
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = TicketServer.PayTicket(ticketId, userId);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult,
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 退票操作
        /// </summary>
        /// <param name="ticketId">票ID</param>
        /// <param name="userId">用户ID</param>        
        /// <returns>售票结果</returns>
        [HttpPost("[action]/{ticketId}&{userId}")]
        public object ReturnedTicket(int ticketId, int userId)
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
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = TicketServer.ReturnedTicket(ticketId, userId);

                return re;
            }
            catch (Exception e)
            {
                return new
                {
                    result = e.HResult,
                    msg = e.Message
                };
            }
        }
    }
}