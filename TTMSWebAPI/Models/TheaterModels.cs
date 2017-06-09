using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 创建影厅模型
    /// </summary>
    public class CreateTheaterModel
    {
        /// <summary>
        /// 影厅名称
        /// </summary>
        [StringLength(30)]
        public string TheaterName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(30)]
        public string Location { get; set; }
        /// <summary>
        /// 地图链接
        /// </summary>
        [StringLength(30)]
        public string MapSite { get; set; }
        /// <summary>
        /// 行座位个数
        /// </summary>
        public int SeatRowCount { get; set; }
        /// <summary>
        /// 列座位个数
        /// </summary>
        public int SeatColCount { get; set; }
    }
}