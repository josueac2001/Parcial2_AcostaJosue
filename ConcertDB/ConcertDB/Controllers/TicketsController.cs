using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcertDB.DAL;
using ConcertDB.DAL.Entities;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Net.Sockets;

namespace ConcertDB.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DatabaseContext _context;

        public TicketsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
              return _context.Tickets != null ? 
                          View(await _context.Tickets.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Tickets'  is null.");
        }

       

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // GET: Tickets/Validate
        public IActionResult Validate()
        {
            return View();
        }

        // POST: Tickets/Validate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validate(Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                //var c = _context.Find<Tickets>(tickets.Id);
                //if (c == null)
                //{
                //    ModelState.AddModelError(string.Empty, "Ticket no valido"); 
                //}
                //else if (tickets.IsUsed)
                //{
                //    ModelState.AddModelError(string.Empty, $"Este Ticket fue usada el {tickets.UseDate} por la porteria {tickets.EntranceGate}");
                //}
                //else
                //{
                    
                //}
                tickets.IsUsed = true;
                tickets.UseDate = DateTime.Now;
                _context.Update(tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tickets);
        }

        

        private bool TicketsExists(Guid id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<String> ValidateTicket(Guid id)
        {
           var  ticket = _context.Tickets.FirstOrDefault(e => e.Id == id);
            if(ticket == null)
            {
                return"Ticket no valido";
            }
            else if (ticket.IsUsed)
            {
                return $"Este Ticket fue usada el {ticket.UseDate} por la porteria {ticket.EntranceGate}";
            }
            else
            {
                return "";
            }
        }
   
    }
}
