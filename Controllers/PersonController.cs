using CRUDWithMysqlAndAspNetCoreMVC.Data;
using CRUDWithMysqlAndAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithMysqlAndAspNetCoreMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly MyDbContext _context;

        public PersonController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> PersonList()
        {
            return View(await _context.Person.ToListAsync());
        }

        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PersonList));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePerson(int id)
        {
            Person person = await _context.Person.FindAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PersonList));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson(int id)
        {
            Person person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PersonList));
        }
    }
}
