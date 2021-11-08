using Client.Repository.Interface;
using Common.Entities;
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
        public MenuController(IFoodRepository rp)
        {
            _rp = rp;
        }

        public async Task<IActionResult> Index()
        {
            List<Food> list = await _rp.GetAllAsync();
            return View(list);
        }        
    }
}
