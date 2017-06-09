using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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

                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = GoodServer.GetAllGood();

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

                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = GoodServer.QueryGood(goodId);

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
        /// 筛选商品
        /// </summary>
        /// <returns>商品列表</returns>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object SelectGood([FromBody] SelectGoodModel sgm)
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

                var re = GoodServer.SelectGood(sgm);

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

                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = GoodServer.CreateGood(cm);

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

                var account = HttpContext.Session.GetString("user_account");

                if (account == null)
                {
                    return new
                    {
                        result = 401,
                        msg = "not login"
                    };
                }

                var re = GoodServer.DeleteGood(id);

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