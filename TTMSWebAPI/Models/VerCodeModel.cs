using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 验证码类
    /// </summary>
    public class VerCodeModel
    {
        /// <summary>
        /// 验证码数据
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 验证码图片流
        /// </summary>
        public byte[] base64 { get; set; }
    }
}
