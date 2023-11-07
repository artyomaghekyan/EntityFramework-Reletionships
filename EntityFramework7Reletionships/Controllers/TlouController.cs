using EntityFramework7Reletionships.Data;
using EntityFramework7Reletionships.DTOs;
using EntityFramework7Reletionships.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Reletionships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlouController : ControllerBase
    {
        private readonly Datacontext _context;
        public TlouController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await _context.Characters
                .Include(c => c.BackPack)
                .Include(c => c.Wepon)
                .Include(c => c.Factions)
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(character);   
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
                
            };
            var backpack = new BackPack
            {
                Description = request.BackPack.Description,
                Character = newCharacter
            };
            var wepon = request.Wepons.Select(w => new Wepon
            {
                Name = w.Name,
                Character = newCharacter
            }).ToList();
            var faction = request.Fractions.Select(f => new Faction
            {
                Name = f.Name,
                Characters = new List<Character> { newCharacter }
            }).ToList();
            newCharacter.BackPack = backpack;
            newCharacter.Wepon = wepon;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => 
            c.BackPack).Include(c => c.Wepon).ToListAsync());
            

        }
    }
}
