﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardAPI.Data;
using CardAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace CardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("GamePolicy")]
    public class CardsController : ControllerBase
    {
        private readonly GameContext _context;

        public CardsController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCard()
        {
            return await _context.Card.Include(ch => ch.Character).ToListAsync();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.Card.Include(ch => ch.Character).FirstOrDefaultAsync(i => i.CardID == id); //FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // GET api/cards/1/character
        [HttpGet("{id:int}/character")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var card = await _context.Card.Include(ch => ch.Character).FirstOrDefaultAsync(i => i.CardID == id);

            if (card == null)
                return NotFound();

            return card.Character;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.CardID)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _context.Card.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.CardID }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteCard(int id)
        {
            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }



        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.CardID == id);
        }
    }
}
