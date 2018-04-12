using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MZC.Count;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MZC.count
{
    public interface IBillAppServer : IApplicationService
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreatBill(CreateBillDto input);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="key"></param>
        Task DeleteBill(int key);
        /// <summary>
        /// 获取消费类型
        /// </summary>
        /// <returns></returns>
        IList<BillType> GetBillType();
        /// <summary>
        /// 获取统计信息
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="type">类型，0 按年统计，1 按月统计</param>
        /// <returns></returns>
        IList<ChartNumDto> GetCount(GetBillDto input);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="getBillDto"></param>
        /// <returns></returns>
        PagedResultDto<BillDto> GetBills(GetBillDto input);
        /// <summary>
        /// 获取记账总额
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        decimal GetTotallCount(GetBillDto input);
    }
}
