using System.ComponentModel.DataAnnotations;

namespace TTMSWebAPI.Models
{
    /// <summary>
    /// 上架节目模型
    /// </summary>
    public class CreateGoodModel
    {
        /// <summary>
        /// 剧目ID
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

    /// <summary>
    /// 筛选商品模型
    /// </summary>
    public class SelectGoodModel
    {
        /// <summary>
        /// 剧目ID
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
    }
}