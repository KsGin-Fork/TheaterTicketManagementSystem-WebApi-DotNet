using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 座位管理Server
    /// </summary>
    public class SeatServer
    {
        /// <summary>
        /// 获得所有座位
        /// </summary>
        /// <returns>座位列表</returns>
        public static object GetAllSeat()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询座位信息
        /// </summary>
        /// <param name="seatId">座位ID</param>
        /// <returns>座位信息</returns>
        public static object QuerySeat(int seatId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新座位状态
        /// </summary>
        /// <param name="um">更新座位状态模型</param>
        /// <returns>更新结果</returns>
        public static object UpdateSeatStatus(UpdateSeatStatusModel um)
        {
            throw new System.NotImplementedException();
        }
    }
}