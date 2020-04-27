using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStationWebAPI.Data;

namespace WeatherStationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // Skal måske bruge signInManager og userManager? (Identity??)

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login og register endpoints below:

    }
}