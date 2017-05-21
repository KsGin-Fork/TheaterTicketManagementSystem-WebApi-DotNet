namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 票操作Server
    /// </summary>
    public class TicketServer
    {
        /// <summary>
        /// 售票
        /// </summary>
        /// <param name="id">票ID</param>
        /// <returns>售票结果</returns>
        public static object SellTicket(int id)
        {
            return 1;
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="id">票ID</param>
        /// <returns>退票结果</returns>
        public static object ReturnedTicket(int id)
        {
            return 1;
        }
    }
}