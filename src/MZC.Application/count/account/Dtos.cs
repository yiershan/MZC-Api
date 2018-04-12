using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MZC.count
{
    public class BillDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        public string Time
        {
            get
            {
                return CreationTime.ToShortDateString();
            }
        }
        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// font图标 样式名称
        /// </summary>
        public string FontStyle { get; set; }
    }

    public class GetBillDto : IPagedResultRequest, ISortedResultRequest
    {
        [Range(0, 1000)]
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }

        public DateTime? Date { get; set; }
        public string User { get; set; }
        /// <summary>
        /// 数据类型，0 按年，1按月,
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 分组依据 0，消费类型，1 月
        /// </summary>
        public int GroupBy { get; set; }

    }

    public class CreateBillDto
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatorUser { get; set; }
        /// <summary>
        /// 记账类型
        /// </summary>
        [Required]
        public int BillTypeId { get; set; }
        /// <summary>
        /// 记账金额
        /// </summary>
        [Required]
        public decimal Money { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }
    }

    public class ChartNumDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

    }
}
