using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Models.Entity
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ngày mở bán
        /// </summary>
        public DateTime OpenDaySale { get; set; }
        /// <summary>
        /// Tình trạng
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Lượt xem
        /// </summary>
        public int View { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Mô tả đầy đủ
        /// </summary>
        public string FullDescription { get; set; }
        /// <summary>
        /// Mã danh mục sản phẩm
        /// </summary>
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        /// <summary>
        /// Mã đơn vị tính sản phẩm
        /// </summary>
        public string UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
