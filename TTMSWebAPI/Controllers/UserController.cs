using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
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
        /// 错误代码与错误信息
        /// </summary>
        public static Dictionary<int, string> CodeMapping = new Dictionary<int, string>
        {
            {0, "successful"},
            {1, "wrong password"},
            {2, "account not found"},
            {3, "account is exists"}

        };

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <returns>登陆结果</returns>
        /// <param name="user">登录的用户</param>  
        [HttpGet("[action]")]
        public object Login([FromBody]UserModel user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.Login(user.Account , user.Password);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }

        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>修改密码结果</returns>
        [HttpPatch("[action]")]
        public object UpdateUserPassword([FromBody]UserModel user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.UpdateUserPassword(user);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

        /// <summary>
        /// 增加一个新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>增加结果</returns>
        [HttpPost("[action]")]
        public object CreateUser([FromBody]UserModel user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.CreateUser(user);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="account">需要删除的用户账号</param>
        /// <returns>删除结果</returns>
        [HttpDelete("[action]/a={account}")]
        public object DeleteUser(string account)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.DeleteUser(account);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        [HttpGet("[action]/a={account}")]
        public object GetUser(string account)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.GetUser(account);

                return re;
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

        /// <summary>
        /// 用户修改等级
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>修改等级结果</returns>
        [HttpPatch("[action]")]
        public object UpdateUserLevel([FromBody] UserModel user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.UpdateUserLevel(user);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

        /// <summary>
        /// 用户修改电话
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>修改电话结果</returns>
        [HttpPatch("[action]")]
        public object UpdateUserTel([FromBody] UserModel user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.UpdateUserTel(user);

                return new {code = (int) re , msg = CodeMapping[(int)re]};
            }
            catch (Exception e)
            {
                return new {code = 301 , msg = e.Message };
            }
        }

    }
}
