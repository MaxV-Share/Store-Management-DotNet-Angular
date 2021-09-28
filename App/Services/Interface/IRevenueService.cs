using App.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IRevenueService
    {
        Task<IEnumerable<RevenueViewModel>> RevenueMonthlyOfYear(int year);
        Task<IEnumerable<RevenueViewModel>> RevenueDailyOfMonth(int year, int month);
    }
}
