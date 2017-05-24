using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 商品(已上架剧目)操作API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class GoodController : Controller
    {
        /// <summary>
        /// 获得所有商品信息
        /// </summary>
        /// <returns>商品列表</returns>
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
                
                var re = GoodServer.GetAllGood();

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
        /// 查询商品信息
        /// </summary>
        /// <param name="goodId">商品ID</param>
        /// <returns>商品信息</returns>
        [HttpGet("[action]/{goodId}")]
        public object QueryGood(int goodId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.QueryGood(goodId);

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
        /// 根据放映厅筛选商品
        /// </summary>
        /// <param name="theaterId">放映厅Id</param>
        /// <returns>商品列表</returns>
        [HttpGet("[action]/{theaterId}")]
        public object SelectGoodByTheater(int theaterId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.SelectGoodByTheater(theaterId);

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
        /// 根据节目筛选商品
        /// </summary>
        /// <param name="programmeId">节目Id</param>
        /// <returns></returns>
        [HttpGet("[action]/{programmeId}")]
        public object SelectGoodByProgramme(int programmeId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.SelectGoodByProgramme(programmeId);

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
        /// 根据日期筛选商品
        /// </summary>
        /// <param name="date">日期(format:xxxx-xx-xx)</param>
        /// <returns></returns>
        [HttpGet("[action]/{date}")]
        public object SelectGoodByDate(string date)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.SelectGoodByDate(date);

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
        /// 根据场次筛选商品
        /// </summary>
        /// <param name="performance">场次</param>
        /// <returns></returns>
        [HttpGet("[action]/{performance}")]
        public object SelectGoodByPerformance(string performance)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.SelectGoodByPerformance(performance);

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
        /// 上架节目
        /// </summary>
        /// <param name="cm">上架节目模型</param>
        /// <returns>上架结果</returns>
        [HttpPost("[action]")]
        public object CreateGood([FromBody] CreateGoodModel cm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.CreateGood(cm);

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
        /// 下架商品
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <returns>下架结果</returns>
        [HttpDelete("[action]/{id}")]
        public object DeleteGood(int id)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = GoodServer.DeleteGood(id);

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