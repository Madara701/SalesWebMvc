﻿using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models.Services
{
    public class SellerService
    {
        private SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context) {

            _context = context;

        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }

        public void Adiciona(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
