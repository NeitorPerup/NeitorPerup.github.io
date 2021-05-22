using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspnetcore_api.Models;

namespace Aspnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly Context _context;

        public AnimalsController(Context context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetTodoItems()
        {
            return await _context.Animals
                .Select(x => AnimalToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDTO>> GetTodoItem(long id)
        {
            var todoItem = await _context.Animals.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return AnimalToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, AnimalDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await _context.Animals.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.UrlPath = todoItemDTO.UrlPath;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AnimalExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDTO>> CreateTodoItem(AnimalDTO animalDTO)
        {
            var todoItem = new Animal
            {
                UrlPath = animalDTO.UrlPath,
                Name = animalDTO.Name
            };

            _context.Animals.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                AnimalToDTO(todoItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(long id)
        {
            var todoItem = await _context.Animals.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(long id) =>
             _context.Animals.Any(e => e.Id == id);

        private static AnimalDTO AnimalToDTO(Animal animal) =>
            new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                UrlPath = animal.UrlPath
            };
    }
}
