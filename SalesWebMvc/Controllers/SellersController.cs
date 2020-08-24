using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesWebMvc.Models.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index() {

            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() {

            var departments = _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel { Departments = departments};
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller) {
            
            _sellerService.Adiciona(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
