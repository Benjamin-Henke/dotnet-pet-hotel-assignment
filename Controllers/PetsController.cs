using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetList() 
        {
            return _context.Pet
                .Include(pet => pet.petOwner); 
        }

        [HttpPost]
        public Pet Post(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();

            return pet;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            Pet pet = _context.Pet.Find(id);
            _context.Pet.Remove(pet);
            _context.SaveChanges();
        }

        // http://localhost:3000/api/pets/2/checkout
    //    [HttpPut("{id}/sell")]
        [HttpPut("{id}/checkout")]
        public IActionResult Checkout(int id) {
            Console.WriteLine("CHECK OUT");
            Pet pet = _context.Pet.Find(id);
            Console.WriteLine(pet.checkedInAt);
    
            DateTime dt = new DateTime(); 

            if(pet.checkedInAt != null) {
                pet.checkedInAt = null;
            } else {
                // DateTime dt = new DateTime();
                pet.checkedInAt = dt; 
            }
            
            
            // if (pet == null) return NotFound();
            // if (pet.checkedInAt != null) return BadRequest(new { error = "Cant reduce inventory below zero" });
            // // bread.sell();
            // pet.checkedInAt = 'date';
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }

        [HttpPut("{id}/checkin")]
        public IActionResult Checkin(int id) {
            Console.WriteLine("CHECK IN");
            Pet pet = _context.Pet.Find(id);
            DateTime dt = new DateTime(); 
            if(pet.checkedInAt == null) {
                pet.checkedInAt = dt;
            } else {
                pet.checkedInAt = null; 
            }
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }


    }
}



    // [HttpPut("{id}/sell")]
    // public IActionResult SellById(int id) {
    //     BreadInventory bread = _context.BreadInventory.Find(id);
    //     if (bread == null) return NotFound();
    //     if (bread.inventory <= 0) return BadRequest(new { error = "Cant reduce inventory below zero" });
    //     bread.sell();
    //     _context.Update(bread);
    //     _context.SaveChanges();
    //     return Ok(bread);
    // }
