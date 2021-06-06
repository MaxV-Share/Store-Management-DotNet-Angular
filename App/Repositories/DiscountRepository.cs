﻿using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class DiscountRepository :  BaseRepository<Discount, int>,IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Discount> PostAsync(DiscountCR request)
        {
            if (request == null)
                return null;
            Discount obj = new Discount()
            {
                PercentDiscount = request.PercentDiscount,
                MaxDiscountPrice = request.MaxDiscountPrice,
                FromDate = request.FromDate,
                ToDate = request.ToDate

            };
            var result = await CreateAsync(obj);
            return result;
        }
    }
}