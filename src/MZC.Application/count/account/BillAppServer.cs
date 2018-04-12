using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MZC.Count;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZC.count
{
    public class BillAppServer : AbpServiceBase, IBillAppServer
    {
        private readonly IRepository<Bill> _billRepository;
        private readonly IRepository<BillType> _billTypeRepository;
        public BillAppServer(IRepository<Bill> billRepository,
            IRepository<BillType> billTypeRepository
            )
        {
            _billRepository = billRepository;
            _billTypeRepository = billTypeRepository;
        }

        public async Task DeleteBill(int key)
        {
            await _billRepository.DeleteAsync(key);
        }

        public async Task CreatBill(CreateBillDto input)
        {
            var bill = ObjectMapper.Map<Bill>(input);
            await _billRepository.InsertAsync(bill);
        }

        public IList<BillType> GetBillType()
        {
            return _billTypeRepository.GetAllList();
        }

        public IList<ChartNumDto> GetCount(GetBillDto input)
        {
            if (!input.Date.HasValue) return null;
            string date = "";
            DateTime startDate, endDate;
            if (input.Type == 1)
            {
                date = input.Date.Value.ToString("yyyy-MM");
                startDate = DateTime.Parse(date);
                endDate = startDate.AddMonths(1);
            }
            else
            {
                date = input.Date.Value.Year + "-01-01";
                startDate = DateTime.Parse(date);
                endDate = startDate.AddYears(1);
            }

            if (input.GroupBy == 1)
            {
                var bills = _billRepository.GetAll().Where(m => m.CreationTime >= startDate && m.CreationTime < endDate && m.CreatorUser == input.User);
                return bills.GroupBy(m => m.CreationTime.Month).Select(m => new ChartNumDto
                {
                    Name = m.Key + "月",
                    Value = m.Sum(n => n.Money)
                }).ToList();
            }
            else
            {
                var bills = _billRepository.GetAll().Where(m => m.CreationTime >= startDate && m.CreationTime < endDate && m.CreatorUser == input.User).Include(m => m.BillType);
                return bills.GroupBy(m => m.BillType.Name).Select(m => new ChartNumDto
                {
                    Name = m.Key,
                    Value = m.Sum(n => n.Money)
                }).ToList();
            }


        }

        public PagedResultDto<BillDto> GetBills(GetBillDto input)
        {
            if (!input.Date.HasValue) return null;
            var date = input.Date.Value.ToString("yyyy-MM");
            var startDate = DateTime.Parse(date);
            var endDate = startDate.AddMonths(1);
            var bills = _billRepository.GetAll().Where(m => m.CreationTime >= startDate && m.CreationTime < endDate && m.CreatorUser == input.User);
            var count = bills.Count();
            var billsPage = bills
                                        .Include(q => q.BillType)
                                        .OrderByDescending(q => q.CreationTime)
                                        .PageBy(input)
                                        .Select(m => new BillDto
                                        {
                                            Name = m.BillType.Name,
                                            FontStyle = m.BillType.FontStyle,
                                            Money = m.Money,
                                            Id = m.Id,
                                            CreationTime = m.CreationTime
                                        })
                                        .ToList();
            return new PagedResultDto<BillDto>
            {
                TotalCount = count,
                Items = billsPage
            };
        }
        public decimal GetTotallCount(GetBillDto input)
        {
            var bills = _billRepository.GetAll().Where(m => m.CreatorUser == input.User);
            return bills.Sum(m => m.Money);
        }
    }
}
