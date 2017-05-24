using System;
using Microsoft.AspNetCore.Cors;
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
        /// <param name="Id">票Id</param>
        /// <returns></returns>
        [HttpGet("[action]/{Id}")]
        public object QueryTicket(int Id)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.QueryTicket(Id);

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
        /// 筛选票
        /// </summary>
        /// <param name="theaterId">影厅ID</param>
        /// <param name="playDate">播放日期</param>
        /// <param name="performance">场次</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public object SelectTicket(int theaterId , string playDate , string performance)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.SelectTicket(theaterId , playDate , performance);

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
        /// 售票
        /// </summary>
        /// <param name="ticketId">票ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>售票结果</returns>
        [HttpPost("[action]/{ticketId}&{userId}")]
        public object SellTicket(int ticketId , int userId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.SellTicket(ticketId , userId);

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
        /// <param name="ticketId">票ID</param>
        /// <param name="userId">用户ID</param>        
        /// <returns>售票结果</returns>
        [HttpPost("[action]/{ticketId}&{userId}")]
        public object ReturnedTicket(int ticketId , int userId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = TicketServer.ReturnedTicket(ticketId , userId);

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