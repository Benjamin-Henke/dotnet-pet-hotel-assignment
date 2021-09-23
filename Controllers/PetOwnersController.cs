using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetList() 
        {
            return _context.PetOwner;
        }

        // [HttpGet]
        // public IEnumerable<PetOwner> GetById(int id)

        [HttpPost]
        public PetOwner Post(PetOwner petowner)
        {
            _context.Add(petowner);
            _context.SaveChanges();

            return petowner;
        }
    }
}
