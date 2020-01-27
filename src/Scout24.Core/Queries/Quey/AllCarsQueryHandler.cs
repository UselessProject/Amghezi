﻿using System;
using System.Collections.Generic;
using System.Text;
using Scout24.Core.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scout24.Core.Queries.Quey
{
    public class AllCarsQueryHandler : IQueryHandler<AllCarsQuery, IEnumerable<Car>>
    {
        private Scout24Context _context;

        public AllCarsQueryHandler(Scout24Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> Get(AllCarsQuery query)
        {
            var cars = (from car in _context.Car.Skip(query.pageIndex).Take(query.pageCount)
                       select car);
            return await cars.ToArrayAsync();
        }
    }
}
