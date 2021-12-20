using Client.Repository.Interface;
using Common.DTO;
using Common.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize(Roles = Constant.Role_Customer)]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _rp;
        public RequestController(IRequestRepository rp)
        {
            _rp = rp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(string message)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            UserRequest ur = new UserRequest
            {
                UserId = Convert.ToInt32(claim.Value),
                Message = message
            };
            if (!await _rp.SendRequest(ur))
            {
                return Json(new { success = false, message = "Gửi thất bại" });
            }
            return Json(new { success = true, message = "Gửi thành công" });
        }
    }
}
