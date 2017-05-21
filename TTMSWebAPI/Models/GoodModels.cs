using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 上架节目ID
    /// </summary>
    public class CreateGoodModel
    {
        /// <summary>
        /// 节目ID
        /// </summary>
        public int ProgrammeId { get; set; }
        /// <summary>
        /// 放映厅ID
        /// </summary>
        public int TheaterId { get; set; }
        /// <summary>
        /// 放映场次
        /// </summary>
        [StringLength(10)]
        public string Performance { get; set; }
        /// <summary>
        /// 放映日期
        /// </summary>
        [StringLength(15)]
        public string PlayDate { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
    }
}