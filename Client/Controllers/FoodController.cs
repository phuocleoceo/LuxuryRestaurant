﻿using Client.Repository.Interface;
using Common.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<Food> list = await _rp.GetAllAsync();
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
                IFormFileCollection files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] pic = null;
                    using (var fs = files[0].OpenReadStream())
                    {
                        using var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        pic = ms.ToArray();
                    }
                    food.Image = pic;
                }
                else if (food.Id == 0)
                {
                    // If we're creating but not choose any Picture
                    food.Image = null;
                }
                else
                {
                    //Reuse old picture if we're updating and not choose any Picture
                    Food objFromDb = await _rp.GetAsync(food.Id);
                    food.Image = objFromDb.Image;
                }


                if (food.Id == 0)
                {
                    await _rp.CreateAsync(food);
                    TempData["Alert"] = "Add Food Successfully !";
                }
                else
                {
                    await _rp.UpdateAsync(food);
                    TempData["Alert"] = "Edit Food Successfully !";
                }
                return RedirectToAction(nameof(Index));
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
            TempData["Alert"] = "Delete Food Successfully !";
            return RedirectToAction("Index");
        }
    }
}
