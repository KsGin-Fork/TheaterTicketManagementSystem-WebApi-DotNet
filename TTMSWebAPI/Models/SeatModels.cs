namespace TTMSWebAPI.Models
{

    /// <summary>
    /// 新增座位模型
    /// </summary>
    public class CreateSeatModel
    {
        /// <summary>
        /// 放映厅Id
        /// </summary>
        public int theaterId { get; set; }
        
        /// <summary>
        /// 座位行数
        /// </summary>
        public int rowNumber { get; set; }
        
        /// <summary>
        /// 座位列数
        /// </summary>
        public int colNumber { get; set; }
        
        /// <summary>
        /// 座位状态
        /// </summary>
        public bool Status { get; set; }
        
    }
    
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