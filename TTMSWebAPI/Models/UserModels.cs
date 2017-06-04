using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 创建用户POST模型
    /// </summary>
    public class CreateUserModel
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
        
        /// <summary>
        /// 用户所在影厅
        /// </summary>
        public int theaterId { get; set; }
    }

    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginModel
    {
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
        /// 验证码
        /// </summary>
        [StringLength(10)]
        public string VerCode { get; set; }
    } 
    
    /// <summary>
    /// 修改用户密码模型
    /// </summary>
    public class UpdateUserPasswordModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(15)]
        public string Password { get; set; }
    }
    
    /// <summary>
    /// 修改用户权限等级模型
    /// </summary>
    public class UpdateUserLevelModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户权限级别
        /// </summary>
        [StringLength(15)]
        public string Level { get; set; }
    }
    
    /// <summary>
    /// 修改用户电话模型
    /// </summary>
    public class UpdateUserTelModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [StringLength(12)]
        public string Tel { get; set; }
    }

}