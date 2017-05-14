using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [StringLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        [StringLength(15)]
        public string Account { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(15)]
        public string Password { get; set; }
        /// <summary>
        /// 用户权限级别
        /// </summary>
        [StringLength(15)]
        public string Level { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [StringLength(10)]
        public string Sex { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        [StringLength(12)]
        public string Tel { get; set; }
    }
}