using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 座位管理API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class SeatController : Controller
    {
        /// <summary>
        /// 获得所有座位
        /// </summary>
        /// <returns>座位列表</returns>
        [HttpGet]
        public object Get()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = SeatServer.GetAllSeat();

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
        /// 查询座位信息
        /// </summary>
        /// <param name="seatId">座位ID</param>
        /// <returns>座位信息</returns>
        [HttpGet("[Action]/sid={seatId}")]
        public object QuerySeat(int seatId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = SeatServer.QuerySeat(seatId);

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
        /// 更新座位状态
        /// </summary>
        /// <param name="um">更新座位状态模型</param>
        /// <returns>更新结果</returns>
        [HttpPatch("[Action]")]
        [HttpPost("[action]")]
        public object UpdateSeatStatus([FromBody] UpdateSeatStatusModel um)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = SeatServer.UpdateSeatStatus(um);

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
        /// 新增座位
        /// </summary>
        /// <param name="cm">新增座位</param>
        /// <returns></returns>
        [HttpPost("[Action]")]
        [HttpPut("[action]")]
        public object CreateSeat([FromBody] CreateSeatModel cm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = SeatServer.CreateSeat(cm);

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
        /// 删除座位
        /// </summary>
        /// <param name="id">座位id</param>
        /// <returns>删除结果</returns>
        [HttpDelete("[Action]/{id}")]
        public object DeleteSeat(int id)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = SeatServer.DeleteSeat(id);

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