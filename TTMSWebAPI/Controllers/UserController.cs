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
        /// 用户登陆
        /// </summary>
        /// <returns>登陆结果</returns>
        /// <param name="Account">账号</param>
        /// <param name="Password">密码</param>
        [HttpGet("[action]/a={Account}&p={Password}")]
        public object Login(string Account , string Password)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UserServer.Login(Account , Password);

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
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

                return re;
            }
            catch (Exception e)
            {
                return "{ " + e.HResult + " : \"" + e.Message + "\" }";
            }
        }

    }
}
