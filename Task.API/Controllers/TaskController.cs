using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.API.Models;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : ControllerBase
    {
        //CREATE => POST 
        //READ => GET 
        //UPDATE => PUT/PATCH
        //DELETE => DELETE

        //private static readonly List<ToDoItem> _todoItems = [];
        private static readonly List<ToDoItem> _todoItems = new List<ToDoItem>();


        // GET api/tasks
        [HttpGet]
        //public IActionResult Get()
        public ActionResult<IEnumerable<ToDoItem>> Get()
        {
            return Ok(_todoItems);
        }

        // GET api/tasks/1
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        //Post api/tasks
        [HttpPost]
        public ActionResult Post([FromBody] ToDoItem todoItem)
        {
            _todoItems.Add(todoItem);
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        // PUT api/tasks/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ToDoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var todoItemToUpdate = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemToUpdate == null)
            {
                return NotFound();
            }

            todoItemToUpdate.Title = todoItem.Title;
            todoItemToUpdate.Description = todoItem.Description;
            todoItemToUpdate.IsCompleted = todoItem.IsCompleted;

            return NoContent();
        }

        // Delete api/tasks/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todoItemToDelete = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemToDelete == null)
            {
                return NotFound();
            }
            _todoItems.Remove(todoItemToDelete);
            return NoContent();
        }

    }
}
