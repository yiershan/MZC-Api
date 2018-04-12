using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MZC.Count
{
    /// <summary>
    /// 账单数据
    /// </summary>
    public class Bill : Entity, IHasCreationTime
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatorUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 记账类型
        /// </summary>
        public int BillTypeId { get; set; }
        [ForeignKey("BillTypeId")]
        public BillType BillType { get; set; }
        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }
    }
}
