using Client.Repository.Interface;
using Common.DTO;
using Common.Entities;
using Common.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize(Roles = Constant.Role_Customer)]
    public class RequestController : Controller
    {
        public RequestController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
