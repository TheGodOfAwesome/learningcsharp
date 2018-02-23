using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ToDoApplication.Entities;
using ToDoApplication.Extensions;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    [Route("api/todo/")]
    public class ToDoController : ApiController
    {
        private readonly ToDoDatabaseEntity _context;

        public ToDoController()
        {
            _context = new ToDoDatabaseEntity();
        }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            var toDos = _context.ToDoTables.ToList().ToModelUsingMapper<List<ToDoTable>, List<ToDoItem>>();
            return toDos;
        }

        [HttpGet, Route("api/todo/{id}")]
        public ToDoItem GetById(int id)
        {
            return _context.ToDoTables.FirstOrDefault(x => x.Id == id).ToModelUsingMapper<ToDoItem>();
        }


        // POST api/todo/
        public ToDoItem Post([FromBody]ToDoItem todo)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException("failed to add todos");
            }

            var entity = todo.ToModelUsingMapper<ToDoTable>();
            _context.ToDoTables.Add(entity);
            _context.SaveChanges();

            return todo;
        }

        // PUT api/todo/
        public ToDoItem Put([FromBody]ToDoItem todo)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException("failed to add todo");
            }

            var entity = todo.ToModelUsingMapper<ToDoTable>();
            _context.ToDoTables.Add(entity);
            _context.SaveChanges();

            return todo;
        }

        // DELETE api/todo
        public IEnumerable<ToDoItem> Delete(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("no id");
            }

            ToDoTable table = _context.ToDoTables.Find(id);
            _context.ToDoTables.Remove(table);
            _context.SaveChanges();
  
            var toDos = _context.ToDoTables.ToList();
            return toDos.Select(toDo => toDo.ToModelUsingMapper<ToDoItem>());
        }
    }
}
