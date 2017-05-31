using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 放映厅操作API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class TheaterController : Controller
    {
        /// <summary>
        /// 获得所有影厅
        /// </summary>
        /// <returns></returns>
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
                        result = 401 ,
                        msg = "not login"
                    };
                }

                var re = TheaterServer.GetAllTheater();

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
        /// 查询影厅
        /// </summary>
        /// <param name="theaterId">影厅Id</param>
        /// <returns></returns>
        [HttpGet("[action]/{theaterId}")]
        public object QueryTheater(int theaterId)
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
                
                var re = TheaterServer.QueryTheater(theaterId);

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
        /// 修改影厅管理者
        /// </summary>
        /// <param name="um">修改影厅管理者模型</param>
        /// <returns>修改结果</returns>
        [HttpPatch("[action]")]
        public object UpdateTheaterAdminId([FromBody]UpdateTheaterAdminIDModel um)
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
                
                var re = TheaterServer.UpdateTheaterAdminId(um);

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
        /// 创建一个新演出厅
        /// </summary>
        /// <param name="cm">演出厅信息</param>
        /// <returns>创建结果</returns>
        [HttpPost("[action]")]
        public object CreateTheater([FromBody] CreateTheaterModel cm)
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
                
                var re = TheaterServer.CreateTheater(cm);

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
        /// 删除一个演出厅
        /// </summary>
        /// <param name="id">演出厅Id</param>
        /// <returns>删除结果</returns>
        [HttpDelete("[action]/{id}")]
        public object DeleteTheater(int id)
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
                
                var re = TheaterServer.DeleteTheater(id);

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