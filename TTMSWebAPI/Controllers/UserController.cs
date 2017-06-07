using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    
    /// <summary>
    /// 人事管理操作API
    /// </summary>
    [Route("[controller]")]
    [EnableCors("mCors")]
    public class UserController : Controller
    {
        /// <summary>
        /// 列出所有用户
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

                var re = UserServer.GetAllUser();

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
        /// 筛选影厅用户（管理者以及所属影厅的售票员）
        /// </summary>
        /// <param name="theaterId">影厅Id</param>
        /// <returns>用户列表</returns>
        [HttpGet("[action]/{theaterId}")]
        public object SelectUser(int theaterId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var account = HttpContext.Session.GetString("user_account");

//                if (account == null)
//                {
//                    return new
//                    {
//                        result = 401 ,
//                        msg = "not login"
//                    };
//                }

                var re = UserServer.SelectUser(theaterId);

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
        /// 获得用户信息
        /// </summary>
        /// <param name="acc">用户账号</param>
        /// <returns></returns>
        [HttpGet("[Action]/{acc}")]
        public object QueryUserByAccount(string acc)
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

                var re = UserServer.QueryUserByAccount(acc);

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
        /// 获得用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet("[Action]/{id}")]
        public object QueryUserById(int id)
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
                
                var re = UserServer.QueryUserById(id);

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
        /// 用户登陆
        /// </summary>
        /// <returns>登陆结果</returns>
        /// <param name="lm">登录用户</param>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object Login([FromBody]LoginModel lm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);

                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var verCode = HttpContext.Session.GetString("user_verCode");

                if (verCode == null)
                {
                    return new
                    {
                        result = 401,
                        msg = "verCode session is null"
                    };
                }


                if (verCode != lm.VerCode)
                {
                    return new
                    {
                        result = 401,
                        msg = "wrong verCode" , 
                        veC = verCode , 
                        subVec = lm.VerCode
                    };
                }

                var re = UserServer.Login(lm);

                if (re.result == 200)
                {
                    HttpContext.Session.SetString("user_account" , lm.Account);
                }
                
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
        /// 用户修改密码
        /// </summary>
        /// <param name="um">用户</param>
        /// <returns>修改密码结果</returns>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object UpdateUserPassword([FromBody]UpdateUserPasswordModel um)
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

                var re = UserServer.UpdateUserPassword(um);

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
        /// 用户修改等级
        /// </summary>
        /// <param name="um">用户</param>
        /// <returns>修改等级结果</returns>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object UpdateUserLevel([FromBody]UpdateUserLevelModel um)
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
                
                var re = UserServer.UpdateUserLevel(um);

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
        /// 用户修改电话
        /// </summary>
        /// <param name="um">用户</param>
        /// <returns>修改电话结果</returns>
        [HttpPatch("[action]")]
        [HttpPost("[action]")]
        public object UpdateUserTel([FromBody]UpdateUserTelModel um)
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

                var re = UserServer.UpdateUserTel(um);

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
        /// 增加一个新用户
        /// </summary>
        /// <param name="cm">增加的用户</param>
        /// <returns>增加结果</returns>
        [HttpPost("[action]")]
        public object CreateUser([FromBody]CreateUserModel cm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.CreateUser(cm);

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
        /// 删除一个用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>删除结果</returns>
        [HttpDelete("[action]/{id}")]
        public object DeleteUser(int id)
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

                var re = UserServer.DeleteUser(id);

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
