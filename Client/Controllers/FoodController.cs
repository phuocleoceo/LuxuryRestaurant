using Client.Repository.Interface;
using Common.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository _rp;
        public FoodController(IFoodRepository rp)
        {
            _rp = rp;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Food> list = await _rp.GetAllAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            Food food = new Food();
            // Create
            if (id == null)
            {
                return View(food);
            }
            // Edit
            food = await _rp.GetAsync(id.GetValueOrDefault()); //value or null
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Food food)
        {
            if (ModelState.IsValid)
            {
                if (food.Id == 0)
                {
                    await _rp.CreateAsync(food);
                }
                else
                {
                    await _rp.UpdateAsync(food.Id, food);
                }
                return RedirectToAction("Index");
            }
            return View(food);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Food obj = await _rp.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            await _rp.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
