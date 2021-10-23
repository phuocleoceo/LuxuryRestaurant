using Client.Repository.Interface;
using Common.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class MenuController : Controller
    {
        private readonly IFoodRepository _rp;
        private readonly ICartRepository _rp_cart;
        public MenuController(IFoodRepository rp, ICartRepository rp_cart)
        {
            _rp = rp;
            _rp_cart = rp_cart;
        }

        public async Task<IActionResult> Index()
        {
            List<Food> list = await _rp.GetAllAsync();
            return View(list);
        }        
    }
}
