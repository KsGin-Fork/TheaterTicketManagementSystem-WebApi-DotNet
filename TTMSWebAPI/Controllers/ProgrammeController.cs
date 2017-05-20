using System;
using Microsoft.AspNetCore.Mvc;
using TTMSWebAPI.Models;
using TTMSWebAPI.Servers;

namespace TTMSWebAPI.Controllers
{
    /// <summary>
    /// 剧目管理API
    /// </summary>
    [Route("[controller]")]
    public class ProgrammeController : Controller
    {
        /// <summary>
        /// 获得所有剧目
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
                
                var re = ProgrammeServer.GetAllProgramme();

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
        /// 查询具体剧目信息
        /// </summary>
        /// <param name="programmeName">剧目名称</param>
        /// <returns></returns>
        [HttpGet("[action]/{programmeName}")]
        public object QueryProgrammeByName(string programmeName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = ProgrammeServer.QueryProgramme(programmeName);

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
        /// 查询具体剧目信息
        /// </summary>
        /// <param name="programmeId">剧目ID</param>
        /// <returns></returns>
        [HttpGet("[action]/{programmeId}")]
        public object QueryProgrammeById(int programmeId)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = ProgrammeServer.QueryProgramme(programmeId);

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
        /// 使用剧目标签筛选剧目
        /// </summary>
        /// <param name="tags">标签</param>
        /// <returns>剧目</returns>
        [HttpGet("[action]/{tags}")]
        public object SelectProgrammeBytags(string tags)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = ProgrammeServer.SelectProgramme(tags);

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
        /// 新建剧目
        /// </summary>
        /// <param name="cm">待新建的剧目</param>
        /// <returns>新建结果</returns>
        [HttpPost("[action]")]
        public object CreateProgramme([FromBody]CreateProgrammeModel cm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = ProgrammeServer.CreateProgramme(cm);

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
        /// 删除剧目
        /// </summary>
        /// <param name="dm">待删除的剧目</param>
        /// <returns>删除结果</returns>
        [HttpDelete("[action]")]
        public object DeleteProgramme([FromBody]DeleteProgrammeModel dm)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IpHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }
                
                var re = ProgrammeServer.DeleteProgramme(dm);

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