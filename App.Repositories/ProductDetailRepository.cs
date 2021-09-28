using App.Models.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class ProductDetailRepository : BaseRepository<ProductDetail, int>, IProductDetailRepository
    {
        public ProductDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
