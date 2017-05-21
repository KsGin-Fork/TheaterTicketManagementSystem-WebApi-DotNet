using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 新建剧目模型
    /// </summary>
    public class CreateProgrammeModel
    {
        /// <summary>
        /// 剧目名称
        /// </summary>
        [StringLength(50)]
        public string ProgrammeName { get; set; }
        /// <summary>
        /// 剧目时长
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 剧目标签
        /// </summary>
        [StringLength(20)]
        public string Tags { get; set; }
        /// <summary>
        /// 剧目简介
        /// </summary>
        public string Profile { get; set; }
    }
}