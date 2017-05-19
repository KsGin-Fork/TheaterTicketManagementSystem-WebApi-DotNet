namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 更新座位状态模型
    /// </summary>
    public class UpdateSeatStatusModel
    {
        /// <summary>
        /// 座位ID
        /// </summary>
        public int SeatId { get; set; }
        /// <summary>
        /// 座位状态
        /// </summary>
        public bool Status { get; set; }
    }
}