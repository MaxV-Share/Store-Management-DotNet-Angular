using App.Models.DTOs;
using App.Repositories.Interface;
using App.Services.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly IBillRepository _billRepository;
        private readonly ConnectionString _connectionString;
        public RevenueService(IBillRepository billRepository, IOptions<ConnectionString> connectionString)
        {
            _billRepository = billRepository;
            _connectionString = connectionString.Value;
        }
        public async Task<IEnumerable<RevenueViewModel>> RevenueMonthlyOfYear(int year)
        {
            IEnumerable<RevenueViewModel> result = new List<RevenueViewModel>();
            var query = string.Format(@"SELECT 
	                                        MONTH( bills.create_at ) as 'Id',
	                                        SUM( bills.payment_amount ) as TotalPrice
                                        FROM
	                                        bills 
                                        WHERE
	                                        YEAR( bills.create_at ) = {0}
                                        GROUP BY
	                                        MONTH( bills.create_at )
                                        ORDER BY MONTH( bills.create_at )", year);

            using (var connection = new SqlConnection(_connectionString.DefaultConnection))
            {
                connection.Open();

                result = await connection.QueryAsync<RevenueViewModel>(query);
            }

            return result;
        }
        public async Task<IEnumerable<RevenueViewModel>> RevenueDailyOfMonth(int year, int month)
        {
            IEnumerable<RevenueViewModel> result = new List<RevenueViewModel>();
            var query = string.Format(@"SELECT 
	                                        DAY( bills.create_at ) AS 'Id',
	                                        SUM( bills.payment_amount ) AS TotalPrice 
                                        FROM
	                                        bills 
                                        WHERE
	                                        YEAR( bills.create_at ) = {0} 
	                                        AND MONTH ( bills.create_at ) = {1}
                                        GROUP BY
	                                        DAY( bills.create_at )
                                        ORDER BY DAY( bills.create_at )", year, month);

            using (var connection = new SqlConnection(_connectionString.DefaultConnection))
            {
                connection.Open();

                result = await connection.QueryAsync<RevenueViewModel>(query);
            }

            return result;
        }
    }
}
