using Client.Repository.Interface;
using Common.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _rp;
        public CartController(ICartRepository rp)
        {
            _rp = rp;
        }

        public async Task<IActionResult> Index()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            List<ShoppingCart> list = await _rp.GetCarts(Convert.ToInt32(claim.Value));
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int FoodId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return Json(new { success = false, message = "Please Login First" });
            }
            ShoppingCart cart = new ShoppingCart()
            {
                FoodId = FoodId,
                UserId = Convert.ToInt32(claim.Value)
            };
            if (!await _rp.AddToCart(cart))
            {
                return Json(new { success = false, message = "Add To Cart Failure" });
            }
            return Json(new { success = true, message = "Added To Cart" });
        }

        [HttpPost]
        public async Task<IActionResult> PlusCart(int cartId)
        {
            if (!await _rp.PlusCart(cartId))
            {
                return Json(new { success = false, message = "Plus Cart Failure" });
            }
            return Json(new { success = true, message = "Plus Cart Success" });
        }

        [HttpPost]
        public async Task<IActionResult> MinusCart(int cartId)
        {
            if (!await _rp.MinusCart(cartId))
            {
                return Json(new { success = false, message = "Minus Cart Failure" });
            }
            return Json(new { success = true, message = "Minus Cart Success" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCart(int cartId)
        {
            if (!await _rp.RemoveCart(cartId))
            {
                return Json(new { success = false, message = "Remove Cart Failure" });
            }
            return Json(new { success = true, message = "Remove Cart Success" });
        }
    }
}
