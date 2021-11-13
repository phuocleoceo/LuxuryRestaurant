using Client.Repository.Interface;
using Common.DTO;
using Common.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IOrderRepository _rp_order;

        public CartController(ICartRepository rp, IOrderRepository rp_order)
        {
            _rp = rp;
            _rp_order = rp_order;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            List<ShoppingCart> list = await _rp.GetCarts(Convert.ToInt32(claim.Value));
            IEnumerable<CartVM> listCart = list.Select(c => new CartVM
            {
                Id = c.Id,
                FoodName = c.Food.Name,
                FoodPrice = c.Food.Price,
                Count = c.Count,
                Image = c.Food.Image != null ? $"data:image/jpg;base64,{Convert.ToBase64String(c.Food.Image)}" : "https://via.placeholder.com/150"
            });
            double total = list.Sum(c => c.Count * c.Food.Price);
            return Json(new { listCart, total });
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

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int UserId = Convert.ToInt32(claim.Value);
            if (!await _rp_order.PlaceOrder(UserId))
            {
                return Json(new { success = false, message = "Place Order Failure" });
            }
            return Json(new { success = true, message = "Place Order Success" });
        }
    }
}
