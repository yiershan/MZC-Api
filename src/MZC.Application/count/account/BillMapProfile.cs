using AutoMapper;
using MZC.Count;
using System;
using System.Collections.Generic;
using System.Text;

namespace MZC.count
{
    public class BillMapProfile : Profile
    {
        public BillMapProfile()
        {
            CreateMap<CreateBillDto, Bill>().AfterMap((s, d, c) => {
                d.CreationTime = DateTime.Now;
            });
        }
    }
}
