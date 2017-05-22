using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 筛选票模型
    /// </summary>
    public class SelectTicketModel
    {
        /// <summary>
        /// 影厅ID
        /// </summary>
        public int TheaterId { get; set; }
        
        /// <summary>
        /// 播放日期
        /// </summary>
        [StringLength(15)]
        public string PlayDate { get; set; }
        
        /// <summary>
        /// 播放场次
        /// </summary>
        [StringLength(10)]
        public string Performance { get; set; }
    }
}